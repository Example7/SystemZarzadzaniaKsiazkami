namespace KlientApp.Models
{
    public class SearchSortViewModel
    {
        public string? Search { get; set; }
        public string? Sort { get; set; }
        public Dictionary<string, string>? SortOptions { get; set; }
    }
}
