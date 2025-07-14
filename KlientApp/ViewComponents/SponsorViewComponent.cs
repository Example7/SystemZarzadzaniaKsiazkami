using AppInterfaces.CMS;
using Microsoft.AspNetCore.Mvc;

namespace KlientApp.ViewComponents
{
    public class SponsorViewComponent : ViewComponent
    {
        private readonly ISponsorService _sponsorService;

        public SponsorViewComponent(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sponsorzy = await _sponsorService.GetSponsorzy();
            return View(sponsorzy);
        }
    }

}
