using Expense_Trackera.Data;
using Expense_Trackera.Models;
using Expense_Trackera.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


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

        public async Task<bool> UpdateAsync(Category category)
        {
            var existingCategory = await _context.Categories.FindAsync(category.Id);

            if (existingCategory == null)
                return false;

            existingCategory.Name = category.Name;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }



    }
}