namespace Escolar2020.Web.Data.Entity.Cursos
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class App_Cursos_Hora
    {

        [Required]
        public int Curso_Id { get; set; }

        [Required]
        public int Dia { get; set; }

        [Required]
        public string Turno { get; set; }

        [Required]
        public int Orden { get; set; }

        [Display(Name = "Hora Inicio")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan? Hora_Ini { get; set; }

        [Display(Name = "Hora Final")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan? Hora_Fin { get; set; }

        [MaxLength(50, ErrorMessage = "El Campo {0} debe de tener {1} de longitud")]
        public string Salon { get; set; }
    }
}
