using System;
using LearningMauiBankingApp.Tools;
using LearningMauiBankingApp.Models;
using System.Windows.Input;
using LearningMauiBankingApp.Pages.ModalPages;

namespace LearningMauiBankingApp.ViewModels
{
	public class HomePageViewModel : ViewModelBase
    {
        public IEnumerable<BankCard> BankCards { get; }

        public ICommand OpenTransferModalCommand { get; }

        public HomePageViewModel()
		{
            BankCards = GetBankCards();
            OpenTransferModalCommand = new Command(OpenTransferModal);
        }

        public override void OnNavigatedTo()
        {
            _navigationService.ClearBackStack();
        }

        private async void OpenTransferModal()
        {
            await _navigationService.NavigateToAsync<TransferModalPage, TransferModalPageViewModel, IEnumerable<BankCard>>(BankCards, true);
        }

        private static IEnumerable<BankCard> GetBankCards()
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

