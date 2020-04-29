namespace Escolar2020.Web.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Tutor
    {
        public int Id { get; set; }
        public string Clave_Familia { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombres { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Sexo { get; set; }
        public string Profesion { get; set; }
        public string Nombre_Empresa { get; set; }
        public int Puesto_Empresa { get; set; }
        public string Telefono_Trabajo { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string EMail { get; set; }       
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Email_Institucional { get; set; }
        public string Usuario_Institucional { get; set; }
        public string Clave_Institucional { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
    }
}
