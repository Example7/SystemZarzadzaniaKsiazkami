using KlientApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KlientApp.ViewComponents
{
    public class SearchSortViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(string search, string sort)
        {
            var sortOptions = new Dictionary<string, string>
            {
                { "", "Domyślne" },
                { "cena", "Cena rosnąco" },
                { "popularnosc", "Popularność" },
                { "ocena", "Ocena" }
            };

            var model = new SearchSortViewModel
            {
                Search = search,
                Sort = sort ?? "",
                SortOptions = sortOptions
            };

            return Task.FromResult<IViewComponentResult>(View(model));
        }
    }
}
