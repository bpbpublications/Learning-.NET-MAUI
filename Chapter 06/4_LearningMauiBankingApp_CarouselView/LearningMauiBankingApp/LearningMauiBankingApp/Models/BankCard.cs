using System.ComponentModel;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Tools;
using LiteDB;

namespace LearningMauiBankingApp.Models
{
	public class BankCard : NotifyPropertyChangedBase, ILocalStorageItem
    {
        [BsonId]
        public ObjectId LocalStorageId { get; set; }

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
            _balance = balance;
        }

        [BsonCtor]
        public BankCard(ObjectId localStorageId, string alias, long cardNumber, DateTime expirationDate, decimal balance)
            : this(alias, cardNumber, expirationDate, balance)
        {
            LocalStorageId = localStorageId;
        }
    }
}

