namespace Escolar2020.Web.Data.Entity.Catalogos
{
    using Entity.Personas;
    using System.ComponentModel.DataAnnotations;
    public class App_c_Status : IEntity
    {
        public int Id { get; set; }
        public int Status_Id { get; set; }
        public string Clave { get; set; }
        [Display(Name = "Estatus del Alumno")]
        public string Status { get; set; }
        public App_Alumno_Grado alumGradoStatus { get; set; }
    }
}
