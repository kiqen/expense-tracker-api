using System.ComponentModel.DataAnnotations;

namespace Expense_Trackera.Dtos
{
    public class UpdateTransactionDto
    {
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title can have max 100 characters")]
        public string Title { get; set; } = string.Empty;
        [Range(typeof(decimal), "0,01", "999999999,99", ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Date is required")]

        public DateOnly Date { get; set; }
        [Required(ErrorMessage = "Type is required")]
        [MaxLength(20, ErrorMessage = "Type can have max 20 characters")]

        public string Type { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage = "CategoryId must be greater than 0")]

        public int CategoryId { get; set; }

    }
}
