using Accounting;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AccountManagerTest
{
    [TestClass]
    public class AccountManagerTest
    {
        private readonly double _defaultAmount = 8300;
        private readonly string _defaultCurrency = "EUR";
        private readonly string _defaultCategory = "Loisir";
        private readonly IList<ExchangeRate> _defaultExchangeRates = new List<ExchangeRate> { { new ExchangeRate("JPY", 0.482) }, { new ExchangeRate("USD", 1.445) } };

        [TestMethod]
        public void Return_0_When_No_Account()
        {
            // Arrange
            var dateTime = new DateTime(2023, 02, 28);
            var accountManager = new AccountManager(null);
            var expectedMoney = 0;

            // Act
            var money = accountManager.GetAccountAmount(dateTime);

            // Assert
            Assert.AreEqual(expectedMoney, money);

        }

        [TestMethod]
        public void Return_8300_When_No_Operation()
        {
            // Arrange
            var dateTime = new DateTime(2023, 02, 28);
            var account = new Account(_defaultAmount, _defaultCurrency, _defaultExchangeRates, new List<Transaction>());
            var accountManager = new AccountManager(account);
            var expectedMoney = 8300;

            // Act
            var money = accountManager.GetAccountAmount(dateTime);

            // Assert
            Assert.AreEqual(expectedMoney, money);

        }

        [TestMethod]
        public void Return_8804_61_When_One_Transaction()
        {
            // Arrange
            var dateTime = new DateTime(2022, 10, 5);
            var transactions = new List<Transaction> { { new Transaction(new DateTime(2022, 10, 6), -504.61, _defaultCurrency, _defaultCategory) } };
            var account = new Account(_defaultAmount, _defaultCurrency, _defaultExchangeRates, transactions);
            var accountManager = new AccountManager(account);
            var expectedMoney = 8804.61;

            // Act
            var money = accountManager.GetAccountAmount(dateTime);

            // Assert
            Assert.AreEqual(expectedMoney, money);

        }

        [TestMethod]
        public void Return_8804_61_When_Two_Operations_And_DateTime_Is_Between()
        {
            // Arrange
            var dateTime = new DateTime(2022, 10, 5);
            var transactions = new List<Transaction> { { new Transaction(new DateTime(2022, 10, 6), -504.61, _defaultCurrency, _defaultCategory) }, { new Transaction(new DateTime(2022, 10, 1), 100, _defaultCurrency, _defaultCategory) } };
            var account = new Account(_defaultAmount, _defaultCurrency, _defaultExchangeRates, transactions);
            var accountManager = new AccountManager(account);
            var expectedMoney = 8804.61;

            // Act
            var money = accountManager.GetAccountAmount(dateTime);

            // Assert
            Assert.AreEqual(expectedMoney, money);

        }

        [TestMethod]
        public void Return_8348_2_When_One_Transaction_In_JPY()
        {
            // Arrange
            var dateTime = new DateTime(2022, 10, 5);
            var transactions = new List<Transaction> { { new Transaction(new DateTime(2022, 10, 6), -100, "JPY", _defaultCategory) } };
            var account = new Account(_defaultAmount, _defaultCurrency, _defaultExchangeRates, transactions);
            var accountManager = new AccountManager(account);
            var expectedMoney = 8348.2;

            // Act
            var money = accountManager.GetAccountAmount(dateTime);

            // Assert
            Assert.AreEqual(expectedMoney, money);

        }
    }
}