
namespace Escolar2020.Web.Data
{
    using Entity.Personas;
    using Helpers;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;
    using System.Threading.Tasks;
    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;

        //private Random random;
        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            //this.random = new Random();
        }
        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();
            await this.userHelper.CheckRoleAsync("Admin");
            await this.userHelper.CheckRoleAsync("Alumno");
            await this.userHelper.CheckRoleAsync("Tutor");
            await this.userHelper.CheckRoleAsync("Docente");
            // Add user
            var personaList = context.App_Personas.Where(s => s.PWd_App == "123456").ToList();
            foreach (var personaItem in personaList)
            {
                var user = await this.userHelper.GetUserByLoginAsync(personaItem.Usuario_App);
                if (user == null)
                {
                    string emailValido = personaItem.EMail;
                    if (string.IsNullOrEmpty(emailValido))
                    {
                        emailValido = personaItem.Usuario_App;
                    }
                    string clavefamilia = "";
                    if (personaItem.TipoPersona != "Docente")
                    {
                        var alumnoList = context.App_Alumnos.Where(s => s.Persona_Id == personaItem.Persona_Id).ToList();
                        if (alumnoList.Count != 0)
                        {
                            foreach (var alumnoItem in alumnoList)
                            {
                                clavefamilia = alumnoItem.Clave_Familia;
                            }
                        }
                        else
                        {
                            var tutorList = context.App_Tutors.Where(s => s.Persona_Id == personaItem.Persona_Id).ToList();
                            if (tutorList.Count != 0)
                            {
                                foreach (var tutorItem in tutorList)
                                {
                                    clavefamilia = tutorItem.Clave_Familia;
                                }
                            }
                        }
                    }
                    user = new App_User
                    {       
                        Persona_Id = personaItem.Persona_Id,
                        Clave_Familia = clavefamilia,
                        Rol = personaItem.TipoPersona,
                        Email = emailValido,
                        UserName = personaItem.Usuario_App,
                        PhoneNumber = personaItem.Telefono
                        };
                        var result = await this.userHelper.AddUserAsync(user, personaItem.PWd_App);
                        if (result == IdentityResult.Success)
                        {
                            await this.userHelper.AddUserToRoleAsync(user, personaItem.TipoPersona);
                        //throw new InvalidOperationException("Could not create the user in seeder");
                        }
                }
                //string sqlQuery = "EXEC [dbo].[App_DbRestore] ";
                //context.Database.ExecuteSqlCommand(sqlQuery);
            }
        }
    }
}
