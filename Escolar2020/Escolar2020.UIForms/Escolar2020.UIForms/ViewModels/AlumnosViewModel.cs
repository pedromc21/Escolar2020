namespace Escolar2020.UIForms.ViewModels
{
    using Common.Models;
    using Common.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class AlumnosViewModel :BaseViewModel
    {
        private readonly ApiService apiService;
        private ObservableCollection<Alumno> alumnos;
        private bool isRefreshing;
        public ObservableCollection<Alumno> Alumnos
        {
            get => this.alumnos;
            set => this.SetValue(ref this.alumnos, value);
        }
        public AlumnosViewModel()
        {
            this.apiService = new ApiService();
            this.LoadAlumnos();
        }
        private async void LoadAlumnos()
        {
            var response = await this.apiService.GetListAsync<Alumno>(
                "http://app_escolar.gissa.com.mx",
                "/api",
                "App_Alumno",
                "? clave_Familia = ABARCLAZC");
            this.isRefreshing = false;
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Aceptar");
                return;
            }
            var myAlumnos = (List<Alumno>)response.Result;
            this.Alumnos = new ObservableCollection<Alumno>(myAlumnos);
        }
    }
}
