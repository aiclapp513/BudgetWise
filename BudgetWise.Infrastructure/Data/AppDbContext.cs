using Microsoft.EntityFrameworkCore;
using System;
using BudgetWise.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetWise.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Expense> Expenses => Set<Expense>();
        public DbSet<CreditCard> CreditCards => Set<CreditCard>();
        public DbSet<User> Users => Set<User>();

        // Fix method name: should be OnModelCreating, not OnModelingCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }

}
