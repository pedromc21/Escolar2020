
namespace Escolar2020.Web.Data.Repositories
{
    using Entity.Personas;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public class AlumnoRepository : GenericRepository<App_Alumno>, IAlumnoRepository
    {
        private readonly DataContext context;

        public AlumnoRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<App_Alumno> GetPersonAsync(int id)
        {
            return await this.context.Set<App_Alumno>()
                .Include(o => o.Person)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Persona_Id == id);
        }
        public IQueryable<App_Alumno> GetPersonaAsync(string clave_Familia)
        {
            return this.context.App_Alumnos
            .Include(a => a.Alumno_Grado)
            .ThenInclude(c => c.CicloEsc)
            .Include(p => p.Person)
            .Where(w => w.Clave_Familia == clave_Familia)
            .OrderByDescending(o => o.Persona_Id);
        }
        public IQueryable GetAllWithUsers()
        {
            return this.context.App_Alumnos.Include(p => p.Clave_Familia);
        }
        
    }
}
