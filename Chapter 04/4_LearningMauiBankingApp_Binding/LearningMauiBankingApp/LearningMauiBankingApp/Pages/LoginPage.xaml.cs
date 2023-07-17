using LearningMauiBankingApp.Models;

namespace LearningMauiBankingApp.Pages;

public partial class LoginPage : ContentPage
{
    private readonly LoginCredentials _credentials;

    public LoginPage()
	{
        InitializeComponent();
        _credentials = new LoginCredentials();
        ContentStackLayout.BindingContext = _credentials;
	}

    private void OnClientIdEntryCompleted(object sender, EventArgs e)
    {
        PasswordEntry.Focus();
    }

    private void OnLoginButtonClicked(object sender, EventArgs e)
    {
        PasswordEntry.Text = string.Empty;
    }
}
