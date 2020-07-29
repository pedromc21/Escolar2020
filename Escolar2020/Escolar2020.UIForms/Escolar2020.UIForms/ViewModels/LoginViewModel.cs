namespace Escolar2020.UIForms.ViewModels
{
    using Escolar2020.Common.Helpers;
    using Escolar2020.Common.Models;
    using Escolar2020.Common.Services;
    using Escolar2020.UIForms.Helpers;
    using Escolar2020.UIForms.Views;
    using GalaSoft.MvvmLight.Command;
    using Newtonsoft.Json;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        private readonly ApiService apiService;
        private bool isRunning;
        private bool isEnabled;
        public bool IsRemember { get; set; }
        public bool IsRunning
        {
            get => isRunning;
            set => SetValue(ref isRunning, value);
        }
        public bool IsEnabled
        {
            get => isEnabled;
            set => SetValue(ref isEnabled, value);
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand => new RelayCommand(Login);
        public LoginViewModel()
        {
            apiService = new ApiService();
            //Email = "alcantara.karla_renee@imex.edu.mx";
            //Password = "123456";
            IsEnabled = true;
            IsRemember = true;
        }
        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await Application.Current.MainPage.DisplayAlert(Languages.Error, Languages.ErrorUser, Languages.Ok);
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert(Languages.Error, Languages.ErrorPassword, Languages.Ok);
                return;
            }
            IsRunning = true;
            IsEnabled = false;
            var request = new TokenRequest
            {
                Password = Password,
                Username = Email
            };

            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await apiService.GetTokenAsync(
                url,
                "/Account",
                "/CreateToken",
                request);

            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(Languages.Error, Languages.ErrorLogin, Languages.Ok);
                return;
            }

            var token = (TokenResponse)response.Result;
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.UserEmail = Email;
            mainViewModel.UserPassword = Password;
            mainViewModel.Token = token;
            //Singleton para Instanciar ViewModel en Memoria
            mainViewModel.Tutors = new TutorsViewModel();

            //Guardar datos en persistencia
            Settings.IsRemember = this.IsRemember;
            Settings.UserEmail = this.Email;
            Settings.UserPassword = this.Password;
            Settings.Token = JsonConvert.SerializeObject(token);
            //Llamar Matar Page que contiene la pantalla principal
            Application.Current.MainPage = new MasterPage();
        }
    }
}
