using Expense_Trackera.Models;

namespace Expense_Trackera.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction> AddAsync(Transaction transaction);
    }
}