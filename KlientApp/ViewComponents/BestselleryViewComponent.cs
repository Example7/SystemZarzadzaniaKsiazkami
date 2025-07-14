using AppInterfaces.Sklep;
using KlientApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KlientApp.ViewComponents
{
    public class BestselleryViewComponent : ViewComponent
    {
        private readonly IKsiazkiService _ksiazkiService;

        public BestselleryViewComponent(IKsiazkiService ksiazkiService)
        {
            _ksiazkiService = ksiazkiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var bestsellery = await _ksiazkiService.GetBestselleryAsync();

            var ksiazkiViewModels = bestsellery.Select(k => new KsiazkaViewModel
            {
                KsiazkaID = k.KsiazkaID,
                Tytul = k.Tytul,
                OkladkaUrl = k.OkladkaUrl,
                Autor = k.Autor != null ? $"{k.Autor.Imie} {k.Autor.Nazwisko}" : "Brak autora",
                Cena = k.Cena,
                SredniaOcena = k.Recenzje.Any() ? k.Recenzje.Average(r => r.Ocena) : 0
            }).ToList();

            var naglowek = await _ksiazkiService.GetNaglowekAsync("Sklep.Bestsellery") ?? "Bestsellery";

            return View("~/Views/Shared/Components/Ksiazki/KsiazkiList.cshtml", new KsiazkiViewModel
            {
                Ksiazki = ksiazkiViewModels,
                Naglowek = naglowek
            });
        }
    }
}
