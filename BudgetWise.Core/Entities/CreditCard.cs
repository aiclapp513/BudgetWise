using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetWise.Core.Entities
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Bank { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime BillingCycleStart { get; set; }
        public DateTime BillingCycleEnd { get; set; }
        public ICollection<Expense> Expenses { get; set; }


    }
}
