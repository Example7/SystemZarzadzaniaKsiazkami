using AppInterfaces.Sklep;
using AppServices.Abstrakcja;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using AppData.Data.Sklep;
using Microsoft.AspNetCore.Http;

public class AccountService : BaseService, IAccountService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AccountService(AppData.Data.AppContext context, IHttpContextAccessor httpContextAccessor)
        : base(context)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> RegisterAsync(string email, string password, string? imie, string? nazwisko)
    {
        if (await _context.Uzytkownik.AnyAsync(u => u.Email == email))
            return false;

        var hash = BCrypt.Net.BCrypt.HashPassword(password);

        var user = new Uzytkownik
        {
            Email = email,
            HasloHash = hash,
            Imie = imie,
            Nazwisko = nazwisko,
            DataRejestracji = DateTime.Now
        };

        _context.Uzytkownik.Add(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Uzytkownik?> LoginAsync(string email, string password)
    {
        var user = await _context.Uzytkownik.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.HasloHash))
            return null;

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.UzytkownikID.ToString()),
            new Claim(ClaimTypes.Name, user.Email),
            new Claim("IsAdmin", user.CzyAdmin.ToString())
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await _httpContextAccessor.HttpContext!.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        return user;
    }

    public async Task<DateTime?> GetRegistrationDateAsync(string email)
    {
        var user = await _context.Uzytkownik.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
            throw new Exception("Użytkownik nie znaleziony");

        return user.DataRejestracji;
    }

    public async Task<Uzytkownik?> GetUserByEmailAsync(string email)
    {
        return await _context.Uzytkownik.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task LogoutAsync()
    {
        await _httpContextAccessor.HttpContext!.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
