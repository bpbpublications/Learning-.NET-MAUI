namespace ShellMauiSample;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(CustomPage1), typeof(CustomPage1));
        Routing.RegisterRoute(nameof(CustomPage2), typeof(CustomPage2));
        Routing.RegisterRoute(nameof(CustomPage3), typeof(CustomPage3));
    }
}

