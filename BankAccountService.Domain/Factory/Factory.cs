using System;
using System.Collections.Generic;
using System.Text;
using BankAccountService.Domain.Interface;
using BankAccountService.Domain.Model;

namespace BankAccountService.Domain.Factory
{
    public static class Factory
    {
        public static IAccount CreateObject(FactoryObject factoryObject)
        {
            IAccount objIAccount = null;

            switch (factoryObject)
            {
                case FactoryObject.SavingAccount:
                    objIAccount = new SavingsAccount();
                    break;

                case FactoryObject.CheckingAccount:
                    objIAccount = new CheckingAccount();
                    break;

                default:
                    break;
            }

            return objIAccount;
        }
    }
}
