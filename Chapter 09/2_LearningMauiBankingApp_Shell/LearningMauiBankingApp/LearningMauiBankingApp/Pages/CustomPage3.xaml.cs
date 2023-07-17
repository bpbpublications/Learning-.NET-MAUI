using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Models;
using LearningMauiBankingApp.Services;
using LearningMauiBankingApp.Tools;

namespace LearningMauiBankingApp.Pages;

public partial class CustomPage3 : ContentPage, IShellPage
{
    private readonly IStrongShellNavigation _strongShellNavigation;

    public CustomPage3(IStrongShellNavigation strongShellNavigation)
	{
		InitializeComponent();
        _strongShellNavigation = strongShellNavigation;
    }

    private async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        await _strongShellNavigation.NavigateBackToAsync(ShellRouteIdHelper.GetId<CustomPage1>());
    }
}