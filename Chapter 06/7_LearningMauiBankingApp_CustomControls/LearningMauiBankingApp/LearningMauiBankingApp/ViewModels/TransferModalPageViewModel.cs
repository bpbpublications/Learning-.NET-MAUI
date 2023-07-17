using System;
using System.Windows.Input;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Models;
using LearningMauiBankingApp.Tools;

namespace LearningMauiBankingApp.ViewModels
{
	public class TransferModalPageViewModel : ViewModelBase, IInitialize<TransferModalPageNavigationParameter>
    {
        private readonly IBankCardManager _bankCardManager;

        private IEnumerable<BankCard> _cards;
        public IEnumerable<BankCard> Cards
        {
            get => _cards;
            set
            {
                _cards = value;
                OnPropertyChanged(nameof(Cards));
            }
        }

        private BankCard _selectedFromCard;
        public BankCard SelectedFromCard
        {
            get => _selectedFromCard;
            set
            {
                _selectedFromCard = value;
                OnPropertyChanged(nameof(SelectedFromCard));
            }
        }

        public BankCard SelectedToCard { get; set; }
        public ICommand TransferCommand { get; }
        public ICommand CloseCommand { get; }

        public TransferModalPageViewModel(INavigationService navigationService, IBankCardManager bankCardManager)
            : base(navigationService)
        {
            _bankCardManager = bankCardManager;

            CloseCommand = new Command(async () => await _navigationService.CloseCurrentModalPageAsync());
            TransferCommand = new Command<string>(OnTransferCommandCalled, CanTransfer);
        }

        private async void OnTransferCommandCalled(string parameter)
        {
            var valueToTransfer = Math.Abs(decimal.Parse(parameter));
            var hasTransferSuccess = await _bankCardManager.TryMakeTransferAsync(SelectedFromCard, SelectedToCard, valueToTransfer);

            if (hasTransferSuccess)
                await _navigationService.CloseCurrentModalPageAsync();
        }

        private bool CanTransfer(string parameter)
        {
            if (SelectedFromCard is null || SelectedToCard is null
                || ReferenceEquals(SelectedFromCard, SelectedToCard)
                || !decimal.TryParse(parameter, out decimal valueToTransfer)
                || SelectedFromCard.Balance < Math.Abs(valueToTransfer))
                return false;

            return true;
        }

        public void Initialize(TransferModalPageNavigationParameter navigationParameter)
        {
            Task.Run(async () =>
            {
                Cards = await _bankCardManager.GetBankCardsAsync();
                SelectedFromCard = Cards.FirstOrDefault(x => x.CardNumber == navigationParameter.FromCardNumber);
            });
        }
    }
}

