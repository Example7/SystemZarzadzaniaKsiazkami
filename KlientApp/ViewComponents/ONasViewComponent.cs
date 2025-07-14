using AppInterfaces.CMS;
using KlientApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KlientApp.ViewComponents
{
    public class ONasViewComponent : ViewComponent
    {
        private readonly IONasService _service;

        public ONasViewComponent(IONasService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var dto = await _service.GetONasContentAsync();

            var model = new ONasViewModel
            {
                Naglowek = dto.Naglowek,
                Akapit1 = dto.Akapit1,
                Akapit2 = dto.Akapit2,
                Cytat = dto.Cytat,
                CytatAutor = dto.CytatAutor,
                Wartosci = dto.Wartosci,
                Statystyki = dto.Statystyki,
                SectionValuesHeader = dto.SectionValuesHeader,
                ContactButtonText = dto.ContactButtonText
            };

            return View("ONasComponent", model);
        }

    }
}
