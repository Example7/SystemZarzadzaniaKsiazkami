using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppData.Data.CMS;
using PracownikApp.Controllers.Abstrakcja;

namespace PracownikApp.Controllers
{
    public class TrescStronyController : BaseSearchController<TrescStrony>
    {
        public TrescStronyController(AppData.Data.AppContext context) : base(context) { }

        // GET: TrescStrony
        public async Task<IActionResult> Index(string? searchTerm)
        {
            var query = _context.TrescStrony.AsQueryable();
            query = ApplySearch(query, searchTerm, t => t.Klucz);

            var list = await query.ToListAsync();
            return View(list);
        }

        // GET: TrescStrony/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trescStrony = await _context.TrescStrony
                .FirstOrDefaultAsync(m => m.TrescStronyID == id);
            if (trescStrony == null)
            {
                return NotFound();
            }

            return View(trescStrony);
        }

        // GET: TrescStrony/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrescStrony/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrescStronyID,Klucz,Wartosc,DataModyfikacji,KtoZmienil")] TrescStrony trescStrony)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trescStrony);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trescStrony);
        }

        // GET: TrescStrony/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trescStrony = await _context.TrescStrony.FindAsync(id);
            if (trescStrony == null)
            {
                return NotFound();
            }
            return View(trescStrony);
        }

        // POST: TrescStrony/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrescStronyID,Klucz,Wartosc,DataModyfikacji,KtoZmienil")] TrescStrony trescStrony)
        {
            if (id != trescStrony.TrescStronyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trescStrony);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrescStronyExists(trescStrony.TrescStronyID))
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
            return View(trescStrony);
        }

        // GET: TrescStrony/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trescStrony = await _context.TrescStrony
                .FirstOrDefaultAsync(m => m.TrescStronyID == id);
            if (trescStrony == null)
            {
                return NotFound();
            }

            return View(trescStrony);
        }

        // POST: TrescStrony/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trescStrony = await _context.TrescStrony.FindAsync(id);
            if (trescStrony != null)
            {
                _context.TrescStrony.Remove(trescStrony);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrescStronyExists(int id)
        {
            return _context.TrescStrony.Any(e => e.TrescStronyID == id);
        }
    }
}
