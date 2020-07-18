namespace Escolar2020.UIForms.ViewModels
{
    using Common.Helpers;
    using Views;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MenuItemViewModel : Common.Models.Menu
    {
        public ICommand SelectMenuCommand => new RelayCommand(SelectMenu);

        private async void SelectMenu()
        {
            //Oculta el Menu al dar clic en una opcion
            App.Master.IsPresented = false;
            var mainViewModel = MainViewModel.GetInstance();

            switch (PageName)
            {
                case "Calificacion":
                    await App.Navigator.PushAsync(new Views.Tutor.CalificacionPage());
                    break;
                case "DatosFacturacion":
                    await App.Navigator.PushAsync(new Views.Tutor.DatosFacturacionPage());
                    break;
                case "Notificacion":
                    await App.Navigator.PushAsync(new Views.Tutor.NotificacionPage());
                    break;
                case "DatosFamilia":
                    await App.Navigator.PushAsync(new Views.Tutor.DatosFamiliaPage());
                    break;
                case "EdoCuenta":
                    await App.Navigator.PushAsync(new Views.Tutor.EdoCuentaPage());
                    break;
                case "Pagar":
                    await App.Navigator.PushAsync(new Views.Tutor.PagarPage());
                    break;
                default:
                    Settings.IsRemember = false;
                    Settings.Token = string.Empty;
                    Settings.UserEmail = string.Empty;
                    Settings.UserPassword = string.Empty;
                    MainViewModel.GetInstance().Login = new LoginViewModel();
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                    break;
            }
        }
    }
}
