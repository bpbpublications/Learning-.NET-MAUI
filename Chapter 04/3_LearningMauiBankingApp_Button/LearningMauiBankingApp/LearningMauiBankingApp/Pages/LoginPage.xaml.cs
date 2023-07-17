﻿namespace LearningMauiBankingApp.Pages;

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

    private void OnLoginButtonClicked(object sender, EventArgs e)
    {
        PasswordEntry.Text = string.Empty;
    }
}
