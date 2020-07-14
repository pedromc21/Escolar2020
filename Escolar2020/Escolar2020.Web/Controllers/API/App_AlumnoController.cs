
namespace Escolar2020.Web.Controllers.API
{
    using Data.Repositories;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[Controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class App_AlumnoController : Controller
    {
        private readonly IAlumnoRepository alumnoRepository;

        public App_AlumnoController(IAlumnoRepository alumnoRepository)
        {
            this.alumnoRepository = alumnoRepository;
        }

        [HttpGet]
        public IActionResult GetAlumnos(string clave_Familia)
        {
            //Regresa todos los datos del controlador Alumno, tengo que hacer que salga solo los tutores de la familia.
            return Ok(this.alumnoRepository.GetPersonaAsync(clave_Familia));
            //.OrderBy(p => p.Clave_Familia)
        }
    }
}