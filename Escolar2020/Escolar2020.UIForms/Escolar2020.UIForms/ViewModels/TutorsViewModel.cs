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
            var myTutors = (List<Tutor>)response.Result;
            Tutors = new ObservableCollection<Tutor>(myTutors);
        }
    }
}
