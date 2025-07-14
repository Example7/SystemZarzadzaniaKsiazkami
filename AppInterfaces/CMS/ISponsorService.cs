using AppData.Data.CMS;

namespace AppInterfaces.CMS
{
    public interface ISponsorService
    {
        Task<IList<Sponsor>> GetSponsorzy();
    }
}
