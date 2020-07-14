namespace Escolar2020.UIForms.ViewModels
{
    using Escolar2020.Common.Models;
    using Escolar2020.Common.Services;
    using Escolar2020.UIForms.Views;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        private readonly ApiService apiService;
        private bool isRunning;
        private bool isEnabled;
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
            Email = "alcantara.karla_renee@imex.edu.mx";
            //Password = "123456";
            IsEnabled = true;
        }
        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Escriba el Usuario", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Escriba la contraseña", "Aceptar");
                return;
            }
            this.IsRunning = true;
            this.IsEnabled = false;
            var request = new TokenRequest
            {
                Password = this.Password,
                Username = this.Email
            };

            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await this.apiService.GetTokenAsync(
                url,
                "/Account",
                "/CreateToken",
                request);

            this.IsRunning = false;
            this.IsEnabled = true;

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Usuario o password incorrecto.", "Aceptar");
                return;
            }

            var token = (TokenResponse)response.Result;
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = token;
            //Singleton para Instanciar ViewModel en Memoria
            mainViewModel.Tutors = new TutorsViewModel();
            Application.Current.MainPage = new MasterPage();            
        }
    }
}
