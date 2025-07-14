using AppInterfaces.CMS;
using Microsoft.AspNetCore.Mvc;

namespace KlientApp.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly IFooterService _footerService;

        public FooterViewComponent(IFooterService footerService)
        {
            _footerService = footerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _footerService.GetFooterItemsAsync();
            return View(items);
        }
    }
}
