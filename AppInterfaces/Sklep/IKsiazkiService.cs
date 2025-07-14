using AppData.Data.Sklep;

namespace AppInterfaces.Sklep
{
    public interface IKsiazkiService
    {
        Task<IList<Ksiazka>> GetWszystkieKsiazkiAsync();
        Task<IList<Ksiazka>> GetBestselleryAsync();
        Task<IList<Ksiazka>> GetNowosciAsync();
        Task<Ksiazka?> GetKsiazkaRokuAsync();
        Task<string?> GetNaglowekAsync(string klucz);
        Task<IList<Ksiazka>> GetKsiazkiAsync(string? search, string? sort);
    }
}
