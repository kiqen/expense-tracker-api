using Expense_Trackera.Dtos;
using Expense_Trackera.Models;
using Expense_Trackera.Repositories;
using Expense_Trackera.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Expense_Trackera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionsController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> Create(CreateTransactionDto dto)
        {
            var transaction = new Transaction
            {
                Title = dto.Title,
                Amount = dto.Amount,
                Date = dto.Date,
                Type = dto.Type,
                CategoryId = dto.CategoryId
            };

            var createdTransaction = await _transactionRepository.AddAsync(transaction);

            return Ok(createdTransaction);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTransactionDto dto)
        {
            var transaction = new Transaction
            {
                Id = id,
                Title = dto.Title,
                Amount = dto.Amount,
                Date = dto.Date,
                Type = dto.Type,
                CategoryId = dto.CategoryId
            };
            var updated = await _transactionRepository.UpdateAsync(transaction);
            if (!updated)
                return NotFound();

            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetById(int id)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);

            if (transaction == null)
                return NotFound();

            return Ok(transaction);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetAll()
        {
            var transactions = await _transactionRepository.GetAllAsync();
            return Ok(transactions);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _transactionRepository.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();

        }



    }
}