using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountService.Domain.Interface
{
    public interface IAccount
    {
        string Withdraw(int amount);
        string Deposit(int amount);
        double InterestRate();
    }
}
