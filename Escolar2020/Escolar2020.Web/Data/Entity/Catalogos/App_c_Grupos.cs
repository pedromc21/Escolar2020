namespace Escolar2020.Web.Data.Entity.Catalogos
{
    using Entity.Personas;
    using System.ComponentModel.DataAnnotations;
    public class App_c_Grupo : IEntity
    {
        public int Id { get; set; }
        public int Grupo_Id { get; set; }
        public string Clave { get; set; }
        [Display(Name = "Grupo")]
        public string Grupo { get; set; }
        public int Orden { get; set; }
        public App_Alumno_Grado alumGradoGrupo { get; set; }
    }
}
