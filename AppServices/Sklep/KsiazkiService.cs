using AppData.Data.Sklep;
using AppInterfaces.Sklep;
using AppServices.Abstrakcja;
using Microsoft.EntityFrameworkCore;

namespace AppServices.Sklep
{
    public class KsiazkiService : BaseService, IKsiazkiService
    {
        public KsiazkiService(AppData.Data.AppContext context) : base(context) { }

        public async Task<IList<Ksiazka>> GetWszystkieKsiazkiAsync()
        {
            return await _context.Ksiazka
                .Include(k => k.Autor)
                .Include(k => k.Recenzje)
                .OrderBy(k => k.Tytul)
                .ToListAsync();
        }

        public async Task<IList<Ksiazka>> GetBestselleryAsync()
        {
            return await _context.Ksiazka
                .Include(k => k.Autor)
                .Include(k => k.Recenzje)
                .OrderByDescending(k => k.ZamowieniaKsiazki.Count)
                .Take(4)
                .ToListAsync();
        }


        public async Task<IList<Ksiazka>> GetNowosciAsync()
        {
            return await _context.Ksiazka
                .Include(k => k.Autor)
                .Include(k => k.Recenzje)
                .OrderByDescending(k => k.DataWydania)
                .Take(4)
                .ToListAsync();
        }

        public async Task<Ksiazka?> GetKsiazkaRokuAsync()
        {
            return await _context.Ksiazka
                .Include(k => k.Autor)
                .Include(k => k.Recenzje)
                .Where(k => k.Recenzje.Any())
                .OrderByDescending(k => k.Recenzje.Average(r => r.Ocena))
                .FirstOrDefaultAsync();
        }

        public async Task<string?> GetNaglowekAsync(string klucz)
        {
            return await _context.TrescStrony
                .Where(t => t.Klucz == klucz)
                .Select(t => t.Wartosc)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<Ksiazka>> GetKsiazkiAsync(string? search, string? sort)
        {
            var query = _context.Ksiazka
                .Include(k => k.Autor)
                .Include(k => k.Recenzje)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(k => k.Tytul.Contains(search) ||
                                         (k.Autor != null && (k.Autor.Imie + " " + k.Autor.Nazwisko).Contains(search)));
            }

            query = sort switch
            {
                "cena" => query.OrderBy(k => k.Cena),
                "popularnosc" => query.OrderByDescending(k => k.ZamowieniaKsiazki.Count),
                "ocena" => query.OrderByDescending(k => k.Recenzje.Any() ? k.Recenzje.Average(r => r.Ocena) : 0),
                _ => query.OrderBy(k => k.Tytul)
            };

            return await query.ToListAsync();
        }

    }
}
