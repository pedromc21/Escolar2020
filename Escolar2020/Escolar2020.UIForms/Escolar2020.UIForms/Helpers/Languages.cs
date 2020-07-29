namespace Escolar2020.UIForms.Helpers
{
    using Interfaces;
    using Resources;
    using Xamarin.Forms;
    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }
        public static string Ok => Resource.Ok;
        public static string Error => Resource.Error;
        public static string ErrorUser => Resource.ErrorUser;
        public static string ErrorLogin => Resource.ErrorLogin;
        public static string ErrorPassword => Resource.ErrorPassword;
        public static string Login => Resource.Login;
        public static string Usuario => Resource.Usuario;
        public static string Contraseña => Resource.Contraseña;
        public static string Recuerdame => Resource.Recuerdame;
        public static string PlaceholderUser => Resource.PlaceholderUser;
        public static string PlaceholderContraseña => Resource.PlaceholderContraseña;
    }

}
