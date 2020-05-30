namespace Escolar2020.Web.Data
{   
    using Entity.Personas;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class TutorRepository : GenericRepository<App_Tutor>, ITutorRepository
    {
        private readonly DataContext context;

        public TutorRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return this.context.App_Tutors.Include(p => p.Clave_Familia); 
        }
    }
}
