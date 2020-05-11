
namespace Escolar2020.Web.Data
{
    using Entity;
    using Helpers;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
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
            // Add user
            var user = await this.userHelper.GetUserByEmailAsync("pedromc219@gmail.com");
            if (user == null)
            {
                user = new App_User
                {
                    Persona_Id = 28071,
                    Clave_Familia = "GOR001",
                    Table = "Tutor",
                    Email = "pedromc219@gmail.com",
                    UserName = "pedromc219@gmail.com",
                    PhoneNumber = "2227657417"
                };
                var result = await this.userHelper.AddUserAsync(user, "M3N6BCYK");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            if (!this.context.App_Tutors.Any())
            {
                string sqlQuery = "EXEC [dbo].[App_DbRestore] ";
                context.Database.ExecuteSqlCommand(sqlQuery);
            }
        }
    }
}
