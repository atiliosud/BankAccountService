using System;
using System.ComponentModel.DataAnnotations;
using BankAccountService.Domain.Interface;

namespace BankAccountService.Domain.Model
{
    public class Transaction : IEntity
    {
        [Key]
        public int Id { get; set; }
        public TransactionType TType { get; set; }
        public OperationType Operation { get; set; }
        public decimal Amount { get; }
        public DateTime Date { get; }

        public int MainAccountId { get; set; }
        public BankAccount MainAccount { get; set; }
        public int SourceAccountId { get; set; }
        public BankAccount SourceAccount { get; set; }
        public int DestinationAccountId { get; set; }
        public BankAccount DestinationAccount { get; set; }

        public Transaction(decimal amount, DateTime date)
        {
            this.Amount = amount;
            this.Date = date;
        }
    }
}

