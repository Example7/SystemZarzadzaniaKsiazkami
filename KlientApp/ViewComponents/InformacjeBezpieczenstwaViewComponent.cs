using Microsoft.AspNetCore.Mvc;

public class InformacjeBezpieczenstwaViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
