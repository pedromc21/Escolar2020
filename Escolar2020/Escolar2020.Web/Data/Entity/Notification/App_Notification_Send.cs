namespace Escolar2020.Web.Data.Entity.Notification
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class App_Notification_Send
    {
        //Relacion con App_Notification_Data
        [Key]
        public int Notification_Data_Id { get; set; }
        [Required]
        [Display(Name = "Fecha envio")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime Send_on { get; set; }
        public int status { get; set; }
    }
}
