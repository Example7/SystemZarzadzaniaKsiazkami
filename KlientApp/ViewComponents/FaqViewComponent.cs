using AppInterfaces.CMS;
using Microsoft.AspNetCore.Mvc;

namespace KlientApp.ViewComponents
{
    public class FaqViewComponent : ViewComponent
    {
        private readonly IFaqService _faqService;

        public FaqViewComponent(IFaqService faqService)
        {
            _faqService = faqService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var faqItems = await _faqService.GetFaqItemsAsync();
            return View(faqItems);
        }
    }
}
