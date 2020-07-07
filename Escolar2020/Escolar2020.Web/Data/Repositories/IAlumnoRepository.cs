namespace Escolar2020.Web.Data.Repositories
{
    using Entity.Personas;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IAlumnoRepository : IGenericRepository<App_Alumno>
    {
        Task<App_Alumno> GetPersonAsync(int id);

        //Task<>
        IQueryable<App_Alumno> GetPersonaAsync(string clave_Familia);
        IQueryable GetAllWithUsers();
    }
}
