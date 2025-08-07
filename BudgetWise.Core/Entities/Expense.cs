using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetWise.Core.Entities
{
    public class Expense
    {
        public int Id { get; set; }     
        public string? Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Category { get; set; }
        public string? Frequency { get; set; }
        public bool IsDeleted { get; set; }
        public int CreditCardId { get; set; }
        public CreditCard? CreditCard { get; set; }





    }
}
