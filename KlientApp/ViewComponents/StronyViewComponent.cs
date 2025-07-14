using AppInterfaces.CMS;
using Microsoft.AspNetCore.Mvc;

namespace KlientApp.ViewComponents
{
    public class StronyViewComponent : ViewComponent
    {
        private readonly IStronaService _stronaService;

        public StronyViewComponent(IStronaService stronaService)
        {
            _stronaService = stronaService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var strony = await _stronaService.GetStronyByPozycja();
            return View(strony);
        }

    }
}
