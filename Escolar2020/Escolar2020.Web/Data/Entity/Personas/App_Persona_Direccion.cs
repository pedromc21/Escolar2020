namespace Escolar2020.Web.Data.Entity.Personas
{
    using System.ComponentModel.DataAnnotations;
    public class App_Persona_Direccion
    {
        public int Direccion_Id { get; set; }
        public int Persona_Id { get; set; }

        [MaxLength(10)]
        [Display(Name = "Codigo_Postal")]
        public string Codigo_Postal { get; set; }

        [Display(Name = "Asentamiento_Id")]
        public int Asentamiento_Id { get; set; }

        [MaxLength(250)]
        [Display(Name = "Colonia")]
        public string Colonia { get; set; }

        [MaxLength(500)]
        [Display(Name = "Calle")]
        public string Calle { get; set; }

        [MaxLength(50)]
        [Display(Name = "Numero Exterior")]
        public string Numero_Exterior { get; set; }

        [MaxLength(50)]
        [Display(Name = "Numero Interior")]
        public string Numero_Interior { get; set; }

        [MaxLength(500)]
        [Display(Name = "EntreCalles")]
        public string EntreCalles { get; set; }

        [Display(Name = "IdMunicipio")]
        public int IdMunicipio { get; set; }

        [MaxLength(500)]
        [Display(Name = "Municipio")]
        public string Municipio { get; set; }

        [Display(Name = "IdEstado")]
        public int IdEstado { get; set; }

        [MaxLength(500)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Display(Name = "IdPais")]
        public int IdPais { get; set; }

        [MaxLength(500)]
        [Display(Name = "Pais")]
        public string Pais { get; set; }

        [MaxLength(500)]
        [Display(Name = "Latitud")]
        public string v_Lat { get; set; }

        [MaxLength(500)]
        [Display(Name = "Longitud")]
        public string v_Lng { get; set; }

        public App_Persona Person { get; set; }
    }
}
