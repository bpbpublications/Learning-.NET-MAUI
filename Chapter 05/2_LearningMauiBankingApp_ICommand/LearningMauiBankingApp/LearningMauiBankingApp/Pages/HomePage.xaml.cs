using LearningMauiBankingApp.Models;
using LearningMauiBankingApp.Pages.ModalPages;
using LearningMauiBankingApp.ViewModels;

namespace LearningMauiBankingApp.Pages;

public partial class HomePage : ContentPage
{
    private readonly HomePageViewModel _viewModel;

    public HomePage()
	{
		InitializeComponent();

        BindingContext = _viewModel = new HomePageViewModel(Navigation);
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        _viewModel.OnNavigatedTo();
        base.OnNavigatedTo(args);
    }
}
