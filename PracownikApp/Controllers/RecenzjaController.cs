using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppData.Data.Sklep;
using PracownikApp.Controllers.Abstrakcja;

namespace PracownikApp.Controllers
{
    public class RecenzjaController : BaseSearchController<Recenzja>
    {
        public RecenzjaController(AppData.Data.AppContext context) : base(context) { }

        // GET: Recenzja
        public async Task<IActionResult> Index(string? searchTerm)
        {
            var query = _context.Recenzja
                .Include(r => r.Ksiazka)
                .Include(r => r.Uzytkownik)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(r =>
                    r.Ocena.ToString().Contains(searchTerm) ||
                    (r.Tresc != null && r.Tresc.ToLower().Contains(searchTerm)) ||
                    (r.Ksiazka != null && r.Ksiazka.ISBN != null && r.Ksiazka.ISBN.ToLower().Contains(searchTerm)) ||
                    (r.Uzytkownik != null && r.Uzytkownik.Email != null && r.Uzytkownik.Email.ToLower().Contains(searchTerm))
                );
            }

            var list = await query.ToListAsync();
            return View(list);
        }

        // GET: Recenzja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recenzja = await _context.Recenzja
                .Include(r => r.Ksiazka)
                .Include(r => r.Uzytkownik)
                .FirstOrDefaultAsync(m => m.RecenzjaID == id);
            if (recenzja == null)
            {
                return NotFound();
            }

            return View(recenzja);
        }

        // GET: Recenzja/Create
        public IActionResult Create()
        {
            ViewData["KsiazkaID"] = new SelectList(_context.Ksiazka, "KsiazkaID", "ISBN");
            ViewData["UzytkownikID"] = new SelectList(_context.Uzytkownik, "UzytkownikID", "Email");
            return View();
        }

        // POST: Recenzja/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecenzjaID,Ocena,Tresc,DataDodania,KsiazkaID,UzytkownikID")] Recenzja recenzja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recenzja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KsiazkaID"] = new SelectList(_context.Ksiazka, "KsiazkaID", "ISBN", recenzja.KsiazkaID);
            ViewData["UzytkownikID"] = new SelectList(_context.Uzytkownik, "UzytkownikID", "Email", recenzja.UzytkownikID);
            return View(recenzja);
        }

        // GET: Recenzja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recenzja = await _context.Recenzja.FindAsync(id);
            if (recenzja == null)
            {
                return NotFound();
            }
            ViewData["KsiazkaID"] = new SelectList(_context.Ksiazka, "KsiazkaID", "ISBN", recenzja.KsiazkaID);
            ViewData["UzytkownikID"] = new SelectList(_context.Uzytkownik, "UzytkownikID", "Email", recenzja.UzytkownikID);
            return View(recenzja);
        }

        // POST: Recenzja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecenzjaID,Ocena,Tresc,DataDodania,KsiazkaID,UzytkownikID")] Recenzja recenzja)
        {
            if (id != recenzja.RecenzjaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recenzja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecenzjaExists(recenzja.RecenzjaID))
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
            ViewData["KsiazkaID"] = new SelectList(_context.Ksiazka, "KsiazkaID", "ISBN", recenzja.KsiazkaID);
            ViewData["UzytkownikID"] = new SelectList(_context.Uzytkownik, "UzytkownikID", "Email", recenzja.UzytkownikID);
            return View(recenzja);
        }

        // GET: Recenzja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recenzja = await _context.Recenzja
                .Include(r => r.Ksiazka)
                .Include(r => r.Uzytkownik)
                .FirstOrDefaultAsync(m => m.RecenzjaID == id);
            if (recenzja == null)
            {
                return NotFound();
            }

            return View(recenzja);
        }

        // POST: Recenzja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recenzja = await _context.Recenzja.FindAsync(id);
            if (recenzja != null)
            {
                _context.Recenzja.Remove(recenzja);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecenzjaExists(int id)
        {
            return _context.Recenzja.Any(e => e.RecenzjaID == id);
        }
    }
}
