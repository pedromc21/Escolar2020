namespace Escolar2020.Web.Data.Entity.Cursos
{
    using System.ComponentModel.DataAnnotations;
    public class App_Cursos
    {
        [Required]
        public int Curso_Id { get; set; }

        //Docente_Id
        [Required]
        public int Persona_Id { get; set; }

        [Required]
        public int Plantel_Id { get; set; }

        [Required]
        public int Grupo_Id { get; set; }

        [Required]
        public int Ciclo_Id { get; set; }

        [MaxLength(50, ErrorMessage = "El Campo {0} debe de tener {1} de longitud")]
        [Required]
        [Display(Name = "Clave Materia")]
        public string Clave_Materia { get; set; }

        [MaxLength(500, ErrorMessage = "El Campo {0} debe de tener {1} de longitud")]
        [Required]
        public string Materia { get; set; }
    }
}
