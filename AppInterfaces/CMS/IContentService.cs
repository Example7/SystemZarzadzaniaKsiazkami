namespace AppInterfaces.CMS
{
    public interface IContentService
    {
        Task<string?> GetContentByKeyAsync(string key);
    }

}
