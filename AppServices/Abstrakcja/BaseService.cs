namespace AppServices.Abstrakcja
{
    public abstract class BaseService
    {
        protected readonly AppData.Data.AppContext _context;

        public BaseService(AppData.Data.AppContext context)
        {
            _context = context;
        }
    }
}
