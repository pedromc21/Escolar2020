namespace Escolar2020.Web.Data.Entity.Cursos
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class App_Cursos_Asistencia : IEntity
    {
        public int Id { get; set; }

        [Required]
        public int Curso_Id { get; set; }
       
        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime? Fecha_Inicio { get; set; }

        [Display(Name = "Hora Inicio")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan? Hora_Ini { get; set; }

        [Display(Name = "Hora Final")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan? Hora_Fin { get; set; }

    }
}
