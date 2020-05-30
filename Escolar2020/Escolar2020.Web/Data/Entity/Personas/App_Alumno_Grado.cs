namespace Escolar2020.Web.Data.Entity.Personas 
{
    public class App_Alumno_Grado 
    {
        public int Ciclo_Id { get; set; }
        public int Persona_Id { get; set; }
        public int Grupo_Id { get; set; }
        public int Plantel_Id { get; set; }
        public int Seccion_Id { get; set; }
        public int Grado_Id { get; set; }
        public int Status_Id { get; set; }
        //Relaciones con Alummo, Periodo, Planteles, Seccion, Grdo, Grupo, Status        
    }
}
