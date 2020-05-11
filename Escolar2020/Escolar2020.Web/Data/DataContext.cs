namespace Escolar2020.Web.Data
{
    using Entity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class DataContext : IdentityDbContext<App_User>
    {
        //Incluir todos los modelos que se van a convertir en tablas en la DB
        public DbSet<App_Tutor> App_Tutors { get; set; }
        public DbSet<App_Alumno> App_Alumnos { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
