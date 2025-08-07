using BudgetWise.Core.Entities;
using BudgetWise.Infrastructure.Data;
using BudgetWise.Shared.DTO;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetWise.API.Controllers
{
    
        // This controller is intentionally left empty for now.
        // You can implement CRUD operations for CreditCard entity here in the future.
        [ApiController]
        [Route("api/[controller]")]
        public class CreditCardController : ControllerBase
        {
            private readonly AppDbContext _context;
            public CreditCardController(AppDbContext context)
            {
                _context = context;
            }
            // POST: api/CreditCard
            [HttpPost]
            public async Task<IActionResult> AddCard([FromBody] CreditCardDto dto)
            {
                if (dto == null)
                {
                    return BadRequest("Credit card data is null.");
                }
                var creditCard = new CreditCard
                {
                    Name = dto.Name,
                    Bank = dto.Bank,
                    CurrentBalance = dto.CurrentBalance,
                    BillingCycleStart = dto.BillingCycleStart,
                    BillingCycleEnd = dto.BillingCycleEnd
                };
                _context.CreditCards.Add(creditCard);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCard), new { id = creditCard.Id }, creditCard);
            }
            // GET: api/CreditCard/5
            [HttpGet]
            public async Task<ActionResult<IEnumerable<CreditCard>>> GetAllCards()
            {
            return await _context.CreditCards
                .Where(c => !c.IsDeleted)
                .Include(c => c.Expenses)
                .ToListAsync();

        }
        // GET: api/CreditCard/5
        [HttpGet("{id}")]
            public async Task<ActionResult<CreditCard>> GetCard(int id)
            {
                var creditCard = await _context.CreditCards
                    .Include(c => c.Expenses)
                    .FirstOrDefaultAsync(c => c.Id == id && c.IsDeleted);
                if (creditCard == null)
                {
                    return NotFound();
                }
                return creditCard;
        }
        // DELETE: api/CreditCard/5 (soft delete)
        [HttpDelete("{id}")]
            public async Task<IActionResult> SoftDeleteCreditCard(int id)
            {
                var creditCard = await _context.CreditCards.FindAsync(id);
                if (creditCard == null || creditCard.IsDeleted)
                {
                    return NotFound();
                }
                creditCard.IsDeleted = true;
                await _context.SaveChangesAsync();
                return NoContent();
            }
        // PUT: api/CreditCard/5
        [HttpPut("{id}")]
            public async Task<IActionResult> UpdateCreditCard(int id, [FromBody] CreditCardDto dto)
            {
                if (dto == null)
                {
                    return BadRequest("Credit card data is null.");
                }
                var creditCard = await _context.CreditCards.FindAsync(id);
                if (creditCard == null || creditCard.IsDeleted)
                {
                    return NotFound();
                }
                creditCard.Name = dto.Name;
                creditCard.Bank = dto.Bank;
                creditCard.CurrentBalance = dto.CurrentBalance;
                creditCard.BillingCycleStart = dto.BillingCycleStart;
                creditCard.BillingCycleEnd = dto.BillingCycleEnd;
                _context.CreditCards.Update(creditCard);
                await _context.SaveChangesAsync();
                return NoContent();
        }
    }
}
