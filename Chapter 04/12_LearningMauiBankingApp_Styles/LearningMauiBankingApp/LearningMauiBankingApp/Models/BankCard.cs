using LearningMauiBankingApp.Tools;

namespace LearningMauiBankingApp.Models
{
	public class BankCard : NotifyPropertyChangedBase
    {
        public string Alias { get; }
		public long CardNumber { get; }
		public DateTime ExpirationDate { get; }

        private decimal _balance;
		public decimal Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                OnPropertyChanged(nameof(Balance));
            }
        }

        public BankCard(string alias, long cardNumber, DateTime expirationDate, decimal balance)
        {
            Alias = alias;
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
            Balance = balance;
        }
    }
}

