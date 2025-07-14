﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppData.Data.Sklep;
using PracownikApp.Controllers.Abstrakcja;

namespace PracownikApp.Controllers
{
    public class UzytkownikController : BaseSearchController<Uzytkownik>
    {
        public UzytkownikController(AppData.Data.AppContext context) : base(context) { }

        // GET: Uzytkownik
        public async Task<IActionResult> Index(string? searchTerm)
        {
            var query = _context.Uzytkownik.AsQueryable();

            query = ApplySearch(query, searchTerm, u => u.Email);

            var list = await query.ToListAsync();
            return View(list);
        }

        // GET: Uzytkownik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownik = await _context.Uzytkownik
                .FirstOrDefaultAsync(m => m.UzytkownikID == id);
            if (uzytkownik == null)
            {
                return NotFound();
            }

            return View(uzytkownik);
        }

        // GET: Uzytkownik/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Uzytkownik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UzytkownikID,Email,HasloHash,Imie,Nazwisko,CzyAdmin,DataRejestracji")] Uzytkownik uzytkownik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uzytkownik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uzytkownik);
        }

        // GET: Uzytkownik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownik = await _context.Uzytkownik.FindAsync(id);
            if (uzytkownik == null)
            {
                return NotFound();
            }
            return View(uzytkownik);
        }

        // POST: Uzytkownik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UzytkownikID,Email,HasloHash,Imie,Nazwisko,CzyAdmin,DataRejestracji")] Uzytkownik uzytkownik)
        {
            if (id != uzytkownik.UzytkownikID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uzytkownik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UzytkownikExists(uzytkownik.UzytkownikID))
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
            return View(uzytkownik);
        }

        // GET: Uzytkownik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownik = await _context.Uzytkownik
                .FirstOrDefaultAsync(m => m.UzytkownikID == id);
            if (uzytkownik == null)
            {
                return NotFound();
            }

            return View(uzytkownik);
        }

        // POST: Uzytkownik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uzytkownik = await _context.Uzytkownik.FindAsync(id);
            if (uzytkownik != null)
            {
                _context.Uzytkownik.Remove(uzytkownik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UzytkownikExists(int id)
        {
            return _context.Uzytkownik.Any(e => e.UzytkownikID == id);
        }
    }
}
