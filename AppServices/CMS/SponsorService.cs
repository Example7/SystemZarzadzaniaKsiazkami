using AppData.Data.CMS;
using AppInterfaces.CMS;
using AppServices.Abstrakcja;
using Microsoft.EntityFrameworkCore;

namespace AppServices.CMS
{
    public class SponsorService : BaseService, ISponsorService
    {
        public SponsorService(AppData.Data.AppContext context) : base(context) { }

        public async Task<IList<Sponsor>> GetSponsorzy()
        {
            var sponsorzy = await _context.Sponsor.Take(6).ToListAsync();
            return sponsorzy;
        }
    }
}
