using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppData.Data.Sklep;
using PracownikApp.Controllers.Abstrakcja;

namespace PracownikApp.Controllers
{
    public class ZamowienieKsiazkaController : BaseSearchController<ZamowienieKsiazka>
    {
        public ZamowienieKsiazkaController(AppData.Data.AppContext context ) : base(context) { }

        // GET: ZamowienieKsiazka
        public async Task<IActionResult> Index(string? searchTerm)
        {
            var query = _context.ZamowienieKsiazka
                        .Include(z => z.Zamowienie)
                        .Include(z => z.Ksiazka)
                        .AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(z =>
                   (z.Zamowienie != null && z.Zamowienie.AdresDostawy != null && z.Zamowienie.AdresDostawy.Contains(searchTerm)) ||
                   (z.Zamowienie != null && z.Zamowienie.Uzytkownik != null && z.Zamowienie.Uzytkownik.Email != null && z.Zamowienie.Uzytkownik.Email.Contains(searchTerm))
               );
            }

            var list = await query.ToListAsync();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                list = list.Where(z =>
                    z.Zamowienie != null &&
                    !string.IsNullOrEmpty(z.Zamowienie.Status.ToString()) &&
                    z.Zamowienie.Status.ToString().Contains(searchTerm)
                ).ToList();
            }

            return View(list);
        }

        // GET: ZamowienieKsiazka/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienieKsiazka = await _context.ZamowienieKsiazka
                .Include(z => z.Ksiazka)
                .Include(z => z.Zamowienie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zamowienieKsiazka == null)
            {
                return NotFound();
            }

            return View(zamowienieKsiazka);
        }

        // GET: ZamowienieKsiazka/Create
        public IActionResult Create()
        {
            ViewData["KsiazkaID"] = new SelectList(_context.Ksiazka, "KsiazkaID", "ISBN");
            ViewData["ZamowienieID"] = new SelectList(_context.Zamowienie, "ZamowienieID", "ZamowienieID");
            return View();
        }

        // POST: ZamowienieKsiazka/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ZamowienieID,KsiazkaID,Ilosc,CenaJednostkowa")] ZamowienieKsiazka zamowienieKsiazka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zamowienieKsiazka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KsiazkaID"] = new SelectList(_context.Ksiazka, "KsiazkaID", "ISBN", zamowienieKsiazka.KsiazkaID);
            ViewData["ZamowienieID"] = new SelectList(_context.Zamowienie, "ZamowienieID", "ZamowienieID", zamowienieKsiazka.ZamowienieID);
            return View(zamowienieKsiazka);
        }

        // GET: ZamowienieKsiazka/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienieKsiazka = await _context.ZamowienieKsiazka.FindAsync(id);
            if (zamowienieKsiazka == null)
            {
                return NotFound();
            }
            ViewData["KsiazkaID"] = new SelectList(_context.Ksiazka, "KsiazkaID", "ISBN", zamowienieKsiazka.KsiazkaID);
            ViewData["ZamowienieID"] = new SelectList(_context.Zamowienie, "ZamowienieID", "ZamowienieID", zamowienieKsiazka.ZamowienieID);
            return View(zamowienieKsiazka);
        }

        // POST: ZamowienieKsiazka/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ZamowienieID,KsiazkaID,Ilosc,CenaJednostkowa")] ZamowienieKsiazka zamowienieKsiazka)
        {
            if (id != zamowienieKsiazka.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zamowienieKsiazka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZamowienieKsiazkaExists(zamowienieKsiazka.Id))
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
            ViewData["KsiazkaID"] = new SelectList(_context.Ksiazka, "KsiazkaID", "ISBN", zamowienieKsiazka.KsiazkaID);
            ViewData["ZamowienieID"] = new SelectList(_context.Zamowienie, "ZamowienieID", "ZamowienieID", zamowienieKsiazka.ZamowienieID);
            return View(zamowienieKsiazka);
        }

        // GET: ZamowienieKsiazka/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienieKsiazka = await _context.ZamowienieKsiazka
                .Include(z => z.Ksiazka)
                .Include(z => z.Zamowienie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zamowienieKsiazka == null)
            {
                return NotFound();
            }

            return View(zamowienieKsiazka);
        }

        // POST: ZamowienieKsiazka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zamowienieKsiazka = await _context.ZamowienieKsiazka.FindAsync(id);
            if (zamowienieKsiazka != null)
            {
                _context.ZamowienieKsiazka.Remove(zamowienieKsiazka);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZamowienieKsiazkaExists(int id)
        {
            return _context.ZamowienieKsiazka.Any(e => e.Id == id);
        }
    }
}
