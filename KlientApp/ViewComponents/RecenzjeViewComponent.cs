using AppInterfaces.Sklep;
using KlientApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KlientApp.ViewComponents
{
    public class RecenzjeViewComponent : ViewComponent
    {
        private readonly IRecenzjeService _recenzjeService;

        public RecenzjeViewComponent(IRecenzjeService recenzjeService)
        {
            _recenzjeService = recenzjeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var topRecenzje = await _recenzjeService.GetRecenzje();

            var model = topRecenzje.Select(r => new RecenzjaViewModel
            {
                Tresc = r.Tresc,
                Autor = r.Uzytkownik?.Imie + " " + r.Uzytkownik?.Nazwisko ?? "Nieznany",
                Ocena = r.Ocena,
                KsiazkaTytul = r.Ksiazka?.Tytul ?? "Nieznana książka"
            }).ToList();

            var naglowek = await _recenzjeService.GetNaglowekAsync("Sklep.Recenzje") ?? "Opinie naszych klientów";

            ViewData["Naglowek"] = naglowek;

            return View("~/Views/Shared/Components/Recenzje/RecenzjeComponent.cshtml", model);
        }
    }
}
