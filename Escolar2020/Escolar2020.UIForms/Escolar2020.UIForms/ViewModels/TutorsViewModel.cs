namespace Escolar2020.UIForms.ViewModels
{
    using Common.Models;
    using Common.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Xamarin.Forms;

    public class TutorsViewModel : BaseViewModel
    {
        private readonly ApiService apiService;
        private bool isRefreshing;
        //Una lista del Objeto Tutor (Mantiene en Momoria)
        private List<Tutor> myTutors;
        //Un Observable Del Item del Tutor seleccionado
        private ObservableCollection<TutorItemViewModel> tutors;
        //Un Propiedad el Observable Collection
        public ObservableCollection<TutorItemViewModel> Tutors
        {
            get => tutors;
            set => SetValue(ref tutors, value);
        }
        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetValue(ref isRefreshing, value);
        }
        public TutorsViewModel()
        {
            apiService = new ApiService();
            LoadTutorts();
        }
        private async void LoadTutorts()
        {
            IsRefreshing = true;
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await apiService.GetListAsync<Tutor>(
                url,
                "/api",
                "/App_Tutor",
                "?clave_Familia=ABARCLAZC",
                "bearer",
                MainViewModel.GetInstance().Token.Token);
            IsRefreshing = false;
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Aceptar");
                return;
            }
            this.myTutors = (List<Tutor>)response.Result;
            this.RefresTutorsList();
        }

        public void AddTutorToList(Tutor Tutor)
        {
            this.myTutors.Add(Tutor);
            this.RefresTutorsList();
        }

        public void UpdateTutorInList(Tutor Tutor)
        {
            var previousTutor = this.myTutors.Where(p => p.Id == Tutor.Id).FirstOrDefault();
            if (previousTutor != null)
            {
                this.myTutors.Remove(previousTutor);
            }

            this.myTutors.Add(Tutor);
            this.RefresTutorsList();
        }

        public void DeleteTutorInList(int productId)
        {
            var previousTutor = this.myTutors.Where(p => p.Id == productId).FirstOrDefault();
            if (previousTutor != null)
            {
                this.myTutors.Remove(previousTutor);
            }

            this.RefresTutorsList();
        }

        private void RefresTutorsList()
        {
            this.Tutors = new ObservableCollection<TutorItemViewModel>(myTutors.Select(p => new TutorItemViewModel
            {
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                ImageFullPath = p.ImageFullPath,
                //IsAvailabe = p.IsAvailabe,
                //LastPurchase = p.LastPurchase,
                //LastSale = p.LastSale,
                PuestoEmpresa = p.PuestoEmpresa,
                NombreEmpresa = p.NombreEmpresa,
                Profesion = p.Profesion,
                TelefonoTrabajo = p.TelefonoTrabajo
            })
            .OrderBy(p => p.Name)
            .ToList());
        }
    }
}
