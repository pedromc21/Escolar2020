namespace Escolar2020.Web.Data.Repositories
{   
    using Entity.Personas;
    using Web.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public class TutorRepository : GenericRepository<App_Tutor>, ITutorRepository
    {
        private readonly DataContext context;

        public TutorRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<App_Tutor> GetPersonAsync(int id)
        {
            return await this.context.Set<App_Tutor>()
                .Include(o => o.c_Person)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Persona_Id == id);
        }        
        public IQueryable<App_Tutor> GetPersonaAsync(string clave_Familia)
        {
            return this.context.App_Tutors
                .Include(o => o.c_Person)
                .Where(w => w.Clave_Familia == clave_Familia)
                .OrderByDescending(o => o.Persona_Id);
        }
        public IQueryable GetAllWithUsers()
        {
            return this.context.App_Tutors.Include(p => p.c_Person);
        }
    }
}
