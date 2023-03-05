using Domain;

namespace Accounting
{
    public class AccountManager
    {
        private Account Account { get; set; }

        public AccountManager(Account account)
        {
            Account = account;
        }

        public double GetAccountAmount(DateTime dateTime)
        {
            if (Account == null)
            {
                return 0;
            }

            var amount = Account.Amount;

            foreach (var transaction in Account.Transactions.Where(t => t.Date > dateTime))
            {
                var amountToSubstract = GetAmountToSubtract(transaction);
                amount -= amountToSubstract;
            }

            return amount;
        }

        private double GetAmountToSubtract(Transaction transaction)
        {
            var amount = transaction.Amount;

            if (transaction.Currency != Account.Currency)
            {
                var exchangeRate = Account.ExchangeRates.Single(t => t.Currency == transaction.Currency);

                amount *= exchangeRate.Rate;
            }

            return amount;
        }
    }
}
