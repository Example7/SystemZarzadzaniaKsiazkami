using KlientApp.Models;

public class KsiazkiViewModel
{
    public string Naglowek { get; set; } = string.Empty;
    public IList<KsiazkaViewModel> Ksiazki { get; set; } = new List<KsiazkaViewModel>();
}
