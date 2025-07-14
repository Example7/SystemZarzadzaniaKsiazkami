using AppData.Data.Sklep;
using AppInterfaces.CMS;
using AppInterfaces.Sklep;
using KlientApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KlientApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string password, string? imie, string? nazwisko)
        {
            var success = await _accountService.RegisterAsync(email, password, imie, nazwisko);
            if (success)
                return RedirectToAction("Login");

            ModelState.AddModelError("", "Email jest już zajęty");
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _accountService.LoginAsync(email, password);
            if (user == null)
            {
                ModelState.AddModelError("", "Nieprawidłowy email lub hasło");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
