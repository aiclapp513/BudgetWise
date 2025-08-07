using BudgetWise.Core.Entities;
using BudgetWise.Infrastructure.Data;
using BudgetWise.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BudgetWise.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ExpenseController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Expense
        [HttpPost]
        public async Task<IActionResult> CreateExpense([FromBody] ExpenseDto Dto)
        {
            if (Dto == null)
            {
                return BadRequest("Expense data is null.");
            }
            var expense = new Expense
            {
                Name = Dto.Name,
                Amount = Dto.Amount,
                Date = Dto.Date,
                Category = Dto.Category,
                Frequency = Dto.Frequency,
                CreditCardId = Dto.CreditCardId
            };
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetExpense), new { id = expense.Id }, expense);

            }

        // GET: api/Expense/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expense>> GetExpense(int id)
        {
            var expense = await _context.Expenses
                .Include(e => e.CreditCard)
                .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
            if (expense == null)
            {
                return NotFound();
            }
            
            return expense;
        }

        //Delete: api/Expense/5 (soft delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteExpense(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null || expense.IsDeleted)
            {
                return NotFound();
            }
            // Soft delete
            expense.IsDeleted = true;
            
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
