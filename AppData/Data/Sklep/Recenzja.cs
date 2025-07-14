using System.ComponentModel.DataAnnotations;

namespace AppData.Data.Sklep
{
    public class Recenzja
    {
        [Key]
        public int RecenzjaID { get; set; }

        [Required]
        [Range(1, 5)]
        public int Ocena { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Tresc { get; set; } = string.Empty;

        [Required]
        public DateTime DataDodania { get; set; } = DateTime.Now;

        [Required]
        public int KsiazkaID { get; set; }
        public Ksiazka? Ksiazka { get; set; }

        [Required]
        public int UzytkownikID { get; set; }
        public Uzytkownik? Uzytkownik { get; set; }
    }
}
