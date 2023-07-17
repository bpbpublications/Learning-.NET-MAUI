using LearningMauiBankingApp.Models;
using LearningMauiBankingApp.ViewModels;

namespace LearningMauiBankingApp.Pages.ModalPages;

public partial class TransferModalPage : ContentPage
{
    private readonly TransferModalPageViewModel _viewModel;

    public TransferModalPage(IEnumerable<BankCard> cards)
	{
		InitializeComponent();
        _viewModel = new TransferModalPageViewModel()
        {
            Cards = cards
        };
        BindingContext = _viewModel;
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

    private void OnTransferButtonClicked(object sender, EventArgs e)
    {
        var fromCard = FromPicker.SelectedItem as BankCard;
        var toCard = ToPicker.SelectedItem as BankCard;

        if (!decimal.TryParse(TransferValueEntry.Text, out decimal transferValue))
            return;

        var tramsferAbsValue = Math.Abs(transferValue);

        if (fromCard.Balance < tramsferAbsValue)
        {
            DisplayAlert("Invalid value", "Source card doesn't have enough money", "OK");
            return;
        }

        if (fromCard != toCard)
        {
            fromCard.Balance -= Math.Abs(transferValue);
            toCard.Balance += transferValue;
            Navigation.PopModalAsync();
        }
    }
}
