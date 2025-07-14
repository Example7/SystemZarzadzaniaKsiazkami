using AppData.Data.Sklep;

namespace AppInterfaces.Sklep
{
    public interface IRecenzjeService
    {
        Task<IList<Recenzja>> GetRecenzje();
        Task<string?> GetNaglowekAsync(string klucz);
    }
}
