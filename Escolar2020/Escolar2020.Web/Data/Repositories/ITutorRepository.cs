namespace Escolar2020.Web.Data.Repositories
{
    using Entity.Personas;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ITutorRepository : IGenericRepository<App_Tutor>
    {
        Task<App_Tutor> GetPersonAsync(int id);
        
        //Task<>
        IQueryable<App_Tutor> GetPersonaAsync(string clave_Familia);
        IQueryable GetAllWithUsers();
    }
}
