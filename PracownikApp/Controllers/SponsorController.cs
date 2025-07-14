using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppData.Data.CMS;
using PracownikApp.Controllers.Abstrakcja;

namespace PracownikApp.Controllers
{
    public class SponsorController : BaseSearchController<Sponsor>
    {
        public SponsorController(AppData.Data.AppContext context) : base(context) { }

        // GET: Sponsor
        public async Task<IActionResult> Index(string? searchTerm)
        {
            var query = _context.Sponsor.AsQueryable();

            query = ApplySearch(query, searchTerm, s => s.Nazwa);

            var list = await query.ToListAsync();
            return View(list);
        }

        // GET: Sponsor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponsor = await _context.Sponsor
                .FirstOrDefaultAsync(m => m.SponsorID == id);
            if (sponsor == null)
            {
                return NotFound();
            }

            return View(sponsor);
        }

        // GET: Sponsor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sponsor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SponsorID,Nazwa,Opis,LogoUrl,DataRozpoczeciaWspolpracy,DataZakonczeniaWspolpracy")] Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sponsor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sponsor);
        }

        // GET: Sponsor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponsor = await _context.Sponsor.FindAsync(id);
            if (sponsor == null)
            {
                return NotFound();
            }
            return View(sponsor);
        }

        // POST: Sponsor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SponsorID,Nazwa,Opis,LogoUrl,DataRozpoczeciaWspolpracy,DataZakonczeniaWspolpracy")] Sponsor sponsor)
        {
            if (id != sponsor.SponsorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sponsor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SponsorExists(sponsor.SponsorID))
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
            return View(sponsor);
        }

        // GET: Sponsor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponsor = await _context.Sponsor
                .FirstOrDefaultAsync(m => m.SponsorID == id);
            if (sponsor == null)
            {
                return NotFound();
            }

            return View(sponsor);
        }

        // POST: Sponsor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sponsor = await _context.Sponsor.FindAsync(id);
            if (sponsor != null)
            {
                _context.Sponsor.Remove(sponsor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SponsorExists(int id)
        {
            return _context.Sponsor.Any(e => e.SponsorID == id);
        }
    }
}
