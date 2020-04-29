namespace Escolar2020.Web.Data
{
    using Microsoft.EntityFrameworkCore;
    public class DataContext :DbContext
    {
        public DbSet<Tutor> Tutors { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
