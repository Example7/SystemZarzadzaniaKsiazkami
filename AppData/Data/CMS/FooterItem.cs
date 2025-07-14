using System.ComponentModel.DataAnnotations;

namespace AppData.Data.CMS
{
    public class FooterItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Key { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string Content { get; set; } = string.Empty;

        public int Order { get; set; }
    }
}
