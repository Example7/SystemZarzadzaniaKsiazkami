using AppData.Data.CMS;
using AppInterfaces.CMS;
using AppServices.Abstrakcja;
using Microsoft.EntityFrameworkCore;

namespace AppServices.CMS
{
    public class AktualnoscService : BaseService, IAktualnosciService
    {
        public AktualnoscService(AppData.Data.AppContext context) : base(context) { }

        public async Task<Aktualnosc> GetAktualnosc(int id)
        {
            var aktualnosc = await _context.Aktualnosc.FirstOrDefaultAsync(a => a.IdAktualnosci == id);
            return aktualnosc;
        }

        public async Task<IList<Aktualnosc>> GetAktualnosci(int ilosc)
        {
            var aktualnosci = await _context.Aktualnosc.OrderBy(a => a.Pozycja).Take(ilosc).ToListAsync();
            return aktualnosci;
        }
    }
}
