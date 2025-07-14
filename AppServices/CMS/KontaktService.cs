using AppData.Data;
using Microsoft.EntityFrameworkCore;
using AppData.DTO;
using AppInterfaces.CMS;
using AppServices.Abstrakcja;

namespace AppServices.CMS
{
    public class KontaktService : BaseService, IKontaktService
    {
        public KontaktService(AppData.Data.AppContext context) : base(context)
        {
        }

        public async Task<KontaktDTO> GetKontaktContentAsync()
        {
            var tresci = await _context.TrescStrony
                .Where(t => t.Klucz.StartsWith("Kontakt."))
                .ToDictionaryAsync(t => t.Klucz, t => t.Wartosc);

            return new KontaktDTO
            {
                HeaderTytul = tresci.GetValueOrDefault("Kontakt.Header"),
                HeaderOpis = tresci.GetValueOrDefault("Kontakt.Opis"),

                HeaderDaneKontaktowe = tresci.GetValueOrDefault("Kontakt.HeaderDaneKontaktowe"),
                Adres = tresci.GetValueOrDefault("Kontakt.Adres"),
                Email = tresci.GetValueOrDefault("Kontakt.Email"),
                Telefon = tresci.GetValueOrDefault("Kontakt.Telefon"),

                HeaderGodzinyOtwarcia = tresci.GetValueOrDefault("Kontakt.HeaderGodzinyOtwarcia"),
                GodzinyOtwarcia = tresci.GetValueOrDefault("Kontakt.Godziny"),

                HeaderZnajdzNas = tresci.GetValueOrDefault("Kontakt.HeaderZnajdzNas"),
                FbLink = tresci.GetValueOrDefault("Kontakt.FbLink"),
                InstagramLink = tresci.GetValueOrDefault("Kontakt.InstagramLink"),
                TwitterLink = tresci.GetValueOrDefault("Kontakt.TwitterLink"),

                HeaderFormularz = tresci.GetValueOrDefault("Kontakt.HeaderFormularz"),
                ImieNazwiskoLabel = tresci.GetValueOrDefault("Kontakt.ImieNazwiskoLabel"),
                EmailLabel = tresci.GetValueOrDefault("Kontakt.EmailLabel"),
                WiadomoscLabel = tresci.GetValueOrDefault("Kontakt.WiadomoscLabel"),
                PrzyciskWyslij = tresci.GetValueOrDefault("Kontakt.ButtonText"),

                MapEmbedUrl = tresci.GetValueOrDefault("Kontakt.MapEmbedUrl")
            };
        }
    }
}
