public class ONasViewModel
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