using System;
using System.Windows.Input;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Models;
using LearningMauiBankingApp.Tools;

namespace LearningMauiBankingApp.ViewModels
{
	public class TransferModalPageViewModel : ViewModelBase, IInitialize<IEnumerable<BankCard>>
    {
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

        public BankCard SelectedFromCard { get; set; }
        public BankCard SelectedToCard { get; set; }
        public ICommand TransferCommand { get; }
        public ICommand CloseCommand { get; }

        public TransferModalPageViewModel()
        {
            CloseCommand = new Command(async () => await _navigationService.CloseCurrentModalPageAsync());
            TransferCommand = new Command<string>(OnTransferCommandCalled, CanTransfer);
        }

        private async void OnTransferCommandCalled(string parameter)
        {
            var valueToTransfer = Math.Abs(decimal.Parse(parameter));

            SelectedFromCard.Balance -= valueToTransfer;
            SelectedToCard.Balance += valueToTransfer;
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

        public void Initialize(IEnumerable<BankCard> navigationParameter)
        {
            Cards = navigationParameter;
        }
    }
}

