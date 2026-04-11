using Expense_Trackera.Dtos;
using Expense_Trackera.Models;
using Expense_Trackera.Repositories;
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
    }
}