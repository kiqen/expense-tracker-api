namespace Expense_Trackera.Models
{
    public class Transaction
    {
        public int Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateOnly Date { get; set; }
        public string Type { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;


    }
}
