namespace Escolar2020.Web.Data.Entity.Personas 
{
    using Catalogos;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class App_Alumno : IEntity
    {
        public int Id { get; set; }

        [Required]
        public int Persona_Id { get; set; }
        [MaxLength(50, ErrorMessage = "El Campo {0} debe de tener {1} de longitud")]
        [Required]
        [Display(Name = "Clave Familia")]
        public string Clave_Familia { get; set; }

        [MaxLength(10)]
        [Required]
        public string Matricula { get; set; }

        [MaxLength(100)]
        public string NIA { get; set; }

        //Relacionar con Persona
        public IEnumerable<App_Persona> Person { get; set; }
        public string Nombre { get { return Person.First(c => c.Persona_Id == Persona_Id).FullName; } }
        public DateTime FechaNac { get { return Person.First(c => c.Persona_Id == Persona_Id).Fecha_Nacimiento.Value; } }
        public string Sexo { get { return Person.First(c => c.Persona_Id == Persona_Id).Sexo; } }
        public string Telefono { get { return Person.First(c => c.Persona_Id == Persona_Id).Telefono; } }
        public string Celular { get { return Person.First(c => c.Persona_Id == Persona_Id).Celular; } }
        public string EMail { get { return Person.First(c => c.Persona_Id == Persona_Id).EMail; } }
        public string CURP { get { return Person.First(c => c.Persona_Id == Persona_Id).CURP; } }
        public string ImageFullPath { get { return Person.First(c => c.Persona_Id == Persona_Id).ImageFullPath; } }
        [Display(Name = "Imagen")]
        public string ImageUrl { get { return Person.First(c => c.Persona_Id == Persona_Id).ImageUrl; } }

        public IEnumerable<App_Alumno_Grado> Alumno_Grado { get; set; }
        //public IEnumerable<App_c_CicloEsc> Alumno_Ciclo { get; set; }
        //public string Ciclo_Escolar { get { return Alumno_Grado.First(c => c.Persona_Id == Persona_Id).CicloEscolar; } }

    }
}
