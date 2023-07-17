namespace ShellMauiSample;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppFlyoutShell();
	}
}

