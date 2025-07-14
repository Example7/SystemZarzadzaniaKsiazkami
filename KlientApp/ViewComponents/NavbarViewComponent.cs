using Microsoft.AspNetCore.Mvc;

namespace KlientApp.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult(View() as IViewComponentResult);
        }
    }

}
