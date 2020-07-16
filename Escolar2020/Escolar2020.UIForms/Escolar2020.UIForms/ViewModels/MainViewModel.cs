namespace Escolar2020.UIForms.ViewModels
{
    using Common.Models;
    using Escolar2020.UIForms.Views.Tutor;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    public class MainViewModel
    {
        private static MainViewModel instance;
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
        public TokenResponse Token { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public LoginViewModel Login { get; set; }
        public TutorsViewModel Tutors { get; set; }
        public AlumnosViewModel Alumnos { get; set; }
        public AddInfoViewModel AddInfo { get; set; }
        public ICommand AddInfoCommand { get { return new RelayCommand(GoAddInfo); } }
        public MainViewModel()
        {
            instance = this;
            LoadMenus();
        }
        //Singleton Clasico (Es para poder referir de la ViewModel desde cualquier sito)
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        private void LoadMenus()
        {
            var menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "ic_notifications",
                    PageName = "Notificacion",
                    Title = "Notificaciones"
                },
                new Menu
                {
                    Icon = "ic_DataFamily",
                    PageName = "DatosFamilia",
                    Title = "Datos de la Familia"
                },
                new Menu
                {
                    Icon = "ic_Data_Factura",
                    PageName = "DatosFacturacion",
                    Title = "Datos de Facturación"
                },
                new Menu
                {
                    Icon = "ic_Calificaciones",
                    PageName = "Calificacion",
                    Title = "Calificaciones"
                },
                new Menu
                {
                    Icon = "ic_EdoCuenta",
                    PageName = "EdoCuenta",
                    Title = "Estado de Cuenta"
                },
                new Menu
                {
                    Icon = "ic_money",
                    PageName = "Pagar",
                    Title = "Pagar"
                },
                new Menu
                {
                    Icon = "ic_exit_to_app",
                    PageName = "LoginPage",
                    Title = "Cerrar session"
                }
            };

            Menus = new ObservableCollection<MenuItemViewModel>(menus.Select(m => new MenuItemViewModel
            {
                Icon = m.Icon,
                PageName = m.PageName,
                Title = m.Title
            }).ToList());
        }
        private async void GoAddInfo()
        {
            AddInfo = new AddInfoViewModel();
            await App.Navigator.PushAsync(new AddInfoTutorPage());
        }
    }
}
