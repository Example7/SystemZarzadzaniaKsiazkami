using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AppData.Data.Sklep
{
    [Index(nameof(Nazwa), IsUnique = true)]
    public class Wydawnictwo
    {
        [Key]
        public int WydawnictwoID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nazwa { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Opis { get; set; }

        public ICollection<Ksiazka> Ksiazki { get; set; } = new List<Ksiazka>();
    }
}
