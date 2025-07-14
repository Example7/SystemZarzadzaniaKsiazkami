using System.ComponentModel.DataAnnotations;

namespace AppData.Data.Sklep
{
    public class Kategoria
    {
        [Key]
        public int KategoriaID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nazwa { get; set; } = string.Empty;

        [MaxLength(500)]
        [Display(Name = "Opis kategorii")]
        public string? Opis { get; set; }

        public ICollection<Ksiazka> Ksiazki { get; set; } = new List<Ksiazka>();
    }
}
