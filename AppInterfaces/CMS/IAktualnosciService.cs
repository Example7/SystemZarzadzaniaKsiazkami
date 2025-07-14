using AppData.Data.CMS;

namespace AppInterfaces.CMS
{
    public interface IAktualnosciService
    {
        Task<IList<Aktualnosc>> GetAktualnosci(int ilosc);

        Task<Aktualnosc> GetAktualnosc(int id);
    }
}
