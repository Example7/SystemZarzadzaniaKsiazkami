using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppData.Data.CMS;
using PracownikApp.Controllers.Abstrakcja;

namespace PracownikApp.Controllers
{
    public class FooterItemController : BaseSearchController<FooterItem>
    {
        public FooterItemController(AppData.Data.AppContext context) : base(context) { }

        // GET: FooterItem
        public async Task<IActionResult> Index(string? searchTerm)
        {
            var query = _context.FooterItem.AsQueryable();

            query = ApplySearch(query, searchTerm, f => f.Key);

            var list = await query.ToListAsync();
            return View(list);
        }

        // GET: FooterItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footerItem = await _context.FooterItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footerItem == null)
            {
                return NotFound();
            }

            return View(footerItem);
        }

        // GET: FooterItem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FooterItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Key,Content,Order")] FooterItem footerItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(footerItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(footerItem);
        }

        // GET: FooterItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footerItem = await _context.FooterItem.FindAsync(id);
            if (footerItem == null)
            {
                return NotFound();
            }
            return View(footerItem);
        }

        // POST: FooterItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Key,Content,Order")] FooterItem footerItem)
        {
            if (id != footerItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(footerItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FooterItemExists(footerItem.Id))
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
            return View(footerItem);
        }

        // GET: FooterItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footerItem = await _context.FooterItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footerItem == null)
            {
                return NotFound();
            }

            return View(footerItem);
        }

        // POST: FooterItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var footerItem = await _context.FooterItem.FindAsync(id);
            if (footerItem != null)
            {
                _context.FooterItem.Remove(footerItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FooterItemExists(int id)
        {
            return _context.FooterItem.Any(e => e.Id == id);
        }
    }
}
