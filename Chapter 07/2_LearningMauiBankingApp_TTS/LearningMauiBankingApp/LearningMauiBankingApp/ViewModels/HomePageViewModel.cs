﻿using LearningMauiBankingApp.Models;
using System.Windows.Input;
using LearningMauiBankingApp.Pages;
using LearningMauiBankingApp.Pages.ModalPages;
using LearningMauiBankingApp.Interfaces;

namespace LearningMauiBankingApp.ViewModels
{
	public class HomePageViewModel : ViewModelBase, IDisposable
    {
        private readonly IBankCardManager _bankCardManager;

        private bool _disposed;

        private IEnumerable<BankCard> _bankCards;
        public IEnumerable<BankCard> BankCards
        {
            get => _bankCards;
            private set
            {
                _bankCards = value;
                OnPropertyChanged(nameof(BankCards));
            }
        }

        public ICommand SelectBankCardCommand { get; }
        public ICommand OpenTransferModalCommand { get; }
        public ICommand OpenSettingsCommand { get; }

        public HomePageViewModel(
            INavigationService navigationService,
            IBankCardManager bankCardManager)
            : base(navigationService)
        {
            _bankCardManager = bankCardManager;
            OpenTransferModalCommand = new Command(OpenTransferModal);
            SelectBankCardCommand = new Command<long>(OnBankCardSelected);
            OpenSettingsCommand = new Command(OpenSettings);

            _bankCardManager.BankCardsChanged += OnBankCardManagerBankCardsChanged;
        }

        public override void OnNavigatedTo()
        {
            _navigationService.ClearBackStack();
            Task.Run(async () => BankCards = await _bankCardManager.GetBankCardsAsync());
        }

        private async void OpenTransferModal()
        {
            await _navigationService.NavigateToAsync<
                TransferModalPage,
                TransferModalPageViewModel,
                TransferModalPageNavigationParameter>(
                new TransferModalPageNavigationParameter(), true);
        }

        private async void OnBankCardSelected(long bankCardNumber)
        {
            await _navigationService.NavigateToAsync<
                TransferModalPage,
                TransferModalPageViewModel,
                TransferModalPageNavigationParameter>(
                new TransferModalPageNavigationParameter(bankCardNumber), true);
        }

        private async void OpenSettings()
        {
            await _navigationService.NavigateToAsync<
                SettingsPage,
                SettingsPageViewModel>();
        }

        private void OnBankCardManagerBankCardsChanged(object sender, IEnumerable<BankCard> bankCards)
        {
            BankCards = bankCards;
        }

        public void Dispose()
        {
            if (!_disposed)
                _bankCardManager.BankCardsChanged -= OnBankCardManagerBankCardsChanged;

            _disposed = true;
        }
    }
}

