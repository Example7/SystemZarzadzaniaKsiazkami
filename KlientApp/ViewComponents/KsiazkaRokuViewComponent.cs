using AppInterfaces.Sklep;
using Microsoft.AspNetCore.Mvc;

namespace KlientApp.ViewComponents
{
    public class KsiazkaRokuViewComponent : ViewComponent
    {
        private readonly IKsiazkiService _ksiazkiService;

        public KsiazkaRokuViewComponent(IKsiazkiService ksiazkiService)
        {
            _ksiazkiService = ksiazkiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ksiazka = await _ksiazkiService.GetKsiazkaRokuAsync();
            var naglowek = await _ksiazkiService.GetNaglowekAsync("Sklep.KsiazkaRoku") ?? "Książka roku";

            return View("KsiazkaRokuComponent", new KsiazkaRokuViewModel
            {
                Ksiazka = ksiazka,
                Naglowek = naglowek
            });
        }
    }
}
