using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.ViewModels;

namespace LearningMauiBankingApp.Pages.ModalPages;

public partial class ConfirmationModalPage : ContentPageBase, IShellPage
{
	public ConfirmationModalPage(ConfirmationModalPageViewModel viewModel)
		: base(viewModel)
	{
		InitializeComponent();
	}
}
