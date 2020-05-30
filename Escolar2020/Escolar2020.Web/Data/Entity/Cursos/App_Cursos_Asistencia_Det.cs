namespace Escolar2020.Web.Data.Entity.Cursos
{
    using System.ComponentModel.DataAnnotations;
    public class App_Cursos_Asistencia_Det
    {
        //Id Encabezado
        [Required]
        public int Asistencia_Id { get; set; }
        //Alumno_Id
        [Required]
        public int Persona_Id { get; set; }

        [Required]
        public bool Asistio { get; set; }

        [Display(Name = "Falta Justificada")]
        public bool Falta_Justificada { get; set; }

        [DataType(DataType.MultilineText)]
        public string Observacion { get; set; }
    }
}
