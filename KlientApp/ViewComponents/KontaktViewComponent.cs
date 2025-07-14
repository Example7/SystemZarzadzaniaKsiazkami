using Microsoft.AspNetCore.Mvc;
using AppInterfaces.CMS;
using KlientApp.Models;

namespace KlientApp.ViewComponents
{
    public class KontaktViewComponent : ViewComponent
    {
        private readonly IKontaktService _service;

        public KontaktViewComponent(IKontaktService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var dto = await _service.GetKontaktContentAsync();

            var model = new KontaktViewModel
            {
                HeaderTytul = dto.HeaderTytul,
                HeaderOpis = dto.HeaderOpis,

                HeaderDaneKontaktowe = dto.HeaderDaneKontaktowe,
                Adres = dto.Adres,
                Email = dto.Email,
                Telefon = dto.Telefon,

                HeaderGodzinyOtwarcia = dto.HeaderGodzinyOtwarcia,
                GodzinyOtwarcia = dto.GodzinyOtwarcia,

                HeaderZnajdzNas = dto.HeaderZnajdzNas,
                FbLink = dto.FbLink,
                InstagramLink = dto.InstagramLink,
                TwitterLink = dto.TwitterLink,

                HeaderFormularz = dto.HeaderFormularz,
                ImieNazwiskoLabel = dto.ImieNazwiskoLabel,
                EmailLabel = dto.EmailLabel,
                WiadomoscLabel = dto.WiadomoscLabel,
                PrzyciskWyslij = dto.PrzyciskWyslij,

                MapEmbedUrl = dto.MapEmbedUrl
            };

            return View("KontaktComponent", model);
        }
    }
}
