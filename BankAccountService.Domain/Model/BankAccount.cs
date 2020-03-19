using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BankAccountService.Domain.Interface;

namespace BankAccountService.Domain.Model
{
    public class BankAccount : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        public string Owner { get; set; }
        public decimal Balance { get; set; }
        public DateTime Date { get; set; }
       
        public List<Transaction> Transactions = new List<Transaction>();

        public void MakeWithdrawal(decimal amount, DateTime date)
        {
            try
            {
                if (amount <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
                }
                if (Balance - amount < 0)
                {
                    throw new InvalidOperationException("Not sufficient funds for this withdrawal");
                }
                this.Balance -= amount;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MakeDeposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            this.Balance += amount;
        }

        public void MakeTransfer(decimal amount, BankAccount destination)
        {
            if (this.Balance <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of transfer must be positive");
            }
            if (this.Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this transfer");
            }
            this.Balance -= amount;
            destination.Balance += amount;
        }


        public bool Validate(decimal amount)
        {
            if (this.Balance <= 0)
            {
                return false;
            }
            if (this.Balance - amount < 0)
            {
                return false;
            }
            return true;
        }
    }
}
