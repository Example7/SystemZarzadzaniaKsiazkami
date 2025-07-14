using Microsoft.AspNetCore.Mvc;

namespace PracownikApp.Controllers
{
    public class SearchViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string placeholder = "Szukaj...", string inputName = "searchTerm", string formAction = "")
        {
            ViewData["Placeholder"] = placeholder;
            ViewData["InputName"] = inputName;
            ViewData["FormAction"] = formAction;
            return View();
        }
    }
}
