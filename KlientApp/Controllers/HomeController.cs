using System.Diagnostics;
using AppData.Data.CMS;
using AppInterfaces.CMS;
using AppInterfaces.Sklep;
using KlientApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KlientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountService _accountService;
        private readonly IAktualnosciService _aktualnosciService;
        private readonly ITrescStronyService _trescStronyService;

        public HomeController(
            ILogger<HomeController> logger,
            IAccountService accountService,
            IAktualnosciService aktualnosciService,
            ITrescStronyService trescStronyService)
        {
            _logger = logger;
            _accountService = accountService;
            _aktualnosciService = aktualnosciService;
            _trescStronyService = trescStronyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Produkty(string? search, string? sort)
        {
            ViewBag.Search = search;
            ViewBag.Sort = sort;
            return View();
        }

        public IActionResult ONas()
        {
            return View();
        }

        public IActionResult Kontakt()
        {
            return View();
        }

        public async Task<IActionResult> Konto()
        {
            KontoViewModel model;

            if (User.Identity?.IsAuthenticated ?? false)
            {
                var email = User.Identity.Name;
                if (!string.IsNullOrEmpty(email))
                {
                    var user = await _accountService.GetUserByEmailAsync(email);
                    if (user != null)
                    {
                        var aktualnosci = await _aktualnosciService.GetAktualnosci(5);

                        model = new KontoViewModel
                        {
                            Email = user.Email,
                            DataRejestracji = user.DataRejestracji,
                            Imie = user.Imie,
                            Nazwisko = user.Nazwisko,
                            News = aktualnosci.ToList(),
                            NaglowekTwojeDane = await _trescStronyService.PobierzTrescAsync("Konto.TwojeDane") ?? "Twoje dane",
                            NaglowekAktualnosci = await _trescStronyService.PobierzTrescAsync("Konto.Aktualnosci") ?? "Aktualnoœci",
                            NaglowekFaq = await _trescStronyService.PobierzTrescAsync("Konto.FAQ") ?? "FAQ"
                        };

                        return View(model);
                    }
                }
            }

            model = new KontoViewModel
            {
                NaglowekTwojeDane = await _trescStronyService.PobierzTrescAsync("Konto.TwojeDane") ?? "Twoje dane",
                NaglowekAktualnosci = await _trescStronyService.PobierzTrescAsync("Konto.Aktualnosci") ?? "Aktualnoœci",
                NaglowekFaq = await _trescStronyService.PobierzTrescAsync("Konto.FAQ") ?? "FAQ",
                News = new List<Aktualnosc>()
            };

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
