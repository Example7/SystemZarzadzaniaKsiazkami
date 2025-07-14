using AppData.Data.CMS;
using AppInterfaces.CMS;
using AppServices.Abstrakcja;
using Microsoft.EntityFrameworkCore;

namespace AppServices.CMS
{
    public class FooterService : BaseService, IFooterService
    {
        public FooterService(AppData.Data.AppContext context) : base(context) { }

        public async Task<IList<FooterItem>> GetFooterItemsAsync()
        {
            return await _context.FooterItem.OrderBy(x => x.Order).ToListAsync();
        }
    }
}
