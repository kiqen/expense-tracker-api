using Expense_Trackera.Data;
using Expense_Trackera.Models;
using Expense_Trackera.Repositories.Interfaces;

namespace Expense_Trackera.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ExpenseTrackerContext _context;

        public TransactionRepository(ExpenseTrackerContext context)
        {
            _context = context;
        }

        public async Task<Transaction> AddAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }
    }
}