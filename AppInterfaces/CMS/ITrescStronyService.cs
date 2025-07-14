namespace AppInterfaces.CMS
{
    public interface ITrescStronyService
    {
        Task<string?> PobierzTrescAsync(string klucz);
    }
}
