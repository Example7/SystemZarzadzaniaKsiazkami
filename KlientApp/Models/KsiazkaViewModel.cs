namespace KlientApp.Models
{
    public class KsiazkaViewModel
    {
        public int KsiazkaID { get; set; }
        public string Tytul { get; set; } = string.Empty;
        public string? OkladkaUrl { get; set; }
        public string? Autor { get; set; }
        public decimal Cena { get; set; }
        public double SredniaOcena { get; set; }
    }
}
