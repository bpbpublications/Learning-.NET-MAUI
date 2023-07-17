using LearningMauiBankingApp.Models;
using LearningMauiBankingApp.ViewModels;

namespace LearningMauiBankingApp.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
	{
        InitializeComponent();
        ValidateEntry(UsernameEntry);
    }

    private void OnUsernameEntryTextChanged(object sender, TextChangedEventArgs e)
        => ValidateEntry((Entry)sender);

    private void ValidateEntry(Entry entry)
    {
        if (string.IsNullOrEmpty(entry.Text))
            VisualStateManager.GoToState(entry, "Invalid");
        else
            VisualStateManager.GoToState(entry, "Valid");
    }

    private void OnClientIdEntryCompleted(object sender, EventArgs e)
    {
        PasswordEntry.Focus();
    }
}