using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using LearningMauiBankingApp.Interfaces;

namespace LearningMauiBankingApp.ViewModels
{
	public class ConfirmationModalPageViewModel : ResultingViewModelBase<bool>
    {
		public ICommand CloseWithResultCommand { get; }

        public ConfirmationModalPageViewModel(IStrongShellNavigation strongShellNavigation)
            : base(strongShellNavigation)
		{
            CloseWithResultCommand = new AsyncRelayCommand<bool>(GoBackWithResultAsync);
        }
    }
}