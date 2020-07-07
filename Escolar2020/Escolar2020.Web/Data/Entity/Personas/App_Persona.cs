namespace Escolar2020.Web.Data.Entity.Personas 
{
    using Entity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.ComponentModel.DataAnnotations;
    public class App_Persona : IEntity
    {
        public int Id { get; set; }
        [Required]
        [HiddenInput(DisplayValue = false)]
        public int Persona_Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int TipoPersona_Id { get; set; }
        [MaxLength(50)]
        [Required]
        [Display(Name = "Tipo Persona")]
        public string TipoPersona { get; set; }

        [MaxLength(250)]
        [Required]
        [Display(Name = "Apellido Paterno")]
        public string Apellido_Paterno { get; set; }

        [MaxLength(250)]
        [Display(Name = "Apellido Materno")]
        public string Apellido_Materno { get; set; }

        [MaxLength(250)]
        [Required]
        public string Nombres { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime? Fecha_Nacimiento { get; set; }

        [MaxLength(10)]
        public string Sexo { get; set; }

        [MaxLength(150)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EMail { get; set; }

        [MaxLength(150)]
        public string Telefono { get; set; }

        [MaxLength(150)]
        public string Celular { get; set; }

        [MaxLength(100)]
        public string CURP { get; set; }

        [MaxLength(150)]
        [Display(Name = "Usuario")]
        public string Usuario_App { get; set; }

        [MaxLength(50)]
        [Display(Name = "Contraseña")]
        public string PWd_App { get; set; }

        [MaxLength(250)]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        //Fotografias
        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImageUrl))
                {
                    return null;
                }
                return $"http://www.gissa.com.mx{this.ImageUrl.Substring(1)}";
            }
        }

        //Relaciones
        public App_User User { get; set; }
        public string FullName { get { return $"{this.Apellido_Paterno} {this.Apellido_Materno} {Nombres}"; } }


    }
}
