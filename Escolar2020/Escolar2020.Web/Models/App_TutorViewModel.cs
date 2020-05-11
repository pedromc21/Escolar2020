namespace Escolar2020.Web.Models
{
    using Escolar2020.Web.Data.Entity;
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class App_TutorViewModel : App_Tutor
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}
