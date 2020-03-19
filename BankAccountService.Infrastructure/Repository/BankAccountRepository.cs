using System;
using System.Collections.Generic;
using System.Text;
using BankAccountService.Domain.Interface;
using BankAccountService.Domain.Model;
using BankAccountService.Domain.Model.Repository;
using BankAccountService.Infrastructure.Context;

namespace BankAccountService.Infrastructure.Repository
{
    public class BankAccountRepository : Repository<BankAccount>, IBankAccountRepository
    {
        public BankAccountRepository(BankServiceContext context) : base(context)
        {

        }
    }
}
