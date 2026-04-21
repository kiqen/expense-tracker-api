using Expense_Trackera.Models;

namespace Expense_Trackera.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction> AddAsync(Transaction transaction);
        Task<bool> UpdateAsync(Transaction transaction);
        Task<List<Transaction>> GetAllFilteredAsync(int? categoryId,string? type,DateOnly? dateFrom,DateOnly? dateTo); Task<Transaction?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> AnyByCategoryIdAsync(int categoryId);



    }
}