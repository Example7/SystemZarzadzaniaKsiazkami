using AppData.Data.Sklep;

namespace AppInterfaces.Sklep
{
    public interface IKategoriaService
    {
        Task<IList<Kategoria>> GetKategorie();
        Task<string?> GetNaglowekAsync(string klucz);
    }
}
