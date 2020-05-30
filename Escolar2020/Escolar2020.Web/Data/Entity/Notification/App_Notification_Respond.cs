namespace Escolar2020.Web.Data.Entity.Notification
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class App_Notification_Respond
    {
        public int Id { get; set; }
        //Id Encabezado
        public int Id_Data { get; set; }
        [Required]
        public int Persona_Id_Respond { get; set; }
        [Required]
        public int Row_Respond { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime Fecha { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comentario { get; set; }
        public int Estatus { get; set; }
    }
}
