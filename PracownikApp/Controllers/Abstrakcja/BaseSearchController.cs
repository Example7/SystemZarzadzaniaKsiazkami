using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace PracownikApp.Controllers.Abstrakcja
{
    public abstract class BaseSearchController<T> : Controller where T : class
    {
        protected readonly AppData.Data.AppContext _context;

        protected BaseSearchController(AppData.Data.AppContext context)
        {
            _context = context;
        }

        protected IQueryable<T> ApplySearch(IQueryable<T> query, string? searchTerm, Expression<Func<T, string>> getSearchField)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return query;

            var parameter = getSearchField.Parameters[0];
            var body = Expression.Call(
                getSearchField.Body,
                nameof(string.Contains),
                Type.EmptyTypes,
                Expression.Constant(searchTerm)
            );

            var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);

            return query.Where(lambda);
        }
    }
}
