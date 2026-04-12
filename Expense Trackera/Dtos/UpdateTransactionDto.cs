namespace Expense_Trackera.Dtos
{
    public class UpdateTransactionDto
    {
        public string Title { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } = string.Empty;
        public int CategoryId { get; set; }

    }
}
