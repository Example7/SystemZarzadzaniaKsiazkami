using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppData.Data.CMS
{
    [Index(nameof(Klucz), IsUnique = true)]
    public class TrescStrony
    {
        [Key]
        public int TrescStronyID { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Klucz { get; set; }

        [Required]
        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")]
        public required string Wartosc { get; set; }

        [Display(Name = "Data modyfikacji")]
        public DateTime DataModyfikacji { get; set; } = DateTime.Now;

        [Display(Name = "Osoba modyfikująca")]
        public string? KtoZmienil { get; set; }
    }
}
