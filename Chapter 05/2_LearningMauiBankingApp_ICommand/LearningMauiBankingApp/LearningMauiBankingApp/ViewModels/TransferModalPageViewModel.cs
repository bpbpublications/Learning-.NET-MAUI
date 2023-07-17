using System;
using System.Windows.Input;
using LearningMauiBankingApp.Models;
using LearningMauiBankingApp.Tools;

namespace LearningMauiBankingApp.ViewModels
{
	public class TransferModalPageViewModel : NotifyPropertyChangedBase
    {
        private readonly INavigation _navigation;

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

        public TransferModalPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            CloseCommand = new Command(() => _navigation.PopModalAsync());
            TransferCommand = new Command<string>(OnTransferCommandCalled, CanTransfer);
        }

        private void OnTransferCommandCalled(string parameter)
        {
            var valueToTransfer = Math.Abs(decimal.Parse(parameter));

            SelectedFromCard.Balance -= valueToTransfer;
            SelectedToCard.Balance += valueToTransfer;
            _navigation.PopModalAsync();
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
    }
}

