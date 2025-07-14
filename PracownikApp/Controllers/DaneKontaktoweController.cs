using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppData.Data.Sklep;
using PracownikApp.Controllers.Abstrakcja;

namespace PracownikApp.Controllers
{
    public class DaneKontaktoweController : BaseSearchController<DaneKontaktowe>
    {
        public DaneKontaktoweController(AppData.Data.AppContext context) : base(context) { }

        // GET: DaneKontaktowe
        public async Task<IActionResult> Index(string? searchTerm)
        {
            var query = _context.DaneKontaktowe
                .Include(u => u.Uzytkownik)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.ToLower();

                query = query.Where(d =>
                    (d.Uzytkownik != null && d.Uzytkownik.Nazwisko != null && d.Uzytkownik.Nazwisko.ToLower().Contains(searchTerm))
                    || (d.Adres != null && d.Adres.ToLower().Contains(searchTerm))
                    || (d.Miasto != null && d.Miasto.ToLower().Contains(searchTerm))
                    || (d.Telefon != null && d.Telefon.ToLower().Contains(searchTerm))
                    || (d.KodPocztowy != null && d.KodPocztowy.ToLower().Contains(searchTerm))
                    || (d.Uzytkownik != null && d.Uzytkownik.Email != null && d.Uzytkownik.Email.ToLower().Contains(searchTerm))
                );
            }

            var list = await query.ToListAsync();
            return View(list);
        }

        // GET: DaneKontaktowe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daneKontaktowe = await _context.DaneKontaktowe
                .Include(d => d.Uzytkownik)
                .FirstOrDefaultAsync(m => m.UzytkownikID == id);
            if (daneKontaktowe == null)
            {
                return NotFound();
            }

            return View(daneKontaktowe);
        }

        // GET: DaneKontaktowe/Create
        public IActionResult Create()
        {
            ViewData["UzytkownikID"] = new SelectList(_context.Uzytkownik, "UzytkownikID", "Email");
            return View();
        }

        // POST: DaneKontaktowe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UzytkownikID,Adres,KodPocztowy,Miasto,Telefon")] DaneKontaktowe daneKontaktowe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(daneKontaktowe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UzytkownikID"] = new SelectList(_context.Uzytkownik, "UzytkownikID", "Email", daneKontaktowe.UzytkownikID);
            return View(daneKontaktowe);
        }

        // GET: DaneKontaktowe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daneKontaktowe = await _context.DaneKontaktowe.FindAsync(id);
            if (daneKontaktowe == null)
            {
                return NotFound();
            }
            ViewData["UzytkownikID"] = new SelectList(_context.Uzytkownik, "UzytkownikID", "Email", daneKontaktowe.UzytkownikID);
            return View(daneKontaktowe);
        }

        // POST: DaneKontaktowe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UzytkownikID,Adres,KodPocztowy,Miasto,Telefon")] DaneKontaktowe daneKontaktowe)
        {
            if (id != daneKontaktowe.UzytkownikID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(daneKontaktowe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DaneKontaktoweExists(daneKontaktowe.UzytkownikID))
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
            ViewData["UzytkownikID"] = new SelectList(_context.Uzytkownik, "UzytkownikID", "Email", daneKontaktowe.UzytkownikID);
            return View(daneKontaktowe);
        }

        // GET: DaneKontaktowe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daneKontaktowe = await _context.DaneKontaktowe
                .Include(d => d.Uzytkownik)
                .FirstOrDefaultAsync(m => m.UzytkownikID == id);
            if (daneKontaktowe == null)
            {
                return NotFound();
            }

            return View(daneKontaktowe);
        }

        // POST: DaneKontaktowe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var daneKontaktowe = await _context.DaneKontaktowe.FindAsync(id);
            if (daneKontaktowe != null)
            {
                _context.DaneKontaktowe.Remove(daneKontaktowe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DaneKontaktoweExists(int id)
        {
            return _context.DaneKontaktowe.Any(e => e.UzytkownikID == id);
        }
    }
}
