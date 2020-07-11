namespace Escolar2020.Common.Models
{
    using Newtonsoft.Json;
    using System;
    
    public partial class CPerson
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("persona_Id")]
        public long PersonaId { get; set; }

        [JsonProperty("tipoPersona_Id")]
        public long TipoPersonaId { get; set; }

        [JsonProperty("tipoPersona")]
        public string TipoPersona { get; set; }

        [JsonProperty("apellido_Paterno")]
        public string ApellidoPaterno { get; set; }

        [JsonProperty("apellido_Materno")]
        public string ApellidoMaterno { get; set; }

        [JsonProperty("nombres")]
        public string Nombres { get; set; }

        [JsonProperty("fecha_Nacimiento")]
        public DateTimeOffset FechaNacimiento { get; set; }

        [JsonProperty("sexo")]
        public string Sexo { get; set; }

        [JsonProperty("eMail")]
        public string EMail { get; set; }

        [JsonProperty("telefono")]
        public string Telefono { get; set; }

        [JsonProperty("celular")]
        public string Celular { get; set; }

        [JsonProperty("curp")]
        public string Curp { get; set; }

        [JsonProperty("usuario_App")]
        public string UsuarioApp { get; set; }

        [JsonProperty("pWd_App")]
        public string PWdApp { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("imageFullPath")]
        public object ImageFullPath { get; set; }

        [JsonProperty("user")]
        public object User { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }
    }
}
