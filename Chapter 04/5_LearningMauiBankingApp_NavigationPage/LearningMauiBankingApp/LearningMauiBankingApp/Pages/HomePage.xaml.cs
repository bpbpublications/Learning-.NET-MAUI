namespace LearningMauiBankingApp.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        Navigation.RemovePage(Navigation.NavigationStack[0]);
        base.OnNavigatedTo(args);
    }
}
