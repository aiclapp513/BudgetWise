using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetWise.Shared.DTO
{
    public class CreditCardDto
    {
        public string Name { get; set; } = string.Empty;
        public string Bank { get; set; } = string.Empty;
        public decimal CurrentBalance { get; set; }
        public DateTime BillingCycleStart { get; set; }
        public DateTime BillingCycleEnd { get; set; }

    }
}
