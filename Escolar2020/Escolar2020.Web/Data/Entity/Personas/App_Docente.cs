namespace Escolar2020.Web.Data.Entity.Personas
{
    using Entity;
    using System.ComponentModel.DataAnnotations;
    public class App_Docente : IEntity
    {
        public int Id { get; set; }
        public int Persona_Id { get; set; }

        [MaxLength(50)]
        [Display(Name = "Clave")]
        public string Clave { get; set; }
        //Relacionar con Persona
    }
}
