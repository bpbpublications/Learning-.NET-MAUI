using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Models;
using LearningMauiBankingApp.Services;
using LearningMauiBankingApp.Tools;

namespace LearningMauiBankingApp.ViewModels
{
    public class TransferModalPageViewModel : NavigationDataViewModelBase<TransferModalPageNavigationParameter>
    {
        private readonly IBankCardManager _bankCardManager;
        private readonly SemaphoreSlim _initializationSemaphore = new SemaphoreSlim(0, 1);

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

        public TransferModalPageViewModel(
            IStrongShellNavigation strongShellNavigation,
            IBankCardManager bankCardManager)
            : base(strongShellNavigation)
        {
            _bankCardManager = bankCardManager;

            CloseCommand = new AsyncRelayCommand(ClosePageAsync);
            TransferCommand = new AsyncRelayCommand<string>(OnTransferCommandCalledAsync, CanTransfer);
        }

        protected override void OnNavigationDataRecieved(TransferModalPageNavigationParameter navigationData)
        {
            Task.Run(async () =>
            {
                await _initializationSemaphore.WaitAsync();
                SelectedFromCard = Cards.FirstOrDefault(x => x.CardNumber == navigationData.FromCardNumber);
                _initializationSemaphore.Release();
            });
        }

        public override void OnNavigatedTo()
        {
            Task.Run(async () =>
            {
                Cards = await _bankCardManager.GetBankCardsAsync();
                _initializationSemaphore.Release();
            });
        }

        private async Task OnTransferCommandCalledAsync(string parameter)
        {
            var valueToTransfer = Math.Abs(decimal.Parse(parameter));
            var hasTransferSuccess = await _bankCardManager.TryMakeTransferAsync(SelectedFromCard, SelectedToCard, valueToTransfer);

            if (hasTransferSuccess)
                await ClosePageAsync();
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

        private async Task ClosePageAsync()
        {
            await _strongShellNavigation.NavigateBackAsync();
        }
    }
}