namespace Escolar2020.Web.Data
{
    using Escolar2020.Web.Data.Entity;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class App_Alumno
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

        [Display(Name = "Fecha Nacimiento")]
        public DateTime Fecha_Nacimiento { get; set; }

        [MaxLength(10)]
        public string Sexo { get; set; }

        [MaxLength(150)]
        public string EMail { get; set; }
        
        public int Periodo_Id { get; set; }
        [MaxLength(150)]
        public string Ciclo_Escolar { get; set; }

        [MaxLength(50, ErrorMessage = "El Campo {0} debe de tener {1} de longitud")]
        [Required]
        public string Matricula { get; set; }
        
        [MaxLength(100)]
        public string Seccion { get; set; }
        
        [MaxLength(100)]
        public string Grado { get; set; }
        
        [MaxLength(100)]
        public string Grupo { get; set; }
        
        [MaxLength(100)]
        public string Status { get; set; }

        [MaxLength(100)]
        public string CURP { get; set; }

        [MaxLength(100)]
        public string NIA { get; set; }

        [MaxLength(150)]
        [Display(Name = "Usuario")]
        public string Usuario_App { get; set; }

        [MaxLength(50)]
        [Display(Name = "Contraseña")]
        public string PWd_App { get; set; }

        [MaxLength(250)]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        public int OrdenSeccion { get; set; }

        public App_User User { get; set; }
    }
}
