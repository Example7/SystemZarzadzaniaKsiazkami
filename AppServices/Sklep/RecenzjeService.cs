using AppData.Data.Sklep;
using AppInterfaces.Sklep;
using AppServices.Abstrakcja;
using Microsoft.EntityFrameworkCore;

namespace AppServices.Sklep
{
    public class RecenzjeService : BaseService, IRecenzjeService
    {
        public RecenzjeService(AppData.Data.AppContext context) : base(context) { }

        public async Task<IList<Recenzja>> GetRecenzje()
        {
            return await _context.Recenzja
                .Include(r => r.Ksiazka)
                .Include(r => r.Uzytkownik)
                .OrderByDescending(r => r.Ocena)
                .Take(3)
                .ToListAsync();
        }

        public async Task<string?> GetNaglowekAsync(string klucz)
        {
            return await _context.TrescStrony
                .Where(t => t.Klucz == klucz)
                .Select(t => t.Wartosc)
                .FirstOrDefaultAsync();
        }
    }
}
