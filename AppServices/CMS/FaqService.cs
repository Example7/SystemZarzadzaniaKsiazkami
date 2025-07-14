using AppInterfaces.CMS;
using Microsoft.EntityFrameworkCore;
using AppServices.Abstrakcja;

namespace AppServices.CMS
{
    public class FaqService : BaseService, IFaqService
    {
        public FaqService(AppData.Data.AppContext context) : base(context) { }

        public async Task<IList<FaqItem>> GetFaqItemsAsync()
        {
            var faqEntries = await _context.TrescStrony
                .Where(t => t.Klucz.StartsWith("faq_"))
                .OrderBy(t => t.Klucz)
                .ToListAsync();

            var faqItems = new List<FaqItem>();

            var grouped = faqEntries.GroupBy(entry =>
            {
                var parts = entry.Klucz.Split('_');
                return parts.Length >= 3 ? parts[1] : null;
            });

            foreach (var group in grouped)
            {
                if (group.Key == null) continue;

                var questionEntry = group.FirstOrDefault(e => e.Klucz.EndsWith("_pytanie"));
                var answerEntry = group.FirstOrDefault(e => e.Klucz.EndsWith("_odpowiedz"));

                if (questionEntry != null && answerEntry != null)
                {
                    faqItems.Add(new FaqItem(questionEntry.Wartosc, answerEntry.Wartosc));
                }
            }

            return faqItems;
        }
    }
}
