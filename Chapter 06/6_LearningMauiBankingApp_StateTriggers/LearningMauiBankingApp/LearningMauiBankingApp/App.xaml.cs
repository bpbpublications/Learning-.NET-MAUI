using LearningMauiBankingApp.Pages;
using LearningMauiBankingApp.ViewModels;
using LearningMauiBankingApp.Interfaces;

namespace LearningMauiBankingApp;

public partial class App : Application
{
	public App(INavigationService navigationService)
	{
        InitializeComponent();

        navigationService.Initialize<LoginPage, LoginPageViewModel>();
	}
}