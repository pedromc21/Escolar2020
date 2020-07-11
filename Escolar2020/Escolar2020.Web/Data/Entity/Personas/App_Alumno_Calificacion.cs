namespace Escolar2020.Web.Data.Entity.Personas 
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class App_Alumno_Calificacion
    {
        public int Curso_Id { get; set; }
        public int Persona_Id { get; set; }
        public int Ciclo_Id { get; set; }
        [MaxLength(10)]
        [Display(Name = "Ciclo Escolar")]
        public string Ciclo_Escolar { get; set; }

        [Display(Name = "N° Periodo")]
        public int Num_Periodo { get; set; }

        [MaxLength(50, ErrorMessage = "El Campo {0} debe de tener {1} de longitud")]
        [Required]
        [Display(Name = "Clave Materia")]
        public string  Clave_Materia { get; set; }

        public int Materia_Id { get; set; }
        [MaxLength(100)]
        [Display(Name = "Materia")]
        public string Materia { get; set; }

        [Display(Name = "Calificación")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Calificacion { get; set; }

        public int Faltas { get; set; }
                
    }
}
