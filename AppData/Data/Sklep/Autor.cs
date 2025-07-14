using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppData.Data.Sklep
{
    public class Autor
    {
        [Key]
        public int AutorID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Imie { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Nazwisko { get; set; } = string.Empty;

        [NotMapped]
        public string ImieNazwisko => $"{Imie} {Nazwisko}";

        public ICollection<Ksiazka> Ksiazki { get; set; } = new List<Ksiazka>();
    }
}
