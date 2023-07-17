using System;
using System.ComponentModel;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Models;
using LiteDB;

namespace LearningMauiBankingApp.Services
{
    public class DummyBankCardManager : IBankCardManager
    {
        private readonly ILocalStorage _localStorage;

        public event EventHandler<IEnumerable<BankCard>> BankCardsChanged;

        public DummyBankCardManager(ILocalStorage localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task<IEnumerable<BankCard>> GetBankCardsAsync()
        {
            var localStorageCards =_localStorage.GetAll<BankCard>();

            if (localStorageCards is null || !localStorageCards.Any())
            {
                localStorageCards = CreateDummyCards();
                _localStorage.Insert(localStorageCards);
            }

            return await Task.FromResult(localStorageCards);
        }

        public Task<bool> TryMakeTransferAsync(BankCard fromCard, BankCard toCard, decimal valueToTransfer)
        {
            if (fromCard.Balance < valueToTransfer)
                return Task.FromResult(false);

            var storageFromCard = _localStorage.FirstOrDefault<BankCard>(x => x.LocalStorageId == fromCard.LocalStorageId);
            if (storageFromCard is null)
                return Task.FromResult(false);

            var storageToCard = _localStorage.FirstOrDefault<BankCard>(x => x.LocalStorageId == toCard.LocalStorageId);
            if (storageFromCard is null)
                return Task.FromResult(false);

            storageFromCard.Balance -= valueToTransfer;
            storageToCard.Balance += valueToTransfer;

            _localStorage.Update(storageFromCard);
            _localStorage.Update(storageToCard);
            var localStorageCards = _localStorage.GetAll<BankCard>();

            BankCardsChanged?.Invoke(this, localStorageCards);
            return Task.FromResult(true);
        }

        private IEnumerable<BankCard> CreateDummyCards()
        {
            return new List<BankCard>
            {
                new BankCard("Main card", 1882824500100505, new DateTime(2029, 5, 1), 3253.45m),
                new BankCard("Emergency card", 4004799964524057, new DateTime(2028, 2, 1), 8500m),
                new BankCard("Savings card", 4576241367871031, new DateTime(2025, 10, 1), 4300m),
            };
        }
    }
}

