namespace Domain
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string Category { get; set; }

        public Transaction(DateTime date, double amount, string currency, string category)
        {
            Date = date;
            Amount = amount;
            Currency = currency;
            Category = category;
        }
    }
}
