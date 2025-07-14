using AppInterfaces.Sklep;
using KlientApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KlientApp.ViewComponents
{
    public class NowosciViewComponent : ViewComponent
    {
        private readonly IKsiazkiService _ksiazkiService;

        public NowosciViewComponent(IKsiazkiService ksiazkiService)
        {
            _ksiazkiService = ksiazkiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var nowosci = await _ksiazkiService.GetNowosciAsync();

            var ksiazkiViewModels = nowosci.Select(k => new KsiazkaViewModel
            {
                KsiazkaID = k.KsiazkaID,
                Tytul = k.Tytul,
                OkladkaUrl = k.OkladkaUrl,
                Autor = k.Autor != null ? $"{k.Autor.Imie} {k.Autor.Nazwisko}" : "Brak autora",
                Cena = k.Cena,
                SredniaOcena = k.Recenzje.Any() ? k.Recenzje.Average(r => r.Ocena) : 0
            }).ToList();

            var naglowek = await _ksiazkiService.GetNaglowekAsync("Sklep.Nowosci") ?? "Nowości";

            return View("~/Views/Shared/Components/Ksiazki/KsiazkiList.cshtml", new KsiazkiViewModel
            {
                Ksiazki = ksiazkiViewModels,
                Naglowek = naglowek
            });
        }
    }
}
