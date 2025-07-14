using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppData.Data.Sklep
{
    public class Ksiazka
    {
        [Key]
        public int KsiazkaID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Tytul { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string ISBN { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 10000)]
        public decimal Cena { get; set; }

        [MaxLength(1000)]
        public string? Opis { get; set; }

        public DateTime? DataWydania { get; set; }

        public string? OkladkaUrl { get; set; }

        public int AutorID { get; set; }
        public Autor? Autor { get; set; }

        public int WydawnictwoID { get; set; }
        public Wydawnictwo? Wydawnictwo { get; set; }

        public int KategoriaID { get; set; }
        public Kategoria? Kategoria { get; set; }

        public ICollection<ZamowienieKsiazka> ZamowieniaKsiazki { get; set; } = new List<ZamowienieKsiazka>();
        public ICollection<Recenzja> Recenzje { get; set; } = new List<Recenzja>();
    }
}
