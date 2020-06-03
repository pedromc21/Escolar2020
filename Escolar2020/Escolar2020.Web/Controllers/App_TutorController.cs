namespace Escolar2020.Web.Controllers
{
    using Data.Repositories;
    using Data.Entity.Personas;
    using Models;
    using Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Authorization;
    using System.Threading.Tasks;
    using System;
    using System.IO;

    public class App_TutorController : Controller
    {
        private readonly ITutorRepository tutorRepository;
        private readonly IUserHelper userHelper;

        public App_TutorController(ITutorRepository tutorRepository, IUserHelper userHelper)
        {
            this.tutorRepository = tutorRepository;
            this.userHelper = userHelper;
        }
        [Authorize]
        // GET: App_Tutor
        public IActionResult Index()
        {
            string clave_Familia = userHelper.GetUserByLoginAsync(User.Identity.Name).Result.Clave_Familia;
            var model = tutorRepository.GetPersonaAsync(clave_Familia);
            return View(model);
        }
        // GET: App_Tutor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("TutorNotFound");
            }
            var app_Tutor = await this.tutorRepository.GetPersonAsync(id.Value);
            if (app_Tutor == null)
            {
                return new NotFoundViewResult("TutorNotFound");
            }
            var view = this.ToApp_TutorViewModel(app_Tutor);
            return View(view);
        }
        private App_TutorViewModel ToApp_TutorViewModel(App_Tutor app_Tutor)
        {
            return new App_TutorViewModel
            {
                ImageUrlTutor= app_Tutor.ImageFullPath,
                Persona_Id = app_Tutor.Persona_Id,
                Clave_Familia = app_Tutor.Clave_Familia,
                NombreTutor = app_Tutor.Nombre,
                Parentesco = app_Tutor.Parentesco,
                Fecha_Nacimiento = app_Tutor.FechaNac,
                SexoTutor = app_Tutor.Sexo,
                Profesion = app_Tutor.Profesion,
                Nombre_Empresa = app_Tutor.Nombre_Empresa,
                Puesto_Empresa = app_Tutor.Puesto_Empresa,
                Telefono_Trabajo = app_Tutor.Telefono_Trabajo,
                TelefonoTutor = app_Tutor.Telefono,
                CelularTutor = app_Tutor.Celular,
                EMailTutor = app_Tutor.EMail,
                CURPTutor = app_Tutor.CURP
            };
        }      
        // GET: App_Tutor/Edit/5
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("TutorNotFound");
            }
            var app_Tutor = await this.tutorRepository.GetPersonAsync(id.Value);
            if (app_Tutor == null)
            {
                return new NotFoundViewResult("TutorNotFound");
            }
            var view = this.ToApp_TutorViewModel(app_Tutor);
            return View(view);
        }
        // POST: App_Tutor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(App_TutorViewModel view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var path = view.ImageUrl;
                    /*if (view.ImageFile != null && view.ImageFile.Length > 0)
                    {
                        var guid = Guid.NewGuid().ToString();
                        var file = $"{guid}.jpg";
                        path = Path.Combine(Directory.GetCurrentDirectory(),
                            "wwwroot\\images\\Tutors",
                            file); //view.ImageFile.FileName
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImageFile.CopyToAsync(stream);
                        }
                        path = $"~/images/Tutors/{file}";
                    }
                    view.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);*/
                    var app_Tutor = this.Toapp_Tutor(view, path); //
                    await this.tutorRepository.UpdateAsync(app_Tutor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.tutorRepository.ExistAsync(view.Persona_Id))
                    {
                        return new NotFoundViewResult("TutorNotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }
        private App_TutorViewModel ToApp_TutorsViewModel(App_Tutor app_Tutor)
        {
            return new App_TutorViewModel
            {
                //ImageUrl=path,
                Persona_Id = app_Tutor.Persona_Id,
                Clave_Familia = app_Tutor.Clave_Familia,
                /*Apellido_Paterno = app_Tutor.Apellido_Paterno,
                Apellido_Materno = app_Tutor.Apellido_Materno,
                Nombres = app_Tutor.Nombres,*/
                Parentesco = app_Tutor.Parentesco,
                /*Fecha_Nacimiento = app_Tutor.Fecha_Nacimiento,
                Sexo = app_Tutor.Sexo,*/
                Profesion = app_Tutor.Profesion,
                Nombre_Empresa = app_Tutor.Nombre_Empresa,
                Puesto_Empresa = app_Tutor.Puesto_Empresa,
                Telefono_Trabajo = app_Tutor.Telefono_Trabajo,
                /*Telefono = app_Tutor.Telefono,
                Celular = app_Tutor.Celular,
                EMail = app_Tutor.EMail,
                Usuario = app_Tutor.Usuario,
                Clave = app_Tutor.Clave,
                Email_Institucional = app_Tutor.Email_Institucional,
                Usuario_Institucional = app_Tutor.Usuario_Institucional,
                Clave_Institucional = app_Tutor.Clave_Institucional,
                User = app_Tutor.User */
            };
        }
        private App_Tutor Toapp_Tutor(App_TutorViewModel view, string path)
        {
            return new App_Tutor
            {
                //ImageUrl_tmp = path,
                Persona_Id = view.Persona_Id,
                Clave_Familia = view.Clave_Familia,
                Parentesco = view.Parentesco,
                Profesion = view.Profesion,
                Nombre_Empresa = view.Nombre_Empresa,
                Puesto_Empresa = view.Puesto_Empresa,
                Telefono_Trabajo = view.Telefono_Trabajo,
            };
        }
    }
}
