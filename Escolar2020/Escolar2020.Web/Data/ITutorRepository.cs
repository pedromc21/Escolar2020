namespace Escolar2020.Web.Data
{
    using Entity;
    using System.Linq;

    public interface ITutorRepository : IGenericRepository<App_Tutor>
    {
        IQueryable GetAllWithUsers();
    }
}
