namespace Escolar2020.UIForms.ViewModels
{
    using Common.Models;
    using UIForms.Views.Tutor;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;


    public class TutorItemViewModel : Tutor
    {
        public ICommand SelectTutorCommand => new RelayCommand(this.SelectTutor);

        private async void SelectTutor()
        {
            MainViewModel.GetInstance().AddInfo = new AddInfoViewModel((Tutor)this);
            await App.Navigator.PushAsync(new AddInfoTutorPage());
        }

    }
}
