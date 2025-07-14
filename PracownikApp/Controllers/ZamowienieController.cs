using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppData.Data.Sklep;
using PracownikApp.Controllers.Abstrakcja;

namespace PracownikApp.Controllers
{
    public class ZamowienieController : BaseSearchController<Zamowienie>
    {
        public ZamowienieController(AppData.Data.AppContext context) : base(context) { }

        private SelectList GetEnumSelectList<T>(T? selectedValue = null) where T : struct, Enum
        {
            var values = Enum.GetValues(typeof(T))
                             .Cast<T>()
                             .Select(e => new { Id = e, Name = e.ToString() });

            return new SelectList(values, "Id", "Name", selectedValue);
        }

        // GET: Zamowienie
        public async Task<IActionResult> Index(string? searchTerm)
        {
            var query = _context.Zamowienie
                .Include(z => z.Uzytkownik)
                .Include(z => z.Kupon)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(z => z.AdresDostawy != null && z.AdresDostawy.Contains(searchTerm)
                                     || (z.Uzytkownik != null && z.Uzytkownik.Email != null && z.Uzytkownik.Email.Contains(searchTerm)));
            }

            var list = await query.ToListAsync();
            return View(list);
        }

        // GET: Zamowienie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienie
                .Include(z => z.Kupon)
                .Include(z => z.Uzytkownik)
                .FirstOrDefaultAsync(m => m.ZamowienieID == id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return View(zamowienie);
        }

        // GET: Zamowienie/Create
        public IActionResult Create()
        {
            var kupony = _context.Kupon
                .Select(k => new SelectListItem
                {
                    Value = k.KuponID.ToString(),
                    Text = k.Kod
                }).ToList();

            kupony.Insert(0, new SelectListItem { Value = "", Text = "Brak" });

            ViewData["KuponID"] = new SelectList(kupony, "Value", "Text");
            ViewData["UzytkownikID"] = new SelectList(_context.Uzytkownik, "UzytkownikID", "Email");
            ViewBag.Status = GetEnumSelectList<StatusZamowienia>();
            return View();
        }

        // POST: Zamowienie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZamowienieID,DataZamowienia,UzytkownikID,KuponID,Status,AdresDostawy,KwotaCalkowita")] Zamowienie zamowienie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zamowienie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var kupony = _context.Kupon
                .Select(k => new SelectListItem
                {
                    Value = k.KuponID.ToString(),
                    Text = k.Kod
                }).ToList();

            kupony.Insert(0, new SelectListItem { Value = "", Text = "Brak" });

            ViewData["KuponID"] = new SelectList(kupony, "Value", "Text", zamowienie.KuponID?.ToString());
            ViewData["UzytkownikID"] = new SelectList(_context.Uzytkownik, "UzytkownikID", "Email", zamowienie.UzytkownikID);
            ViewBag.Status = GetEnumSelectList<StatusZamowienia>();
            return View(zamowienie);
        }

        // GET: Zamowienie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienie.FindAsync(id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            var kupony = _context.Kupon
                .Select(k => new SelectListItem
                {
                    Value = k.KuponID.ToString(),
                    Text = k.Kod
                }).ToList();

            kupony.Insert(0, new SelectListItem { Value = "", Text = "Brak" });

            ViewData["KuponID"] = new SelectList(kupony, "Value", "Text", zamowienie.KuponID?.ToString());
            ViewData["UzytkownikID"] = new SelectList(_context.Uzytkownik, "UzytkownikID", "Email", zamowienie.UzytkownikID);
            ViewBag.Status = GetEnumSelectList<StatusZamowienia>(zamowienie.Status);

            return View(zamowienie);
        }

        // POST: Zamowienie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZamowienieID,DataZamowienia,UzytkownikID,KuponID,Status,AdresDostawy,KwotaCalkowita")] Zamowienie zamowienie)
        {
            if (id != zamowienie.ZamowienieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zamowienie);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZamowienieExists(zamowienie.ZamowienieID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            var kupony = _context.Kupon
                .Select(k => new SelectListItem
                {
                    Value = k.KuponID.ToString(),
                    Text = k.Kod
                }).ToList();

            kupony.Insert(0, new SelectListItem { Value = "", Text = "Brak" });

            ViewData["KuponID"] = new SelectList(kupony, "Value", "Text", zamowienie.KuponID?.ToString());
            ViewData["UzytkownikID"] = new SelectList(_context.Uzytkownik, "UzytkownikID", "Email", zamowienie.UzytkownikID);
            ViewBag.Status = GetEnumSelectList<StatusZamowienia>(zamowienie.Status);
            return View(zamowienie);
        }

        // GET: Zamowienie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienie
                .Include(z => z.Kupon)
                .Include(z => z.Uzytkownik)
                .FirstOrDefaultAsync(m => m.ZamowienieID == id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return View(zamowienie);
        }

        // POST: Zamowienie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zamowienie = await _context.Zamowienie.FindAsync(id);
            if (zamowienie != null)
            {
                _context.Zamowienie.Remove(zamowienie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZamowienieExists(int id)
        {
            return _context.Zamowienie.Any(e => e.ZamowienieID == id);
        }
    }
}
