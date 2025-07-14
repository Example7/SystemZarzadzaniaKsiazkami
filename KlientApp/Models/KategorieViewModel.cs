using AppData.Data.Sklep;

public class KategorieViewModel
{
    public required IEnumerable<Kategoria> Kategorie { get; set; }
    public string? Naglowek { get; set; }
}
