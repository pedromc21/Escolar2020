namespace Escolar2020.Web.Controllers
{
    using Data;
    using Data.Entity.Personas;
    using Models;
    using Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Authorization;
    using System.IO;
    using System.Threading.Tasks;
    using System.Linq;
    using System;
    
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
            return View(this.tutorRepository.GetAll().OrderBy(p => p.Clave_Familia));
        }

        // GET: App_Tutor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("TutorNotFound");
            }

            var app_Tutor = await this.tutorRepository.GetByIdAsync(id.Value);
            if (app_Tutor == null)
            {
                return new NotFoundViewResult("TutorNotFound");
            }
            var view = this.ToApp_TutorViewModel(app_Tutor);
            return View(view);
            //return View(app_Tutor);
        }
        
        // GET: App_Tutor/Create
        //[Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: App_Tutor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(App_TutorViewModel view)
        {
            if (ModelState.IsValid)
            {
                /*var path = string.Empty;
                if (view.ImageFile != null && view.ImageFile.Length > 0)
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
                }*/
                var app_Tutor = this.Toapp_Tutor(view); //, path
                //app_Tutor.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                await this.tutorRepository.CreateAsync(app_Tutor);
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }
        private App_Tutor Toapp_Tutor(App_TutorViewModel view) //, string path
        {
            return new App_Tutor
            {
                //ImageUrl=path,
                Persona_Id = view.Persona_Id,
                Clave_Familia = view.Clave_Familia,
                /*Apellido_Paterno = view.Apellido_Paterno,
                Apellido_Materno = view.Apellido_Materno,
                Nombres = view.Nombres,*/
                Parentesco = view.Parentesco,
                /*Fecha_Nacimiento = view.Fecha_Nacimiento,
                Sexo = view.Sexo,*/
                Profesion = view.Profesion,
                Nombre_Empresa = view.Nombre_Empresa,
                Puesto_Empresa = view.Puesto_Empresa,
                Telefono_Trabajo = view.Telefono_Trabajo,
                /*Telefono = view.Telefono,
                Celular = view.Celular,
                EMail = view.EMail,
                Usuario = view.Usuario,
                Clave = view.Clave,
                Email_Institucional = view.Email_Institucional,
                Usuario_Institucional = view.Usuario_Institucional,
                Clave_Institucional = view.Clave_Institucional,
                User = view.User */
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

            var app_Tutor = await this.tutorRepository.GetByIdAsync(id.Value);
            if (app_Tutor == null)
            {
                return new NotFoundViewResult("TutorNotFound");
            }
            var view = this.ToApp_TutorViewModel(app_Tutor);
            //view.User = await this.userHelper.GetUserByEmailAsync("pedromc219@gmail.com");
            return View(view);
            //return View(app_Tutor);
        }

        private App_TutorViewModel ToApp_TutorViewModel(App_Tutor app_Tutor)
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
                    /*var path = view.ImageUrl;
                    if (view.ImageFile != null && view.ImageFile.Length > 0)
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
                    var app_Tutor = this.Toapp_Tutor(view); //, path
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

        // GET: App_Tutor/Delete/5
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("TutorNotFound");
            }

            var app_Tutor = await this.tutorRepository.GetByIdAsync(id.Value);
            if (app_Tutor == null)
            {
                return new NotFoundViewResult("TutorNotFound");
            }
            var view = this.ToApp_TutorViewModel(app_Tutor);
            return View(view);
            //return View(app_Tutor);
        }

        // POST: App_Tutor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var app_Tutor = await this.tutorRepository.GetByIdAsync(id);
            await this.tutorRepository.DeleteAsync(app_Tutor);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult TutorNotFound()
        {
            return this.View();
        }

    }
}
