using AppData.Data.Sklep;
using AppInterfaces.Sklep;
using AppServices.Abstrakcja;
using Microsoft.EntityFrameworkCore;

namespace AppServices.Sklep
{
    public class KategoriaService : BaseService, IKategoriaService
    {
        public KategoriaService(AppData.Data.AppContext context) : base(context) { }

        public async Task<IList<Kategoria>> GetKategorie()
        {
            var kategorie = await _context.Kategoria.Take(4).ToListAsync();
            return kategorie;
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
