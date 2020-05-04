namespace Escolar2020.Web.Controllers
{
    using System.Threading.Tasks;
    using Data;
    using Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    public class App_TutorController : Controller
    {
        private readonly ITutorRepository tutorRepository;
        private readonly IUserHelper userHelper;

        public App_TutorController(ITutorRepository tutorRepository, IUserHelper userHelper)
        {
            this.tutorRepository = tutorRepository;
            this.userHelper = userHelper;
        }

        // GET: App_Tutor
        public IActionResult Index()
        {
            return View(this.tutorRepository.GetAll());
        }

        // GET: App_Tutor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var app_Tutor = await this.tutorRepository.GetByIdAsync(id.Value);
            if (app_Tutor == null)
            {
                return NotFound();
            }

            return View(app_Tutor);
        }

        // GET: App_Tutor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: App_Tutor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(App_Tutor app_Tutor)
        {
            if (ModelState.IsValid)
            {
                app_Tutor.User = await this.userHelper.GetUserByEmailAsync("pedromc219@gmail.com");
                await this.tutorRepository.CreateAsync(app_Tutor);
                return RedirectToAction(nameof(Index));
            }
            return View(app_Tutor);
        }

        // GET: App_Tutor/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var app_Tutor = this.tutorRepository.GetByIdAsync(id.Value);
            if (app_Tutor == null)
            {
                return NotFound();
            }
            return View(app_Tutor);
        }

        // POST: App_Tutor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(App_Tutor app_Tutor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    app_Tutor.User = await this.userHelper.GetUserByEmailAsync("pedromc219@gmail.com");
                    await this.tutorRepository.UpdateAsync(app_Tutor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.tutorRepository.ExistAsync(app_Tutor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(app_Tutor);
        }

        // GET: App_Tutor/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var app_Tutor = this.tutorRepository.GetByIdAsync(id.Value);
            if (app_Tutor == null)
            {
                return NotFound();
            }

            return View(app_Tutor);
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
    }
}
