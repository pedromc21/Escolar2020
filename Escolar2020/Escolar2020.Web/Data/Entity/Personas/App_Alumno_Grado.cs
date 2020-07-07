namespace Escolar2020.Web.Data.Entity.Personas 
{
    using Catalogos;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class App_Alumno_Grado 
    {
        [Key]
        public int Ciclo_Id { get; set; }
        [Required]
        public int Persona_Id { get; set; }
        [Required]
        public int Grupo_Id { get; set; }
        public int Plantel_Id { get; set; }
        public int Seccion_Id { get; set; }
        public int Grado_Id { get; set; }
        public int Status_Id { get; set; }
        //Relaciones con Alummo, Periodo, Planteles, Seccion, Grdo, Grupo, Status
        public ICollection<App_c_CicloEsc> CicloEsc { get; set; }
        public ICollection<App_Persona> PersonAG { get; set; }
        public ICollection<App_c_Grupo> Grupo { get; set; }
        public ICollection<App_c_Plantel> Plantel { get; set; }
        public ICollection<App_c_Seccion> Seccion { get; set; }
        public ICollection<App_c_Grado> Grado { get; set; }
        public ICollection<App_c_Status> Status { get; set; }
        //public IEnumerable<App_c_CicloEsc> CicloEsc { get; set; }
        public string CicloEscolar { get { return CicloEsc.First(c => c.Ciclo_Id == Ciclo_Id).Ciclo_Escolar; } }

    }
}
