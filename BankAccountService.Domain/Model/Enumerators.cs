using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountService.Domain.Model
{
    public enum AccountType
    {
        SavingAccount,
        CheckingAccount
    }

    public enum TransactionType
    {
        CCtoCC,
        CCtoSV
    }

    public enum OperationType
    {
        Withdraw,
        Deposit,
        Transfer
    }
}
