using AppData.Data.CMS;
using AppInterfaces.CMS;
using AppServices.Abstrakcja;
using Microsoft.EntityFrameworkCore;

namespace AppServices.CMS
{
    public class StronaService : BaseService, IStronaService
    {
        public StronaService(AppData.Data.AppContext context) : base(context) { }

        public async Task<Strona?> GetStrona(int? id)
        {
            var strona = await _context.Strona.Where(s => s.IdStrony == id).FirstOrDefaultAsync();
            return strona;
        }

        public async Task<IList<Strona>> GetStronyByPozycja()
        {
            var strony = await _context.Strona.OrderBy(s => s.Pozycja).ToListAsync();
            return strony;
        }

        public async Task<Strona?> GetByLinkTytul(string linkTytul)
        {
            return await _context.Strona.FirstOrDefaultAsync(s => s.LinkTytul == linkTytul);
        }
    }
}
