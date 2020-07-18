namespace Escolar2020.Common.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class Tutor
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("persona_Id")]
        public int PersonaId { get; set; }

        [JsonProperty("clave_Familia")]
        public string ClaveFamilia { get; set; }

        [JsonProperty("parentesco")]
        public string Parentesco { get; set; }

        [JsonProperty("profesion")]
        public string Profesion { get; set; }

        [JsonProperty("nombre_Empresa")]
        public string NombreEmpresa { get; set; }

        [JsonProperty("puesto_Empresa")]
        public string PuestoEmpresa { get; set; }

        [JsonProperty("telefono_Trabajo")]
        public string TelefonoTrabajo { get; set; }

        [JsonProperty("c_Person")]
        public CPerson CPerson { get; set; }
        
    }
}
