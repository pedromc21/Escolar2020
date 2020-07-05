namespace Escolar2020.Web.Data.Repositories
{
    using Entity.Personas;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IPersonaRepository : IGenericRepository<App_Persona>
    {
        Task<App_Persona> GetPersonAsync(int id);
        //Task<>
        IQueryable<App_Persona> GetPersonaAsync(int persona_id);
        IQueryable GetAllWithUsers();
    }
}
