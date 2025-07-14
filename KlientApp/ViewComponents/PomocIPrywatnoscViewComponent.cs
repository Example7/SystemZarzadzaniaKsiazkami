using Microsoft.AspNetCore.Mvc;

public class PomocIPrywatnoscViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
