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

        // GET: api/expense?startDate=2025-08-01&endDate=2025-08-31&creditCardId=2
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Expense>>> GetExpense(
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] int? creditCardId)
        {
            var expense = _context.Expenses
                .Where(e => !e.IsDeleted)
                .Include(e => e.CreditCard)
                .AsQueryable();

            if (startDate.HasValue)
            {
                expense = expense.Where(e => e.Date >= startDate.Value);
            }
            if (endDate.HasValue)
            {   
                expense = expense.Where(e => e.Date <= endDate.Value);

            }
            if (creditCardId.HasValue)
            {
                expense = expense.Where(e => e.CreditCardId == creditCardId.Value);
            }

            return await expense
                .OrderByDescending(e => e.Date)
                .ToListAsync();
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

        // PUT: api/Expense/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense(int id, [FromBody] ExpenseDto Dto)
        {
            if (Dto == null)
            {
                return BadRequest("Expense data is null.");
            }
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null || expense.IsDeleted)
            {
                return NotFound();
            }
            expense.Name = Dto.Name;
            expense.Amount = Dto.Amount;
            expense.Date = Dto.Date;
            expense.Category = Dto.Category;
            expense.Frequency = Dto.Frequency;
            expense.CreditCardId = Dto.CreditCardId;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
