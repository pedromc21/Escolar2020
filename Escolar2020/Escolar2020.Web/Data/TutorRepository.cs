namespace Escolar2020.Web.Data
{
    using Entity;
    public class TutorRepository : GenericRepository<App_Tutor>, ITutorRepository
    {
        public TutorRepository(DataContext context) : base(context)
        {
        }
    }
}
