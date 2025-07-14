using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppData.Data.Sklep;
using PracownikApp.Controllers.Abstrakcja;

namespace PracownikApp.Controllers
{
    public class KsiazkaController : BaseSearchController<Ksiazka>
    {
        public KsiazkaController(AppData.Data.AppContext context) : base(context) { }

        // GET: Ksiazka
        public async Task<IActionResult> Index(string? searchTerm)
        {
            var query = _context.Ksiazka
                .Include(k => k.Autor)
                .Include(k => k.Kategoria)
                .Include(k => k.Wydawnictwo)
                .AsQueryable();

            query = ApplySearch(query, searchTerm, k => k.Tytul);

            var list = await query.ToListAsync();
            return View(list);
        }

        // GET: Ksiazka/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ksiazka = await _context.Ksiazka
                .Include(k => k.Autor)
                .Include(k => k.Kategoria)
                .Include(k => k.Wydawnictwo)
                .FirstOrDefaultAsync(m => m.KsiazkaID == id);
            if (ksiazka == null)
            {
                return NotFound();
            }

            return View(ksiazka);
        }

        // GET: Ksiazka/Create
        public IActionResult Create()
        {
            ViewData["AutorID"] = new SelectList(_context.Autor, "AutorID", "ImieNazwisko");
            ViewData["KategoriaID"] = new SelectList(_context.Kategoria, "KategoriaID", "Nazwa");
            ViewData["WydawnictwoID"] = new SelectList(_context.Wydawnictwo, "WydawnictwoID", "Nazwa");
            return View();
        }

        // POST: Ksiazka/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KsiazkaID,Tytul,ISBN,Cena,Opis,DataWydania,OkladkaUrl,AutorID,WydawnictwoID,KategoriaID")] Ksiazka ksiazka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ksiazka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorID"] = new SelectList(_context.Autor, "AutorID", "ImieNazwisko", ksiazka.AutorID);
            ViewData["KategoriaID"] = new SelectList(_context.Kategoria, "KategoriaID", "Nazwa", ksiazka.KategoriaID);
            ViewData["WydawnictwoID"] = new SelectList(_context.Wydawnictwo, "WydawnictwoID", "Nazwa", ksiazka.WydawnictwoID);
            return View(ksiazka);
        }

        // GET: Ksiazka/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ksiazka = await _context.Ksiazka.FindAsync(id);
            if (ksiazka == null)
            {
                return NotFound();
            }
            ViewData["AutorID"] = new SelectList(_context.Autor, "AutorID", "ImieNazwisko", ksiazka.AutorID);
            ViewData["KategoriaID"] = new SelectList(_context.Kategoria, "KategoriaID", "Nazwa", ksiazka.KategoriaID);
            ViewData["WydawnictwoID"] = new SelectList(_context.Wydawnictwo, "WydawnictwoID", "Nazwa", ksiazka.WydawnictwoID);
            return View(ksiazka);
        }

        // POST: Ksiazka/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KsiazkaID,Tytul,ISBN,Cena,Opis,DataWydania,OkladkaUrl,AutorID,WydawnictwoID,KategoriaID")] Ksiazka ksiazka)
        {
            if (id != ksiazka.KsiazkaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ksiazka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KsiazkaExists(ksiazka.KsiazkaID))
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
            ViewData["AutorID"] = new SelectList(_context.Autor, "AutorID", "ImieNazwisko", ksiazka.AutorID);
            ViewData["KategoriaID"] = new SelectList(_context.Kategoria, "KategoriaID", "Nazwa", ksiazka.KategoriaID);
            ViewData["WydawnictwoID"] = new SelectList(_context.Wydawnictwo, "WydawnictwoID", "Nazwa", ksiazka.WydawnictwoID);
            return View(ksiazka);
        }

        // GET: Ksiazka/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ksiazka = await _context.Ksiazka
                .Include(k => k.Autor)
                .Include(k => k.Kategoria)
                .Include(k => k.Wydawnictwo)
                .FirstOrDefaultAsync(m => m.KsiazkaID == id);
            if (ksiazka == null)
            {
                return NotFound();
            }

            return View(ksiazka);
        }

        // POST: Ksiazka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ksiazka = await _context.Ksiazka.FindAsync(id);
            if (ksiazka != null)
            {
                _context.Ksiazka.Remove(ksiazka);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KsiazkaExists(int id)
        {
            return _context.Ksiazka.Any(e => e.KsiazkaID == id);
        }
    }
}
