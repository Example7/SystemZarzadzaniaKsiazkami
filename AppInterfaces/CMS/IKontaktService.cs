using AppData.DTO;

namespace AppInterfaces.CMS
{
    public interface IKontaktService
    {
        Task<KontaktDTO> GetKontaktContentAsync();
    }

}
