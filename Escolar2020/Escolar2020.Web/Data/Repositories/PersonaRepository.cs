namespace Escolar2020.Web.Data.Repositories
{
    using Entity.Personas;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    public class PersonaRepository : GenericRepository<App_Persona>, IPersonaRepository
    {
        private readonly DataContext context;
        public PersonaRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<App_Persona> GetPersonAsync(int id)
        {
            return await this.context.Set<App_Persona>()
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Persona_Id == id);
        }
        public IQueryable GetAllWithUsers()
        {
            return this.context.App_Personas.Include(p => p.Persona_Id);
        }

        public IQueryable<App_Persona> GetPersonaAsync(int persona_id)
        {
            return this.context.App_Personas
               .Where(w => w.Persona_Id == persona_id)
               .OrderByDescending(o => o.Persona_Id);
        }        
    }
}
