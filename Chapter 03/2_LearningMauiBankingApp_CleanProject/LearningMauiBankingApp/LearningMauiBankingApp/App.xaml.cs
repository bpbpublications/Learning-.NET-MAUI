using LearningMauiBankingApp.Pages;

namespace LearningMauiBankingApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new HomePage();
	}
}