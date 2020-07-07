namespace Escolar2020.Web.Data.Entity.Catalogos
{
    using Entity.Personas;
    using System.ComponentModel.DataAnnotations;
    public class App_c_CicloEsc : IEntity
    {
        public int Id { get; set; }
        public int Ciclo_Id { get; set; }

        [Display(Name = "Ciclo Escolar")]
        public string Ciclo_Escolar { get; set; }

        public App_Alumno_Grado alumGradoCiclo { get; set; }

    }
}
