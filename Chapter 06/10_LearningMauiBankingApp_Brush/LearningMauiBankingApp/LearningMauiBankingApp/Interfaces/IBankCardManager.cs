using System;
using LearningMauiBankingApp.Models;

namespace LearningMauiBankingApp.Interfaces
{
	public interface IBankCardManager
	{
        event EventHandler<IEnumerable<BankCard>> BankCardsChanged;
        Task<IEnumerable<BankCard>> GetBankCardsAsync();
		Task<bool> TryMakeTransferAsync(BankCard fromCard, BankCard toCard, decimal valueToTransfer);

    }
}

