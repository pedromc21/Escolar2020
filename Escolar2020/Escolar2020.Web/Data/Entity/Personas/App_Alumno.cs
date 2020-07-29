namespace Escolar2020.Web.Data.Entity.Personas 
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
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

        public int Plantel_Id { get; set; }
        [MaxLength(100)]
        [Display(Name = "Plantel")]
        public string Plantel { get; set; }

        public int Ciclo_Id { get; set; }
        [MaxLength(100)]
        [Display(Name = "Ciclo Escolar")]
        public string Ciclo_Escolar { get; set; }

        public int Seccion_Id { get; set; }
        [MaxLength(100)]
        [Display(Name = "Seccion")]
        public string Seccion { get; set; }

        public int Grado_Id { get; set; }
        [MaxLength(100)]
        [Display(Name = "Grado")]
        public string Grado { get; set; }

        public int Status_Id { get; set; }
        [MaxLength(100)]
        [Display(Name = "Status")]
        public string Status { get; set; }

        public string ImageUrl { get; set; }
        //Relacionar con Persona
        public App_Persona c_Person { get; set; }
        
    }
}
