namespace ShellMauiSample;

public partial class AccessoriesPage : ContentPage
{
	public AccessoriesPage()
	{
		InitializeComponent();
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        var shell = Shell.Current;
    }

    private async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("CustomPage3");
    }
}
