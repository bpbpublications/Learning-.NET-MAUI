using System;
using LearningMauiBankingApp.Tools;
using LearningMauiBankingApp.Models;
using System.Windows.Input;
using LearningMauiBankingApp.Pages.ModalPages;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Services;

namespace LearningMauiBankingApp.ViewModels
{
	public class HomePageViewModel : ViewModelBase
    {
        private readonly IBankCardManager _bankCardManager;

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

        public ICommand OpenTransferModalCommand { get; }

        public HomePageViewModel(
            INavigationService navigationService,
            IBankCardManager bankCardManager)
            : base(navigationService)
		{
            _bankCardManager = bankCardManager;
            OpenTransferModalCommand = new Command(OpenTransferModal);
        }

        public override void OnNavigatedTo()
        {
            _navigationService.ClearBackStack();
            Task.Run(async () => BankCards = await _bankCardManager.GetBankCardsAsync());
        }

        private async void OpenTransferModal()
        {
            await _navigationService.NavigateToAsync<TransferModalPage, TransferModalPageViewModel, IEnumerable<BankCard>>(BankCards, true);
        }
    }
}

