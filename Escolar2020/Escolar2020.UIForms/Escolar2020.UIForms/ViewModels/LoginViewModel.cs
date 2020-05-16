namespace Escolar2020.UIForms.ViewModels
{
    using Escolar2020.UIForms.Views;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel 
    {
        public string Email { get; set; }
        public string Pasword { get; set; }
        public ICommand LoginCommand => new RelayCommand(Login);
        public LoginViewModel()
        {
            this.Email = "Pedro";

        }
        private async void Login()
        {
            if (string.IsNullOrEmpty (this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Escriba el Usuario", "Aceptar");
                return; 
            }
            if (string.IsNullOrEmpty(this.Pasword))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Escriba la contraseña", "Aceptar");
                return;
            }
            if (!this.Email.Equals("Pedro") || !this.Pasword.Equals("12345") )
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Credenciales incorrectas", "Aceptar");
            }
            //await Application.Current.MainPage.DisplayAlert("Listo", "Ok", "Aceptar");
            MainViewModel.GetInstance().Tutors = new TutorsViewModel();   
            await Application.Current.MainPage.Navigation.PushAsync(new TutorsPage());
        }
    }
}
