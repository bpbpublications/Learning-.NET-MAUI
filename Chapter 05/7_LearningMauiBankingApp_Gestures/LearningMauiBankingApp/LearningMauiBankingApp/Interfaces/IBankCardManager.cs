using System;
using LearningMauiBankingApp.Models;

namespace LearningMauiBankingApp.Interfaces
{
	public interface IBankCardManager
	{
		Task<IEnumerable<BankCard>> GetBankCardsAsync();
	}
}

