using AppInterfaces.Sklep;
using KlientApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KlientApp.ViewComponents
{
    public class KsiazkiViewComponent : ViewComponent
    {
        private readonly IKsiazkiService _ksiazkiService;

        public KsiazkiViewComponent(IKsiazkiService ksiazkiService)
        {
            _ksiazkiService = ksiazkiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string? search, string? sort)
        {
            var wszystkie = await _ksiazkiService.GetKsiazkiAsync(search, sort);

            var ksiazkiViewModels = wszystkie.Select(k => new KsiazkaViewModel
            {
                KsiazkaID = k.KsiazkaID,
                Tytul = k.Tytul,
                OkladkaUrl = k.OkladkaUrl,
                Autor = k.Autor != null ? $"{k.Autor.Imie} {k.Autor.Nazwisko}" : "Brak autora",
                Cena = k.Cena,
                SredniaOcena = k.Recenzje.Any() ? k.Recenzje.Average(r => r.Ocena) : 0
            }).ToList();

            return View("KsiazkiList", new KsiazkiViewModel
            {
                Naglowek = "Wszystkie książki",
                Ksiazki = ksiazkiViewModels
            });
        }
    }
}
