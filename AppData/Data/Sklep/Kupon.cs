using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppData.Data.Sklep
{
    public enum TypZnizki
    {
        Procentowa,
        Kwotowa
    }

    public class Kupon
    {
        [Key]
        public int KuponID { get; set; }

        [Required]
        [MaxLength(20)]
        public string Kod { get; set; } = string.Empty;

        [Required]
        public TypZnizki TypZnizki { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, 10000)]
        public decimal WartoscZnizki { get; set; }

        [Required]
        public DateTime DataWaznosci { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? MinimalnaWartosc { get; set; }

        public bool CzyAktywny { get; set; } = true;

        public ICollection<Zamowienie> Zamowienia { get; set; } = new List<Zamowienie>();
    }
}
