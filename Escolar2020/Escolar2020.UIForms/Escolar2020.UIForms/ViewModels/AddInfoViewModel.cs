namespace Escolar2020.UIForms.ViewModels
{
    using Common.Models;
    using Common.Services;
    using GalaSoft.MvvmLight.Command;
    using Plugin.Media;
    using Plugin.Media.Abstractions;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class AddInfoViewModel : BaseViewModel
    {
        private bool isRunning;
        private bool isEnabled;
        public Tutor Tutor { get; set; }
        private readonly ApiService apiService;
        public string FullName { get; set; }       
        private ImageSource imageSource;
        private MediaFile file;
        public ImageSource ImageSource
        {
            get => this.imageSource;
            set => this.SetValue(ref this.imageSource, value);
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
        public ICommand ChangeImageCommand => new RelayCommand(this.ChangeImage);
        public ICommand SaveCommand => new RelayCommand(Save);
        public AddInfoViewModel()
        {
            apiService = new ApiService();
        }
        public AddInfoViewModel(Tutor tutor)
        {
            apiService = new ApiService();
            Tutor = tutor;
            FullName = Tutor.CPerson.FullName;
            ImageSource = "Not_image";
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
        private async void ChangeImage()
        {
            await CrossMedia.Current.Initialize();
            //Dialogo con varias opciones
            var source = await Application.Current.MainPage.DisplayActionSheet(
                "Donde tomas la foto?",
                "Cancelar",
                null,
                "De la galería",
                "De la cámara");
            if (source == "Cancelar")
            {
                this.file = null;
                return;
            }
            if (source == "De la cámara")
            {
                this.file = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        Directory = "Pictures",
                        Name = "test.jpg",
                        PhotoSize = PhotoSize.Small,
                    }
                );
            }
            else
            {
                this.file = await CrossMedia.Current.PickPhotoAsync();
            }

            if (this.file != null)
            {
                this.ImageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
            }
        }
    }
}
