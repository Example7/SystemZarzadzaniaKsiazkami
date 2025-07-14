using AppData.Data.CMS;

namespace AppInterfaces.CMS
{
    public interface IStronaService
    {
        Task<IList<Strona>> GetStronyByPozycja();

        Task<Strona?> GetStrona(int? id);

        Task<Strona?> GetByLinkTytul(string linkTytul);
    }
}
