using System.ComponentModel;
using LearningMauiBankingApp.Models;
using LearningMauiBankingApp.ViewModels;

namespace LearningMauiBankingApp.Pages.ModalPages;

public partial class TransferModalPage : ContentPage
{
    public TransferModalPage(IEnumerable<BankCard> cards)
	{
		InitializeComponent();
        BindingContext = new TransferModalPageViewModel(Navigation)
        {
            Cards = cards
        };
    }

    protected override void OnAppearing()
    {
        BackgroundColor = new Color(0, 0, 0, 0.0001f);
    }
}
