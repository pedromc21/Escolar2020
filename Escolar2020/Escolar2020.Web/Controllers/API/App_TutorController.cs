namespace Escolar2020.Web.Controllers.API
{
    using Data.Repositories;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    [Route("api/[Controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            return Ok(this.tutorRepository.GetAllWithUsers());
            //.OrderBy(p => p.Clave_Familia)
        }

    }
}
