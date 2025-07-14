using AppInterfaces.CMS;
using AppServices.Abstrakcja;
using Microsoft.EntityFrameworkCore;

namespace AppServices.CMS
{
    public class ONasService : BaseService, IONasService
    {
        public ONasService(AppData.Data.AppContext context) : base(context) { }

        public async Task<ONasDTO> GetONasContentAsync()
        {
            var tresci = await _context.TrescStrony
                .Where(t => t.Klucz.StartsWith("O_Nas."))
                .ToDictionaryAsync(t => t.Klucz, t => t.Wartosc);

            var wartosciRaw = await _context.TrescStrony
                .Where(t => t.Klucz.StartsWith("O_Nas.Wartosci."))
                .OrderBy(t => t.Klucz)
                .ToListAsync();

            var wartosci = wartosciRaw.Select(t => new ONasWartoscDTO
            {
                Tytul = ExtractTitleFromKey(t.Klucz),
                Tresc = t.Wartosc
            }).ToList();

            var statystyki = await _context.TrescStrony
                .Where(t => t.Klucz.StartsWith("O_Nas.Statystyki."))
                .ToListAsync();

            var statList = statystyki
                .GroupBy(t => ExtractStatKeyIndex(t.Klucz))
                .OrderBy(g => g.Key)
                .Select(g => new ONasStatystykaDTO
                {
                    Liczba = g.FirstOrDefault(x => x.Klucz.Contains("Liczba"))?.Wartosc,
                    Opis = g.FirstOrDefault(x => x.Klucz.Contains("Opis"))?.Wartosc
                })
                .ToList();

            return new ONasDTO
            {
                Naglowek = tresci.GetValueOrDefault("O_Nas.Header"),
                Akapit1 = tresci.GetValueOrDefault("O_Nas.Paragraph1"),
                Akapit2 = tresci.GetValueOrDefault("O_Nas.Paragraph2"),
                Cytat = tresci.GetValueOrDefault("O_Nas.Quote"),
                CytatAutor = tresci.GetValueOrDefault("O_Nas.QuoteAuthor"),
                SectionValuesHeader = tresci.GetValueOrDefault("O_Nas.SectionValuesHeader"),
                ContactButtonText = tresci.GetValueOrDefault("O_Nas.ContactButtonText"),
                Wartosci = wartosci,
                Statystyki = statList
            };

        }

        private string? ExtractTitleFromKey(string key)
        {
            var parts = key.Split('.');
            if (parts.Length >= 3)
            {
                return parts[2];
            }
            return null;
        }

        private int ExtractStatKeyIndex(string key)
        {
            var lastPart = key.Split('.').Last();
            var digits = new string(lastPart.Where(char.IsDigit).ToArray());
            return int.TryParse(digits, out var index) ? index : 0;
        }


    }
}
