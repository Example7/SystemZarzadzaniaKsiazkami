using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppData.Data.Sklep
{
    public enum StatusZamowienia
    {
        Nowe,
        WRealizacji,
        Wyslane,
        Anulowane,
        Zrealizowane
    }

    public class Zamowienie
    {
        [Key]
        public int ZamowienieID { get; set; }

        [Required]
        public DateTime DataZamowienia { get; set; } = DateTime.Now;

        [Required]
        public int UzytkownikID { get; set; }
        public Uzytkownik? Uzytkownik { get; set; }

        public int? KuponID { get; set; }
        public Kupon? Kupon { get; set; }

        [Required]
        public StatusZamowienia Status { get; set; } = StatusZamowienia.Nowe;

        [MaxLength(200)]
        public string? AdresDostawy { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? KwotaCalkowita { get; set; }

        public ICollection<ZamowienieKsiazka> ZamowieniaKsiazki { get; set; } = new List<ZamowienieKsiazka>();
    }
}
