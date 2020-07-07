namespace Escolar2020.Web.Data.Entity.Catalogos
{
    using Entity.Personas;
    using System.ComponentModel.DataAnnotations;
    public class App_c_Plantel : IEntity
    {
        public int Id { get; set; }
        public int Plantel_Id { get; set; }
        public string Clave { get; set; }
        [Display(Name = "Plantel")]
        public string Plantel { get; set; }
        public App_Alumno_Grado alumGradoPlantel { get; set; }
    }
}
