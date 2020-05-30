namespace Escolar2020.Web.Data.Entity.Personas 
{
    using System.ComponentModel.DataAnnotations;
    public class App_Alumno : IEntity
    {
        public int Id { get; set; }

        [Required]
        public int Persona_Id { get; set; }
        [MaxLength(50, ErrorMessage = "El Campo {0} debe de tener {1} de longitud")]
        [Required]
        [Display(Name = "Clave Familia")]
        public string Clave_Familia { get; set; }

        [MaxLength(10)]
        [Required]
        public string Matricula { get; set; }

        [MaxLength(100)]
        public string NIA { get; set; }
    }
}
