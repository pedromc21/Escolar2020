namespace Escolar2020.UIForms.ViewModels
{
    using Common.Models;
    using Common.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class TutorsViewModel : BaseViewModel
    {
        private readonly ApiService apiService;
        private ObservableCollection<Tutor> tutors;
        private bool isRefreshing;
        public ObservableCollection<Tutor> Tutors
        {
            get => this.tutors;
            set => this.SetValue(ref this.tutors, value);
        }
        public bool IsRefreshing
        {
            get => this.isRefreshing;
            set => this.SetValue(ref this.isRefreshing, value);
        }
        public TutorsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadTutorts();
        }
        private async void LoadTutorts()
        {
            this.IsRefreshing = true; 
            var response = await this.apiService.GetListAsync<Tutor>(
                "http://app_escolar.gissa.com.mx",
                "/api",
                "/App_Tutor");
            this.IsRefreshing = false;
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Aceptar");
                return;
            }
            var myTutors = (List<Tutor>)response.Result;
            this.Tutors = new ObservableCollection<Tutor>(myTutors);

        }
    }
}
