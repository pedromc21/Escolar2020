namespace Escolar2020.Web.Data.Entity.Personas
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class App_Docente_Califica
    {
        public int Id { get; set; }
        //Docente_Id
        public int Persona_Id { get; set; }
        public int Curso_Id { get; set; }

        public int Plantel_Id { get; set; }
        [MaxLength(10)]
        [Display(Name = "Plantel")]
        public string Plantel { get; set; }

        public int Ciclo_Id { get; set; }
        [MaxLength(10)]
        [Display(Name = "Ciclo Escolar")]
        public string Ciclo_Escolar { get; set; }
        
        public int Grupo_Id { get; set; }
        [MaxLength(10)]
        [Display(Name = "Grupo")]
        public string Grupo { get; set; }

        [Display(Name = "N° Periodo")]
        public int Num_Periodo { get; set; }

        [MaxLength(50, ErrorMessage = "El Campo {0} debe de tener {1} de longitud")]
        [Required]
        [Display(Name = "Clave Materia")]
        public string Clave_Materia { get; set; }

        [MaxLength(500, ErrorMessage = "El Campo {0} debe de tener {1} de longitud")]
        [Required]
        public string Materia { get; set; }
        
        [Display(Name = "Fecha Inicio")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime? Fecha_Inicio { get; set; }

        [Display(Name = "Fecha Cierre")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime? Fecha_Fin { get; set; }

        public int Estatus { get; set; }

    }
}
