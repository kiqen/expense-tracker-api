using Expense_Trackera.Data;
using Expense_Trackera.Models;
using Expense_Trackera.Repositories.Interfaces;

namespace Expense_Trackera.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ExpenseTrackerContext _context;

        public CategoryRepository(ExpenseTrackerContext context)
        {
            _context = context;
        }

        public async Task<Category> AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}