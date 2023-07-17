using LearningMauiBankingApp.Models;
using System.Windows.Input;
using LearningMauiBankingApp.Pages;
using LearningMauiBankingApp.Pages.ModalPages;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Services;
using System.Collections.Generic;
using LearningMauiBankingApp.Tools;
using CommunityToolkit.Mvvm.Input;

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
        public ICommand MoreButtonCommand { get; }

        public HomePageViewModel(IStrongShellNavigation strongShellNavigation, IBankCardManager bankCardManager)
            : base(strongShellNavigation)
        {
            _bankCardManager = bankCardManager;
            OpenTransferModalCommand = new AsyncRelayCommand(OpenTransferModalAsync);
            SelectBankCardCommand = new AsyncRelayCommand<long>(OnBankCardSelectedAsync);
            OpenSettingsCommand = new AsyncRelayCommand(OpenSettingsAsync);
            MoreButtonCommand = new AsyncRelayCommand(OnMoreButtonCommandAsync);

            _bankCardManager.BankCardsChanged += OnBankCardManagerBankCardsChanged;
        }

        public override void OnNavigatedTo()
        {
            Task.Run(async () => BankCards = await _bankCardManager.GetBankCardsAsync());
        }

        private async Task OpenTransferModalAsync()
        {
            await _strongShellNavigation.NavigateToAsync(new List<ShellPageRouteId> { ShellRouteIdHelper.GetId<TransferModalPage>() });
        }

        private async Task OnBankCardSelectedAsync(long bankCardNumber)
        {
            var isConfirmed = await _strongShellNavigation.NavigateToAsync<bool>(
                new List<ShellPageRouteId> { ShellRouteIdHelper.GetId<ConfirmationModalPage>() });

            if (isConfirmed)
                await _strongShellNavigation.NavigateToAsync(
                    new List<ShellPageRouteId> { ShellRouteIdHelper.GetId<TransferModalPage>() },
                    new TransferModalPageNavigationParameter(bankCardNumber));
        }

        private async Task OpenSettingsAsync()
        {
            await _strongShellNavigation.NavigateToAsync(ShellRouteIdHelper.GetRootId<SettingsPage>());
        }

        private void OnBankCardManagerBankCardsChanged(object sender, IEnumerable<BankCard> bankCards)
        {
            BankCards = bankCards;
        }

        private async Task OnMoreButtonCommandAsync()
        {
            await _strongShellNavigation.NavigateToAsync(new List<ShellPageRouteId>
            {
                ShellRouteIdHelper.GetId<CustomPage1>(),
                ShellRouteIdHelper.GetId<CustomPage2>(),
                ShellRouteIdHelper.GetId<CustomPage3>()
            });
        }

        public void Dispose()
        {
            if (!_disposed)
                _bankCardManager.BankCardsChanged -= OnBankCardManagerBankCardsChanged;

            _disposed = true;
        }
    }
}