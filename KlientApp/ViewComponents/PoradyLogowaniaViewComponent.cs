using Microsoft.AspNetCore.Mvc;

public class PoradyLogowaniaViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var porady = new List<string>
        {
            "Używaj unikalnego, silnego hasła.",
            "Nie zapisuj hasła na publicznych urządzeniach.",
            "Regularnie zmieniaj swoje hasło.",
            "W razie problemów skorzystaj z opcji resetowania hasła."
        };
        return View(porady);
    }
}
