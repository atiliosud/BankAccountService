using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BankAccountService.Domain.Interface;

namespace BankAccountService.Domain.Model
{
    public abstract class Account:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { get; }
    }
}
