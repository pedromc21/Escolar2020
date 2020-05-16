namespace Escolar2020.Common.Models
{
    using Newtonsoft.Json;
    using System;
    public partial class Tutor
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("persona_Id")]
        public long PersonaId { get; set; }

        [JsonProperty("clave_Familia")]
        public string ClaveFamilia { get; set; }

        [JsonProperty("apellido_Paterno")]
        public string ApellidoPaterno { get; set; }

        [JsonProperty("apellido_Materno")]
        public string ApellidoMaterno { get; set; }

        [JsonProperty("nombres")]
        public string Nombres { get; set; }

        [JsonProperty("parentesco")]
        public string Parentesco { get; set; }

        [JsonProperty("fecha_Nacimiento")]
        public DateTimeOffset FechaNacimiento { get; set; }

        [JsonProperty("sexo")]
        public string Sexo { get; set; }

        [JsonProperty("profesion")]
        public string Profesion { get; set; }

        [JsonProperty("nombre_Empresa")]
        public string NombreEmpresa { get; set; }

        [JsonProperty("puesto_Empresa")]
        public string PuestoEmpresa { get; set; }

        [JsonProperty("telefono_Trabajo")]
        public string TelefonoTrabajo { get; set; }

        [JsonProperty("telefono")]
        public string Telefono { get; set; }

        [JsonProperty("celular")]
        public string Celular { get; set; }

        [JsonProperty("eMail")]
        public string EMail { get; set; }

        [JsonProperty("usuario")]
        public string Usuario { get; set; }

        [JsonProperty("clave")]
        public string Clave { get; set; }

        [JsonProperty("email_Institucional")]
        public string EmailInstitucional { get; set; }

        [JsonProperty("usuario_Institucional")]
        public string UsuarioInstitucional { get; set; }

        [JsonProperty("clave_Institucional")]
        public string ClaveInstitucional { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("imageFullPath")]
        public Uri ImageFullPath { get; set; }
        public override string ToString()
        {
            return $"{this.ClaveFamilia} {this.ApellidoPaterno} {this.ApellidoMaterno} {this.Nombres}"; 
        }
    }
}
