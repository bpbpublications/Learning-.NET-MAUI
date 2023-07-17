using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.ViewModels;

namespace LearningMauiBankingApp.Pages;

public partial class SettingsPage : ContentPageBase, IShellRootPage
{
	public SettingsPage(SettingsPageViewModel viewModel)
        : base(viewModel)
	{
		InitializeComponent();
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
		var currentItem = Shell.Current.CurrentItem;
        var currentPage = Shell.Current.CurrentPage;
        var currentState = Shell.Current.CurrentState;

        base.OnNavigatedTo(args);
    }
}
