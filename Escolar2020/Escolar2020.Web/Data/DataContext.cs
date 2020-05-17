namespace Escolar2020.Web.Data
{
    using Entity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class DataContext : IdentityDbContext<App_User>
    {
        //Incluir todos los modelos que se van a convertir en tablas en la DB
        public DbSet<App_Tutor> App_Tutors { get; set; }
        public DbSet<App_Alumno> App_Alumnos { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<App_Tutor>()
            .Property(p => p.Persona_Id)
            .HasColumnType("int"); //decimal(18,2)
            /*Al borrar registro no afecte en cascada*/
            var cascadeFKs = modelBuilder.Model
                .G­etEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
