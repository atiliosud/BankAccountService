using System;
using BankAccountService.Domain.Interface;

namespace BankAccountService.Domain.Model
{
    public class SavingsAccount : Account, IAccount
    {
        public string Withdraw(int amount)
        {
            throw new NotImplementedException();
        }

        public string Deposit(int amount)
        {
            throw new NotImplementedException();
        }

        public double InterestRate()
        {
            return 12.5;
        }
    }
}
