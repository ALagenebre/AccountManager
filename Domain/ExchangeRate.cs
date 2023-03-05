namespace Domain
{
    public class ExchangeRate
    {
        public string Currency { get; private set; }
        public double Rate { get; private set; }

        public ExchangeRate(string currency, double rate)
        {
            Currency = currency;
            Rate = rate;
        }
    }
}
