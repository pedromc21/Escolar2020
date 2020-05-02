namespace Escolar2020.Web.Controllers
{
    using Escolar2020.Web.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    public class App_TutorController : Controller
    {
        private readonly DataContext _context;

        public App_TutorController(DataContext context)
        {
            _context = context;
        }

        // GET: App_Tutor
        public async Task<IActionResult> Index()
        {
            return View(await _context.App_Tutors.ToListAsync());
        }

        // GET: App_Tutor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var app_Tutor = await _context.App_Tutors
                .FirstOrDefaultAsync(m => m.Id == id);
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
                _context.Add(app_Tutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(app_Tutor);
        }

        // GET: App_Tutor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var app_Tutor = await _context.App_Tutors.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, App_Tutor app_Tutor)
        {
            if (id != app_Tutor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(app_Tutor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!App_TutorExists(app_Tutor.Id))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var app_Tutor = await _context.App_Tutors
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var app_Tutor = await _context.App_Tutors.FindAsync(id);
            _context.App_Tutors.Remove(app_Tutor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool App_TutorExists(int id)
        {
            return _context.App_Tutors.Any(e => e.Id == id);
        }
    }
}
