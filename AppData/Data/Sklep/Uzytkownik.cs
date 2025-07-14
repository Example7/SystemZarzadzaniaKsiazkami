using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AppData.Data.Sklep
{
    [Index(nameof(Email), IsUnique = true)]
    public class Uzytkownik
    {
        [Key]
        public int UzytkownikID { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string HasloHash { get; set; } = string.Empty;

        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }

        public bool CzyAdmin { get; set; } = false;

        public DateTime DataRejestracji { get; set; } = DateTime.Now;

        public DaneKontaktowe? DaneKontaktowe { get; set; }

        public ICollection<Zamowienie> Zamowienia { get; set; } = new List<Zamowienie>();
        public ICollection<Recenzja> Recenzje { get; set; } = new List<Recenzja>();
    }
}
