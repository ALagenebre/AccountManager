namespace Domain
{
    public class Account
    {
        public double Amount { get; private set; }
        public string Currency { get; private set; }
        public IList<ExchangeRate> ExchangeRates { get; private set; }
        public IList<Transaction> Transactions { get; private set; }

        public Account(double amount, string currency, IList<ExchangeRate> exchangeRates, IList<Transaction> transactions)
        {
            Amount = amount;
            Currency = currency;
            ExchangeRates = exchangeRates;
            Transactions = transactions;
        }
    }
}
