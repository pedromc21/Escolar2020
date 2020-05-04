namespace Escolar2020.Web.Data
{
    using Escolar2020.Web.Data.Entity;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class App_Tutor : IEntity
    {
        public int Id { get; set; }

        public int Persona_Id { get; set; }

        [MaxLength(50, ErrorMessage = "El Campo {0} debe de tener {1} de longitud")]
        [Required]
        [Display(Name = "Clave Familia")]
        public string Clave_Familia { get; set; }

        [MaxLength(250)]
        [Display(Name = "Apellido Paterno")]
        public string Apellido_Paterno { get; set; }

        [MaxLength(250)]
        [Display(Name = "Apellido Materno")]
        public string Apellido_Materno { get; set; }

        [MaxLength(250)]
        [Required]
        public string Nombres { get; set; }

        [MaxLength(100)]
        [Required]
        public string Parentesco { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        public DateTime? Fecha_Nacimiento { get; set; }

        [MaxLength(10)]
        public string Sexo { get; set; }

        [MaxLength(250)]
        public string Profesion { get; set; }

        [MaxLength(250)]
        [Display(Name = "Empresa")]
        public string Nombre_Empresa { get; set; }

        [MaxLength(250)]
        [Display(Name = "Puesto")]
        public int Puesto_Empresa { get; set; }

        [MaxLength(150)]
        [Display(Name = "Telefono Trabajo")]
        public string Telefono_Trabajo { get; set; }

        [MaxLength(150)]
        public string Telefono { get; set; }

        [MaxLength(150)]
        public string Celular { get; set; }

        [MaxLength(150)]
        public string EMail { get; set; }

        [MaxLength(50)]
        public string Usuario { get; set; }

        [MaxLength(50)]
        public string Clave { get; set; }

        [MaxLength(250)]
        [Display(Name = "Email Institucional")]
        public string Email_Institucional { get; set; }

        [MaxLength(150)]
        [Display(Name = "Usuario Institucional")]
        public string Usuario_Institucional { get; set; }

        [MaxLength(50)]
        [Display(Name = "Contraseña Institucional")]
        public string Clave_Institucional { get; set; }

        [MaxLength(250)]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        public App_User User { get; set; }
    }
}
