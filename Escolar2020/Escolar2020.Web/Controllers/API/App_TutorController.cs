namespace Escolar2020.Web.Controllers.API
{
    using Data.Repositories;
    using Escolar2020.Web.Helpers;
	using Escolar2020.Web.Data.Entity.Personas;
	using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[Controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class App_TutorController : Controller
    {
        private readonly ITutorRepository tutorRepository;
		private readonly IUserHelper userHelper;

		public App_TutorController(
			ITutorRepository tutorRepository, 
			IUserHelper userHelper)
        {
            this.tutorRepository = tutorRepository;
			this.userHelper = userHelper;
		}

        [HttpGet]
        public IActionResult GetTutors(string clave_Familia)
        {
            //Regresa todos los datos del controlador Tutor, tengo que hacer que salga solo los tutores de la familia.
            return Ok(tutorRepository.GetPersonaAsync(clave_Familia));
            //.OrderBy(p => p.Clave_Familia)
        }

		[HttpPost]
		public async Task<IActionResult> PostTutor([FromBody] Common.Models.Tutor Tutor)
		{
			if (!ModelState.IsValid)
			{
				return this.BadRequest(ModelState);
			}

			var user = await this.userHelper.GetUserByLoginAsync(Tutor.CPerson.UsuarioApp);
			if (user == null)
			{
				return this.BadRequest("Invalid user");
			}

			//TODO: Upload images
			var entityTutor = new App_Tutor
			{
				Persona_Id = Tutor.PersonaId,
				Clave_Familia = Tutor.ClaveFamilia,
				Parentesco = Tutor.Parentesco,
				Profesion = Tutor.Profesion,
				Nombre_Empresa = Tutor.NombreEmpresa,
				Puesto_Empresa = Tutor.PuestoEmpresa,
				Telefono_Trabajo = Tutor.TelefonoTrabajo
			};

			var newTutor = await this.tutorRepository.CreateAsync(entityTutor);
			return Ok(newTutor);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutTutor([FromRoute] int id, [FromBody] Common.Models.Tutor Tutor)
		{
			if (!ModelState.IsValid)
			{
				return this.BadRequest(ModelState);
			}

			if (id != Tutor.Id)
			{
				return BadRequest();
			}

			var oldTutor = await this.tutorRepository.GetByIdAsync(id);
			if (oldTutor == null)
			{
				return this.BadRequest("Tutor Id don't exists.");
			}

			//TODO: Upload images
			oldTutor.Persona_Id = Tutor.PersonaId;
			oldTutor.Clave_Familia = Tutor.ClaveFamilia;
			oldTutor.Parentesco = Tutor.Parentesco;
			oldTutor.Profesion = Tutor.Profesion;
			oldTutor.Nombre_Empresa = Tutor.NombreEmpresa;
			oldTutor.Puesto_Empresa = Tutor.PuestoEmpresa;
			oldTutor.Telefono_Trabajo = Tutor.TelefonoTrabajo;
			//oldTutor.IsAvailabe = Tutor.IsAvailabe;
			//oldTutor.LastPurchase = Tutor.LastPurchase;
			//oldTutor.LastSale = Tutor.LastSale;
			//oldTutor.Name = Tutor.Name;
			//oldTutor.Price = Tutor.Price;
			//oldTutor.Stock = Tutor.Stock;

			var updatedTutor = await this.tutorRepository.UpdateAsync(oldTutor);
			return Ok(updatedTutor);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTutor([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return this.BadRequest(ModelState);
			}

			var Tutor = await this.tutorRepository.GetByIdAsync(id);
			if (Tutor == null)
			{
				return this.NotFound();
			}

			await this.tutorRepository.DeleteAsync(Tutor);
			return Ok(Tutor);
		}
	}
}
