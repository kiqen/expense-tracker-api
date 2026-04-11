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

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
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
    }
}