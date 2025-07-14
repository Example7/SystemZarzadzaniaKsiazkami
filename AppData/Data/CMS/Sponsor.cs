using System.ComponentModel.DataAnnotations;

namespace AppData.Data.CMS
{
    public class Sponsor
    {
        [Key]
        public int SponsorID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nazwa { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Opis { get; set; }

        public string? LogoUrl { get; set; }

        public DateTime? DataRozpoczeciaWspolpracy { get; set; }

        public DateTime? DataZakonczeniaWspolpracy { get; set; }
    }
}
