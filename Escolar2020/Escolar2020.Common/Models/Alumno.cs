namespace Escolar2020.Common.Models
{
    using Newtonsoft.Json;
    using System;
    public partial class Alumno
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("persona_Id")]
        public long PersonaId { get; set; }

        [JsonProperty("clave_Familia")]
        public string ClaveFamilia { get; set; }

        [JsonProperty("matricula")]
        public string Matricula { get; set; }

        [JsonProperty("nia")]
        public string Nia { get; set; }

        [JsonProperty("plantel_Id")]
        public long PlantelId { get; set; }

        [JsonProperty("plantel")]
        public string Plantel { get; set; }

        [JsonProperty("ciclo_Id")]
        public long CicloId { get; set; }

        [JsonProperty("ciclo_Escolar")]
        public string CicloEscolar { get; set; }

        [JsonProperty("seccion_Id")]
        public long SeccionId { get; set; }

        [JsonProperty("seccion")]
        public string Seccion { get; set; }

        [JsonProperty("grado_Id")]
        public long GradoId { get; set; }

        [JsonProperty("grado")]
        public string Grado { get; set; }

        [JsonProperty("status_Id")]
        public long StatusId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

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
        public object ImageFullPath { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
    }
}
