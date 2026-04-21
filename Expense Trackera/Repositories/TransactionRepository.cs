using Expense_Trackera.Data;
using Expense_Trackera.Models;
using Expense_Trackera.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        public async Task<bool> UpdateAsync(Transaction transaction)
        {
            var existingTransaction = await _context.Transactions.FindAsync(transaction.Id);

            if (existingTransaction == null)
                return false;

            existingTransaction.Title = transaction.Title;
            existingTransaction.Amount = transaction.Amount;
            existingTransaction.Date = transaction.Date;
            existingTransaction.Type = transaction.Type;
            existingTransaction.CategoryId = transaction.CategoryId;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<Transaction>> GetAllFilteredAsync(int? categoryId,string? type,DateOnly? dateFrom,DateOnly? dateTo)
        {
            var query = _context.Transactions
                .Include(t => t.Category)
                .AsQueryable();

            if (categoryId.HasValue)
            {
                query = query.Where(t => t.CategoryId == categoryId.Value);
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                query = query.Where(t => t.Type == type);
            }

            if (dateFrom.HasValue)
            {
                query = query.Where(t => t.Date >= dateFrom.Value);
            }

            if (dateTo.HasValue)
            {
                query = query.Where(t => t.Date <= dateTo.Value);
            }

            return await query.ToListAsync();
        }
        public async Task<Transaction?> GetByIdAsync(int id)
        {
            return await _context.Transactions
                .Include(t => t.Category)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null) 
                return false;
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return true;


        }

        public async Task<bool> AnyByCategoryIdAsync(int categoryId)
        {
            return await _context.Transactions.AnyAsync(t => t.CategoryId == categoryId);
        }
    }
}