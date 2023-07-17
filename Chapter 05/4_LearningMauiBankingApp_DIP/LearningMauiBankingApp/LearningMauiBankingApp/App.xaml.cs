using LearningMauiBankingApp.Pages;
using Microsoft.Maui.Platform;
using LearningMauiBankingApp.Services;
using LearningMauiBankingApp.ViewModels;

namespace LearningMauiBankingApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		var navigationService = new HierarchicalNavigationService();
		navigationService.Initialize<LoginPage, LoginPageViewModel>();
	}
}