namespace Escolar2020.Web.Data.Entity.Personas
{
    using Microsoft.AspNetCore.Identity;
    public class App_User : IdentityUser
    {
        public int Persona_Id { get; set; }
        public string Clave_Familia { get; set; }
        public string Rol { get; set; }
    }
}
