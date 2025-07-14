using AppData.Data.CMS;

namespace KlientApp.Models
{
    public class KontoViewModel
    {
        public string Email { get; set; } = "";
        public DateTime? DataRejestracji { get; set; }
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }

        public List<Aktualnosc> News { get; set; } = new List<Aktualnosc>();

        public string? NaglowekTwojeDane { get; set; }
        public string? NaglowekAktualnosci { get; set; }
        public string? NaglowekFaq { get; set; }
    }
}
