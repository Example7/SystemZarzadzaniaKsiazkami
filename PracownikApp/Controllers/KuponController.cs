using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppData.Data.Sklep;
using Microsoft.AspNetCore.Mvc.Rendering;
using PracownikApp.Controllers.Abstrakcja;

namespace PracownikApp.Controllers
{
    public class KuponController : BaseSearchController<Kupon>
    {
        public KuponController(AppData.Data.AppContext context) : base(context) { }

        private IEnumerable<SelectListItem> GetTypZnizkiSelectList()
        {
            return Enum.GetValues(typeof(TypZnizki))
                .Cast<TypZnizki>()
                .Select(t => new SelectListItem
                {
                    Text = t.ToString(),
                    Value = ((int)t).ToString()
                });
        }

        // GET: Kupon
        public async Task<IActionResult> Index(string? searchTerm)
        {
            var query = _context.Kupon.AsQueryable();

            query = ApplySearch(query, searchTerm, k => k.Kod);

            var list = await query.ToListAsync();
            return View(list);
        }

        // GET: Kupon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kupon = await _context.Kupon
                .FirstOrDefaultAsync(m => m.KuponID == id);
            if (kupon == null)
            {
                return NotFound();
            }

            return View(kupon);
        }

        // GET: Kupon/Create
        public IActionResult Create()
        {
            ViewData["TypZnizki"] = GetTypZnizkiSelectList();
            return View();
        }

        // POST: Kupon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KuponID,Kod,TypZnizki,WartoscZnizki,DataWaznosci,MinimalnaWartosc,CzyAktywny")] Kupon kupon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kupon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kupon);
        }

        // GET: Kupon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var kupon = await _context.Kupon.FindAsync(id);
            if (kupon == null) return NotFound();

            ViewData["TypZnizki"] = GetTypZnizkiSelectList();
            return View(kupon);
        }

        // POST: Kupon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KuponID,Kod,TypZnizki,WartoscZnizki,DataWaznosci,MinimalnaWartosc,CzyAktywny")] Kupon kupon)
        {
            if (id != kupon.KuponID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kupon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KuponExists(kupon.KuponID))
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
            ViewData["TypZnizki"] = GetTypZnizkiSelectList();
            return View(kupon);
        }

        // GET: Kupon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kupon = await _context.Kupon
                .FirstOrDefaultAsync(m => m.KuponID == id);
            if (kupon == null)
            {
                return NotFound();
            }

            return View(kupon);
        }

        // POST: Kupon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kupon = await _context.Kupon.FindAsync(id);
            if (kupon != null)
            {
                _context.Kupon.Remove(kupon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KuponExists(int id)
        {
            return _context.Kupon.Any(e => e.KuponID == id);
        }
    }
}
