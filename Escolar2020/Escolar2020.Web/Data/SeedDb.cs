
namespace Escolar2020.Web.Data
{
    using Escolar2020.Web.Data.Entity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    public class SeedDb
    {
        private readonly DataContext context;
        private readonly UserManager<App_User> userManager;

        //private Random random;
        public SeedDb(DataContext context, UserManager<App_User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
            //this.random = new Random();
        }
        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();
            if (!this.context.App_Tutors.Any())
            {
                string sqlQuery = "EXEC [dbo].[App_DbRestore] ";
                context.Database.ExecuteSqlCommand(sqlQuery);
            }
        }
    }
}
