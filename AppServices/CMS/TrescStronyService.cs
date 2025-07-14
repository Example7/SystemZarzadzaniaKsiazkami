using AppInterfaces.CMS;
using AppServices.Abstrakcja;
using Microsoft.EntityFrameworkCore;

namespace AppServices.CMS
{
    public class TrescStronyService: BaseService, ITrescStronyService
    {
        public TrescStronyService(AppData.Data.AppContext context) : base(context) { }

        public async Task<string?> PobierzTrescAsync(string klucz)
        {
            var tresc = await _context.TrescStrony
                .Where(t => t.Klucz == klucz)
                .Select(t => t.Wartosc)
                .FirstOrDefaultAsync();

            return tresc;
        }
    }
}
