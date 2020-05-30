namespace Escolar2020.Web.Data.Entity.Personas 
{
    using Entity.Catalogos;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class App_Alumno_Calificacion
    {
        public int Curso_Id { get; set; }
        public int Persona_Id { get; set; }
        public int Ciclo_Id { get; set; }

        [Display(Name = "N° Periodo")]
        public int Num_Periodo { get; set; }

        [MaxLength(50, ErrorMessage = "El Campo {0} debe de tener {1} de longitud")]
        [Required]
        [Display(Name = "Clave Materia")]
        public string  Clave_Materia { get; set; }

        [MaxLength(500, ErrorMessage = "El Campo {0} debe de tener {1} de longitud")]
        [Required]
        public string Materia { get; set; }

        [Display(Name = "Calificación")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Calificacion { get; set; }

        public int Faltas { get; set; }
                
    }
}
