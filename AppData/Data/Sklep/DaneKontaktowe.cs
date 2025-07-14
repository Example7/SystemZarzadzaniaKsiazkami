using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppData.Data.Sklep
{
    public class DaneKontaktowe
    {
        [Key, ForeignKey("Uzytkownik")]
        public int UzytkownikID { get; set; }

        [MaxLength(100)]
        public string? Adres { get; set; }

        [MaxLength(10)]
        public string? KodPocztowy { get; set; }

        [MaxLength(50)]
        public string? Miasto { get; set; }

        [Phone]
        [MaxLength(20)]
        public string? Telefon { get; set; }

        public Uzytkownik? Uzytkownik { get; set; }
    }
}
