using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetWise.Shared.DTO
{
    public class ExpenseDto
    {
        
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Category { get; set; }
        public string? Frequency { get; set; } 
        public int CreditCardId { get; set; }
    }
}
