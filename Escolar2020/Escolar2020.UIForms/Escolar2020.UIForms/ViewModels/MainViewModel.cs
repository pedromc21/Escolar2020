namespace Escolar2020.UIForms.ViewModels
{
    public class MainViewModel
    {
        private static MainViewModel instance;
        public LoginViewModel Login { get; set; }
        public TutorsViewModel Tutors { get; set; }
        public AlumnosViewModel Alumnos { get; set; }

        public MainViewModel()
        {
            instance = this;
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
    }
}
