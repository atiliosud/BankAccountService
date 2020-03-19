using System;
using System.Collections.Generic;
using System.Text;
using BankAccountService.Domain.Model;
using BankAccountService.Domain.Model.Repository;
using BankAccountService.Infrastructure.Context;

namespace BankAccountService.Infrastructure.Repository
{
    public class SavingsAccountRepository : Repository<SavingsAccount>, ISavingsAccountRepository
    {
        public SavingsAccountRepository(BankServiceContext context) : base(context)
        {

        }
    }
}
