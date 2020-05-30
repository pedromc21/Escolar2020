namespace Escolar2020.Web.Data.Entity.Notification
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class App_Notification_HomeWork_Evaluation
    {
        //Id Encabezado Respuesta Home Work
        [Key]
        public int Id_HomeWork { get; set; }
        [Required]
        [Display(Name = "Fecha calificación")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime Fecha { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Calificacion { get; set; }

        public string Calificacion_Letra { get; set; }

        [DataType(DataType.MultilineText)]
        public string Observacion { get; set; }
    }
}
