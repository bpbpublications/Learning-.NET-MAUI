using LearningMauiBankingApp.Pages;
using Microsoft.Maui.Platform;

namespace LearningMauiBankingApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new LoginPage();
	}
}