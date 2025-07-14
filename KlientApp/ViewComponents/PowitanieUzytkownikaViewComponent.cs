using Microsoft.AspNetCore.Mvc;

namespace KlientApp.ViewComponents
{
    public class PowitanieUzytkownikaViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity?.Name ?? "Gość";
            return View("Default", userName);
        }
    }
}
