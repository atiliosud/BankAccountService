using System;
using BankAccountService.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BankAccountService.Infrastructure.Context
{
    public class BankServiceContext : DbContext
    {
        public BankServiceContext(DbContextOptions<BankServiceContext> options)
        : base(options)
        {
        }

        public DbSet<CheckingAccount> CheckingAccount { get; set; }
        public DbSet<SavingsAccount> SavingsAccount { get; set; }
    }
}
