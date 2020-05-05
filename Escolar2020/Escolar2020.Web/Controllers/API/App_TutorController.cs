namespace Escolar2020.Web.Controllers.API
{
    using Escolar2020.Web.Data;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[Controller]")]
    public class App_TutorController : Controller
    {
        private readonly ITutorRepository tutorRepository;

        public App_TutorController(ITutorRepository tutorRepository)
        {
            this.tutorRepository = tutorRepository;
        }
        
        [HttpGet]
        public IActionResult GetTutors()
        {
            //Regresa todos los datos del controlador Tutor, tengo que hacer que salga solo los tutores de la familia.
            return Ok(this.tutorRepository.GetAll());
        }

    }
}
