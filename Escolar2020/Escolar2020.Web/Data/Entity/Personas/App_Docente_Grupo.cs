namespace Escolar2020.Web.Data.Entity.Personas
{
    using System.ComponentModel.DataAnnotations;
    public class App_Docente_Grupo 
    {
        public int Persona_Id { get; set; }
        public int Ciclo_Id { get; set; }
        [MaxLength(10)]
        [Display(Name = "Ciclo Escolar")]
        public string Ciclo_Escolar { get; set; }

        public int Grupo_Id { get; set; }
        [MaxLength(10)]
        [Display(Name = "Grupo")]
        public string Grupo { get; set; }
    }
}
