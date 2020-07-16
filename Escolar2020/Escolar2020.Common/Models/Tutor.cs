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

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("fechaNac")]
        public DateTimeOffset FechaNac { get; set; }

        [JsonProperty("sexo")]
        public string Sexo { get; set; }

        [JsonProperty("telefono")]
        public string Telefono { get; set; }

        [JsonProperty("celular")]
        public string Celular { get; set; }

        [JsonProperty("eMail")]
        public string EMail { get; set; }

        [JsonProperty("curp")]
        public string Curp { get; set; }

        [JsonProperty("imageFullPath")]
        public string ImageFullPath { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
        public override string ToString()
        {
            return $"{this.ClaveFamilia} {CPerson.ApellidoPaterno} {CPerson.ApellidoMaterno} {CPerson.Nombres}"; 
        }
        public string Name
        {
            get
            {
                return $" {CPerson.ApellidoPaterno} {CPerson.ApellidoMaterno} {CPerson.Nombres}";
            }
        }
    }
}
