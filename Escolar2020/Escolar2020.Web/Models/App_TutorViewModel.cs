namespace Escolar2020.Web.Models
{
    using Data.Entity.Personas;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class App_TutorViewModel : App_Tutor 
    {
        [Display(Name = "Nombre")]
        public string NombreTutor { get;  set; }
        [Display(Name = "Fecha Nacimiento")]
        public DateTime? Fecha_Nacimiento { get;  set; }
        [Display(Name = "Sexo")]
        public string SexoTutor { get; set; }
        [Display(Name = "Telefono")]
        public string TelefonoTutor { get; set; }
        [Display(Name = "Celular")]
        public string CelularTutor { get; set; }
        [Display(Name = "EMail")]
        public string EMailTutor { get; set; }
        [Display(Name = "CURP")]
        public string CURPTutor { get; set; }       
        
        public string ImageFullPathTutor {get; }
        public string ImageUrlTutor { get; set; }

        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}
