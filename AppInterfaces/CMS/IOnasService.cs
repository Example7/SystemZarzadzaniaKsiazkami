namespace AppInterfaces.CMS
{
    public interface IONasService
    {
        Task<ONasDTO> GetONasContentAsync();
    }
}
