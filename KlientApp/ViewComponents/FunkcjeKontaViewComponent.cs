using Microsoft.AspNetCore.Mvc;

public class FunkcjeKontaViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
