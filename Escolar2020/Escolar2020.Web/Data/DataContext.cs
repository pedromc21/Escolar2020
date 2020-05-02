namespace Escolar2020.Web.Data
{
    using Escolar2020.Web.Data.Entity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class DataContext : IdentityDbContext<App_User>
    {
        public DbSet<App_Tutor> App_Tutors { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
