namespace Escolar2020.UIForms.ViewModels
{
    using Common.Models;
    using Common.Services;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class AddInfoViewModel : BaseViewModel
    {
        private bool isRunning;
        private bool isEnabled;
        public Tutor Tutor { get; set; }

        private readonly ApiService apiService;
        public string FullName { get; set; }
        public string ImageFullPath { get; set; }
        
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
        public ICommand SaveCommand => new RelayCommand(Save);
        public AddInfoViewModel()
        {
            apiService = new ApiService();
        }
        public AddInfoViewModel(Tutor tutor)
        {
            Tutor = tutor;
            FullName = Tutor.CPerson.FullName;
            ImageFullPath = Tutor.CPerson.ImageFullPath;
            apiService = new ApiService();
            IsEnabled = true;
        }
        private async void Save()
        {
            if (string.IsNullOrEmpty(this.Tutor.Profesion))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Escriba su profesión.", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Tutor.NombreEmpresa))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Escriba su Empresa.", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Tutor.PuestoEmpresa))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Escriba su puesto.", "Aceptar");
                return;
            }
            IsRunning = true;
            IsEnabled = false;
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await apiService.PutAsync(
                url,
                "/api",
                "/App_Tutor",
                Tutor.Id,
                Tutor,
                "bearer",
                MainViewModel.GetInstance().Token.Token);
            IsRunning = false;
            IsEnabled = true;
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }
            var modifiedTutor = (Tutor)response.Result;
            MainViewModel.GetInstance().Tutors.UpdateTutorInList(modifiedTutor);
            await App.Navigator.PopAsync();
        }
    }
}
