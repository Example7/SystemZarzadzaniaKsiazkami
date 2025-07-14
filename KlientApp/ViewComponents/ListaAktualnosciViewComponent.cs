using KlientApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KlientApp.ViewComponents
{
    public class ListaAktualnosciViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(KontoViewModel model)
        {
            return View("Default", model);
        }
    }
}
