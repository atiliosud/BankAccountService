using System;
using System.Collections.Generic;
using System.Text;
using BankAccountService.Domain.Model;
using BankAccountService.Domain.Model.Repository;
using BankAccountService.Infrastructure.Context;

namespace BankAccountService.Infrastructure.Repository
{
    public class CheckingAccountRepository : Repository<CheckingAccount>, ICheckingAccountRepository
    {
        public CheckingAccountRepository(BankServiceContext context) : base(context)
        {

        }
    }
}
