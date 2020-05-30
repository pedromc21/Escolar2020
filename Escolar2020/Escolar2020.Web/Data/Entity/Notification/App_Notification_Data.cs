namespace Escolar2020.Web.Data.Entity.Notification
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class App_Notification_Data : IEntity
    {
        //Cuerpo y datos de la Notificación
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El Campo {0} debe de tener Maximo {1} de longitud")]
        [Required]
        [Display(Name = "Nombre de la Notificación")]
        public string Name { get; set; }
        [Required]
        public int Persona_Id_Create { get; set; }
        [Required]
        //Catalogo de Acciones de la Notificacion: 1) Borrador 2)Send  3)Vencida
        public int Action_Id { get; set; }
        //LLave Relación con App_Notification_Recipient, Grupos quienes pueden ver la Notificación
        [Required]
        public int Recipient_Id { get; set; }
        //Enviar Mensage SMS
        public bool Send_Message { get; set; }
        //Enviar Mensage Email
        public bool Send_Email { get; set; }

        [MaxLength(100, ErrorMessage = "El Campo {0} debe de tener Maximo {1} de longitud")]
        [Required]
        [Display(Name = "Titulo")]
        public string Title { get; set; }

        [MaxLength(500, ErrorMessage = "El Campo {0} debe de tener Maximo {1} de longitud")]
        [Required]
        [Display(Name = "Cuerpo")]
        public string Body { get; set; }
        //Publicar un link 
        [Display(Name = "Url, complementa la notificación")]
        public string url { get; set; }
        //Convierte la Notificación en Tarea
        [Display(Name = "Es una tarea")]
        public bool IsHomeWork { get; set; }
        //La notificación puede ser evaluada (Puede tener Comentarios)
        [Display(Name = "Permite comentarios")]
        public bool IsEvaluated { get; set; }
        //La los Comentarios solo los ve el publicador)
        [Display(Name = "Solo yo veo los comentarios")]
        public bool IsPrivate { get; set; }
        //Fecha Creacion
        [Required]
        [Display(Name = "Fecha creacion")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime created_on { get; set; }
        
    }
}
