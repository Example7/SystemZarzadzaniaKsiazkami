using AppInterfaces.CMS;
using AppServices.Abstrakcja;
using Microsoft.EntityFrameworkCore;

namespace AppServices.CMS
{
    public class ContentService : BaseService, IContentService
    {
        public ContentService(AppData.Data.AppContext context) :base(context) { }

        public async Task<string?> GetContentByKeyAsync(string key)
        {
            return await _context.TrescStrony
                .Where(t => t.Klucz == key)
                .Select(t => t.Wartosc)
                .FirstOrDefaultAsync();
        }
    }

}
