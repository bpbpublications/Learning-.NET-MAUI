using System;
namespace LearningMauiBankingApp.Models
{
	public class TransferModalPageNavigationParameter
	{
		public long FromCardNumber { get; }

		public TransferModalPageNavigationParameter(long fromCardNumber = 0)
		{
            FromCardNumber = fromCardNumber;
        }
	}
}

