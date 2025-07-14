using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppData.Data.Sklep;
using PracownikApp.Controllers.Abstrakcja;

namespace PracownikApp.Controllers
{
    public class WydawnictwoController : BaseSearchController<Wydawnictwo>
    {
        public WydawnictwoController(AppData.Data.AppContext context) : base(context) { }

        // GET: Wydawnictwo
        public async Task<IActionResult> Index(string? searchTerm)
        {
            var query = _context.Wydawnictwo.AsQueryable();
            query = ApplySearch(query, searchTerm, w => w.Nazwa);

            var list = await query.ToListAsync();
            return View(list);
        }

        // GET: Wydawnictwo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wydawnictwo = await _context.Wydawnictwo
                .FirstOrDefaultAsync(m => m.WydawnictwoID == id);
            if (wydawnictwo == null)
            {
                return NotFound();
            }

            return View(wydawnictwo);
        }

        // GET: Wydawnictwo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wydawnictwo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WydawnictwoID,Nazwa,Opis")] Wydawnictwo wydawnictwo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wydawnictwo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wydawnictwo);
        }

        // GET: Wydawnictwo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wydawnictwo = await _context.Wydawnictwo.FindAsync(id);
            if (wydawnictwo == null)
            {
                return NotFound();
            }
            return View(wydawnictwo);
        }

        // POST: Wydawnictwo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WydawnictwoID,Nazwa,Opis")] Wydawnictwo wydawnictwo)
        {
            if (id != wydawnictwo.WydawnictwoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wydawnictwo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WydawnictwoExists(wydawnictwo.WydawnictwoID))
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
            return View(wydawnictwo);
        }

        // GET: Wydawnictwo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wydawnictwo = await _context.Wydawnictwo
                .FirstOrDefaultAsync(m => m.WydawnictwoID == id);
            if (wydawnictwo == null)
            {
                return NotFound();
            }

            return View(wydawnictwo);
        }

        // POST: Wydawnictwo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wydawnictwo = await _context.Wydawnictwo.FindAsync(id);
            if (wydawnictwo != null)
            {
                _context.Wydawnictwo.Remove(wydawnictwo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WydawnictwoExists(int id)
        {
            return _context.Wydawnictwo.Any(e => e.WydawnictwoID == id);
        }
    }
}
