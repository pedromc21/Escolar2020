namespace Escolar2020.Web.Data.Entity.Personas
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class App_Tutor : IEntity
    {
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int Persona_Id { get; set; }

        [MaxLength(50, ErrorMessage = "El Campo {0} debe de tener {1} de longitud")]
        [Required]
        [Display(Name = "Clave Familia")]
        public string Clave_Familia { get; set; }

        [MaxLength(100)]
        [Required]
        public string Parentesco { get; set; }

        [MaxLength(250)]
        public string Profesion { get; set; }

        [MaxLength(250)]
        [Display(Name = "Empresa")]
        public string Nombre_Empresa { get; set; }

        [MaxLength(250)]
        [Display(Name = "Puesto")]
        public string Puesto_Empresa { get; set; }

        [MaxLength(150)]
        [Display(Name = "Telefono Trabajo")]
        public string Telefono_Trabajo { get; set; }

        //public string ImageUrl_tmp { get; set; }
        public App_Persona c_Person { get; set; }
        //Relacionar con Persona
        public virtual string Nombre { get { return c_Person.FullName; } }
        public virtual DateTime? FechaNac { get { return c_Person.Fecha_Nacimiento; } }
        public virtual string Sexo { get { return c_Person.Sexo; } }
        public virtual string Telefono { get { return c_Person.Telefono; } }
        public virtual string Celular { get { return c_Person.Celular; } }
        public virtual string EMail { get { return c_Person.EMail; } }
        public virtual string CURP { get { return c_Person.CURP; } }
        public virtual string ImageFullPath { get { return c_Person.ImageFullPath; } }
        [Display(Name = "Imagen")]
        public virtual string ImageUrl { get { return c_Person.ImageUrl; } }
    }
}
