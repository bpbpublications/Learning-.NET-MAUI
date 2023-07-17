﻿using LearningMauiBankingApp.Models;

namespace LearningMauiBankingApp.Pages.ModalPages;

public partial class TransferModalPage : ContentPage
{
    private IEnumerable<BankCard> _cards;
    public IEnumerable<BankCard> Cards
    {
        get => _cards;
        set
        {
            _cards = value;
            OnPropertyChanged(nameof(Cards));
        }
    }

    public TransferModalPage()
	{
		InitializeComponent();
        ContentLayout.BindingContext = this;

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
        
        if (fromCard != toCard
            && decimal.TryParse(TransferValueEntry.Text, out decimal transferValue)
            && fromCard?.Balance >= transferValue)
        {
            fromCard.Balance -= transferValue;
            toCard.Balance += transferValue;
            Navigation.PopModalAsync();
        }
    }
}
