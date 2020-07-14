using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Escolar2020.UIForms.ViewModels;
using Escolar2020.UIForms.Views;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Escolar2020.UIForms
{
    public partial class App : Application
    {
        public static MasterPage Master { get; internal set; }

        public static NavigationPage Navigator { get; internal set; }

        public App()
        {
            InitializeComponent();
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
