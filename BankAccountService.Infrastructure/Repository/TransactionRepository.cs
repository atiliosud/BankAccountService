using System;
using System.Collections.Generic;
using System.Text;
using BankAccountService.Domain.Model;
using BankAccountService.Domain.Model.Repository;
using BankAccountService.Infrastructure.Context;

namespace BankAccountService.Infrastructure.Repository
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(BankServiceContext context) : base(context)
        {

        }
    }
}
