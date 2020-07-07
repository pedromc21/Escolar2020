

namespace Escolar2020.Web.Controllers
{
    using Data.Repositories;
    using Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    public class App_AlumnoController : Controller
    {
        private readonly IAlumnoRepository alumnoRepository;
        private readonly IUserHelper userHelper;
        public App_AlumnoController(IAlumnoRepository alumnoRepository, IUserHelper userHelper)
        {
            this.alumnoRepository = alumnoRepository;
            this.userHelper = userHelper;
        }
        [Authorize]
        // GET: App_Alumno
        public IActionResult Index()
        {
            //var idciclo = Context.Session.GetString("");
            string clave_Familia = userHelper.GetUserByLoginAsync(User.Identity.Name).Result.Clave_Familia;
            var model = alumnoRepository.GetPersonaAsync(clave_Familia);
            return View(model);
        }
    }
}