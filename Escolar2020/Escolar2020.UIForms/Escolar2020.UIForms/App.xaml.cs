
namespace Escolar2020.UIForms
{
    using Views;
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using Escolar2020.UIForms.ViewModels;

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainViewModel.GetInstance().Login = new LoginViewModel();  
            this.MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
