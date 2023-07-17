using LearningMauiBankingApp.Pages;
using Microsoft.Maui.Platform;
using LearningMauiBankingApp.Services;
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