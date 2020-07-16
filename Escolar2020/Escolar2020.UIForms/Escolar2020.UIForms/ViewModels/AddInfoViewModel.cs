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
        public string Image { get; set; }

        public AddInfoViewModel(Tutor tutor)
        {
            this.Tutor = tutor;
        }

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

        public string Profesion { get; set; }
        public string Empresa { get; set; }
        public string Puesto { get; set; }
        public string Telefono { get; set; }

        public ICommand SaveCommand => new RelayCommand(Save);

        public AddInfoViewModel()
        {
            apiService = new ApiService();
            Image = "Not_image";
            IsEnabled = true;
        }
        private async void Save()
        {
            if (string.IsNullOrEmpty(Profesion))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Escriba su profesión.", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(Empresa))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Escriba su Empresa.", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(Puesto))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Escriba su puesto.", "Aceptar");
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            //TODO: Add image
            var tutor = new Tutor
            {
                //IsAvailabe = true,
                PuestoEmpresa = this.Puesto,
                Profesion = this.Profesion,
                NombreEmpresa = this.Empresa,
                TelefonoTrabajo = this.Telefono 
                //User = new User { UserName = MainViewModel.GetInstance().UserEmail }    
            };
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await apiService.PostAsync(
                url,
                "/api",
                "/App_Tutor",
                tutor,
                "bearer",
                MainViewModel.GetInstance().Token.Token);

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            var newTutor = (Tutor)response.Result;
            MainViewModel.GetInstance().Tutors.Tutors.Add(newTutor);

            IsRunning = false;
            IsEnabled = true;
            await App.Navigator.PopAsync();
        }
    }
}
