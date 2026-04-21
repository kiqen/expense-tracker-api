using Expense_Trackera.Dtos;
using Expense_Trackera.Models;
using Expense_Trackera.Repositories;
using Expense_Trackera.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Expense_Trackera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITransactionRepository _transactionRepository;


        public CategoriesController(ICategoryRepository categoryRepository, ITransactionRepository transactionRepository)
        {
            _categoryRepository = categoryRepository;
            _transactionRepository = transactionRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Create(CreateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name
            };

            var createdCategory = await _categoryRepository.AddAsync(category);

            return Ok(createdCategory);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCategoryDto dto)
        {
            var category = new Category
            {
                Id = id,
                Name = dto.Name
            };

            var updated = await _categoryRepository.UpdateAsync(category);

            if (!updated)
                return NotFound();

            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            return Ok(category);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var hasTransactions = await _transactionRepository.AnyByCategoryIdAsync(id);

            if (hasTransactions)
            {
                return BadRequest("Cannot delete category with assigned transactions");
            }
            var deleted = await _categoryRepository.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();



        }



    }
}