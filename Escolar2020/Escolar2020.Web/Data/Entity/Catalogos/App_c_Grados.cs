namespace Escolar2020.Web.Data.Entity.Catalogos
{
    using Entity.Personas;
    using System.ComponentModel.DataAnnotations;
    public class App_c_Grado : IEntity
    {
        public int Id { get; set; }
        public int Grado_Id { get; set; }
        public int Seccion_Id { get; set; }
        public string Clave { get; set; }
        [Display(Name = "Grado")]
        public string Grado { get; set; }
        public int Orden { get; set; }
        public App_Alumno_Grado alumGradoGrado { get; set; }

    }
}
