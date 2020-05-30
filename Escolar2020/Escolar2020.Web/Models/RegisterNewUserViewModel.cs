namespace Escolar2020.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    public class RegisterNewUserViewModel
    {
        [Required]
        [Display(Name = "Persona_Id")]
        public int Persona_Id { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public string Rol { get; set; }

        [Required]
        [Display(Name = "Clave Familia")]
        public string Clave_Familia { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string Confirm { get; set; }
    }
}
