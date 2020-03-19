using BankAccountService.API.Controllers;
using BankAccountService.Domain.Model;
using NUnit.Framework;

namespace BankAccountService.Tests
{
    [TestFixture]
    public class BankAccountTest
    {
        private BankAccount _bankAccount;

        [SetUp]
        public void Setup()
        {
            _bankAccount = new BankAccount();
        }

        [Test]
        public void IsAmount_ReturnFalse()
        {
            _bankAccount.Balance = 10;
            var result = _bankAccount.Validate(15);
            Assert.IsFalse(result, "Ammount cannot be greater than account balance");
        }

        [Test]
        public void IsBalance_ReturnFalse()
        {
            _bankAccount.Balance = 0;
            var result = _bankAccount.Validate(0);
            Assert.IsFalse(result, "Balance cannot be 0");
        }
    }
}