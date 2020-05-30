namespace Escolar2020.Web.Data
{
    using Entity.Personas;
    using System.Linq;
    public interface ITutorRepository : IGenericRepository<App_Tutor>
    {
        IQueryable GetAllWithUsers();
    }
}
