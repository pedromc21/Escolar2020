namespace Escolar2020.Web.Data.Entity.Personas
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

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

        //Relacionar con Persona
        public IEnumerable<App_Persona> Personas { get; set; }
        public string Nombre { get { return Personas.First(c => c.Persona_Id == Persona_Id).FullName; } }
        public DateTime FechaNac { get { return Personas.First(c => c.Persona_Id == Persona_Id).Fecha_Nacimiento.Value; } }
        public string Sexo { get { return Personas.First(c => c.Persona_Id == Persona_Id).Sexo; } }
        public string Telefono { get { return Personas.First(c => c.Persona_Id == Persona_Id).Telefono; } }
        public string Celular { get { return Personas.First(c => c.Persona_Id == Persona_Id).Celular; } }
        public string EMail { get { return Personas.First(c => c.Persona_Id == Persona_Id).EMail; } }
        public string CURP { get { return Personas.First(c => c.Persona_Id == Persona_Id).CURP; } }
        public string ImageFullPath { get { return Personas.First(c => c.Persona_Id == Persona_Id).ImageFullPath; } }
        [Display(Name = "Imagen")]
        public string ImageUrl { get { return Personas.First(c => c.Persona_Id == Persona_Id).ImageUrl; } }
        
    }
}
