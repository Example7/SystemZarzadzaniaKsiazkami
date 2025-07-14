using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppData.Data.Sklep
{
    public class ZamowienieKsiazka
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ZamowienieID { get; set; }
        public Zamowienie? Zamowienie { get; set; }

        [Required]
        public int KsiazkaID { get; set; }
        public Ksiazka? Ksiazka { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Ilość musi być większa niż 0")]
        public int Ilosc { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CenaJednostkowa { get; set; }
    }
}
