namespace KlientApp.Models
{
    public class RecenzjaViewModel
    {
        public string Tresc { get; set; } = string.Empty;
        public string Autor { get; set; } = "Nieznany";
        public int Ocena { get; set; } = 0;
        public string? KsiazkaTytul { get; set; }
    }
}