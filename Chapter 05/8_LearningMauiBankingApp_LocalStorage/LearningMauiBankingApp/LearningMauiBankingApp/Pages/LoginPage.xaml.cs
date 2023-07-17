using LearningMauiBankingApp.Models;
using LearningMauiBankingApp.ViewModels;

namespace LearningMauiBankingApp.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
	{
        InitializeComponent();
	}

    private void OnClientIdEntryCompleted(object sender, EventArgs e)
    {
        PasswordEntry.Focus();
    }
}
