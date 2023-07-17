using System;
namespace LearningMauiBankingApp.Models
{
	public class TransferModalPageNavigationParameter
	{
		public IEnumerable<BankCard> BankCards { get; }
		public long FromCardNumber { get; }

		public TransferModalPageNavigationParameter(IEnumerable<BankCard> bankCards, long fromCardNumber = 0)
		{
			BankCards = bankCards;
            FromCardNumber = fromCardNumber;
        }
	}
}

