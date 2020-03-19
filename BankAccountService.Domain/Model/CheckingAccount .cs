using System;
using System.ComponentModel.DataAnnotations;
using BankAccountService.Domain.Interface;

namespace BankAccountService.Domain.Model
{
    public class CheckingAccount : Account, IAccount
    {
        #region IAccount Members
    
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
            return 10.24;
        }

        #endregion
    }
}

