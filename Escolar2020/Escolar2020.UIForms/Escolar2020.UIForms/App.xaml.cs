using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Escolar2020.UIForms.ViewModels;
using Escolar2020.UIForms.Views;
using Escolar2020.Common.Helpers;
using Newtonsoft.Json;
using System;
using Escolar2020.Common.Models;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Escolar2020.UIForms
{
    public partial class App : Application
    {
        public static NavigationPage Navigator { get; internal set; }
        public static MasterPage Master { get; internal set; }
        public App()
        {
            InitializeComponent();
            if (Settings.IsRemember)
            {
                var token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
                if (token.Expiration > DateTime.Now)
                {
                    var mainViewModel = MainViewModel.GetInstance();
                    mainViewModel.Token = token;
                    mainViewModel.UserEmail = Settings.UserEmail;
                    mainViewModel.UserPassword = Settings.UserPassword;
                    mainViewModel.Tutors = new TutorsViewModel();
                    this.MainPage = new MasterPage();
                    return;
                }
            }
            MainViewModel.GetInstance().Login = new LoginViewModel(); 
            MainPage = new NavigationPage(new LoginPage());
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
