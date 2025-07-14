public class ONasDTO
{
    public string? Naglowek { get; set; }
    public string? Akapit1 { get; set; }
    public string? Akapit2 { get; set; }
    public string? Cytat { get; set; }
    public string? CytatAutor { get; set; }
    public string? SectionValuesHeader { get; set; }
    public string? ContactButtonText { get; set; }

    public List<ONasWartoscDTO> Wartosci { get; set; } = new();
    public List<ONasStatystykaDTO> Statystyki { get; set; } = new();
}

public class ONasWartoscDTO
{
    public string? Tytul { get; set; }
    public string? Tresc { get; set; }
}

public class ONasStatystykaDTO
{
    public string? Liczba { get; set; }
    public string? Opis { get; set; }
}
