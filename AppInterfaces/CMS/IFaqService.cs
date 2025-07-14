namespace AppInterfaces.CMS
{
    public class FaqItem
    {
        public string Question { get; set; }
        public string Answer { get; set; }

        public FaqItem(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }
    }

    public interface IFaqService
    {
        Task<IList<FaqItem>> GetFaqItemsAsync();
    }
}
