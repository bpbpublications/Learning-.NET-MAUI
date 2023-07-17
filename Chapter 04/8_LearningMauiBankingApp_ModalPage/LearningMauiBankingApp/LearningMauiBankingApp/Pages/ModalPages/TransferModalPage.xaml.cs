namespace LearningMauiBankingApp.Pages.ModalPages;

public partial class TransferModalPage : ContentPage
{
	public TransferModalPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        BackgroundColor = new Color(0, 0, 0, 0.0001f);
        base.OnAppearing();
    }

    private void OnCloseButtonClicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}
