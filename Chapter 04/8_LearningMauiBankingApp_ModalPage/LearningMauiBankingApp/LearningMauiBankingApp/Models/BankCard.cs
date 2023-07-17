namespace LearningMauiBankingApp.Models
{
	public class BankCard
	{
        public string Alias { get; }
		public long CardNumber { get; }
		public DateTime ExpirationDate { get; }
		public decimal Balance { get; }

        public BankCard(string alias, long cardNumber, DateTime expirationDate, decimal balance)
        {
            Alias = alias;
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
            Balance = balance;
        }
    }
}

