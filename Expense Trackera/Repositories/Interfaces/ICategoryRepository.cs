using Expense_Trackera.Models;

namespace Expense_Trackera.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> AddAsync(Category category);
    }

}
