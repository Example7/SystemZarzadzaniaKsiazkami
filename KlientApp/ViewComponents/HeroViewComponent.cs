using AppInterfaces.CMS;
using KlientApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KlientApp.ViewComponents
{
    public class HeroViewComponent : ViewComponent
    {
        private readonly IContentService _contentService;

        public HeroViewComponent(IContentService contentService)
        {
            _contentService = contentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new HeroViewModel
            {
                Title = await _contentService.GetContentByKeyAsync("HomePage.Hero.Title") ?? "Tysiące historii na wyciągnięcie ręki",
                Description = await _contentService.GetContentByKeyAsync("HomePage.Hero.Description") ?? "Odkryj bogatą ofertę książek ...",
                ImagePath = await _contentService.GetContentByKeyAsync("HomePage.Hero.ImagePath") ?? "~/content/mainPagePhoto.jpeg",

                Benefit1 = await _contentService.GetContentByKeyAsync("HomePage.Hero.Benefit1") ?? "Szeroki wybór gatunków",
                Benefit2 = await _contentService.GetContentByKeyAsync("HomePage.Hero.Benefit2") ?? "Szybka dostawa",
                Benefit3 = await _contentService.GetContentByKeyAsync("HomePage.Hero.Benefit3") ?? "Najwyższe oceny czytelników",
            };

            return View(model);
        }
    }
}
