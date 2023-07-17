using System.ComponentModel;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Models;
using LearningMauiBankingApp.ViewModels;

namespace LearningMauiBankingApp.Pages.ModalPages;

public partial class TransferModalPage : ContentPageBase, IShellPage
{
    public TransferModalPage(TransferModalPageViewModel viewModel)
        : base(viewModel)
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        BackgroundColor = new Color(0, 0, 0, 0.0001f);
    }
}