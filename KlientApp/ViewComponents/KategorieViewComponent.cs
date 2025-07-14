using AppInterfaces.Sklep;
using Microsoft.AspNetCore.Mvc;

namespace KlientApp.ViewComponents
{
    public class KategorieViewComponent : ViewComponent
    {
        private readonly IKategoriaService _kategoriaService;

        public KategorieViewComponent(IKategoriaService kategoriaService)
        {
            _kategoriaService = kategoriaService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var kategorie = await _kategoriaService.GetKategorie();
            var naglowek = await _kategoriaService.GetNaglowekAsync("Sklep.Kategorie") ?? "Najpopularniejsze kategorie";

            var model = new KategorieViewModel
            {
                Kategorie = kategorie,
                Naglowek = naglowek
            };

            return View("KategorieComponent", model);
        }
    }
}
