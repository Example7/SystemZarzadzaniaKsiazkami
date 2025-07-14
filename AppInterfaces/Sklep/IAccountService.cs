using AppData.Data.Sklep;

namespace AppInterfaces.Sklep
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(string email, string password, string? imie, string? nazwisko);
        Task<Uzytkownik?> LoginAsync(string email, string password);
        Task<DateTime?> GetRegistrationDateAsync(string username);
        Task<Uzytkownik?> GetUserByEmailAsync(string email);
        Task LogoutAsync();
    }
}
