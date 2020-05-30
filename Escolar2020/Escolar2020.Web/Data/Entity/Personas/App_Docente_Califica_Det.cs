namespace Escolar2020.Web.Data.Entity.Personas
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class App_Docente_Califica_Det
    {
        //Id Encabezado
        public int Id { get; set; }
        //Alumno_Id
        public int Persona_Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Calificacion { get; set; }

        [Display(Name = "Fecha Calificación")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime? Fecha { get; set; }

        [DataType(DataType.MultilineText)]
        public string Observacion { get; set; }
    }
}
