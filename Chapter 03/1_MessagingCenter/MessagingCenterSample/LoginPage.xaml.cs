namespace MessagingCenterSample;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void OnLoginButtonClicked(object sender, EventArgs e)
    {
		var user = new User(FirstNameEntry.Text, LastNameEntry.Text);
		DisplayAlert("Success", "Please, go back to the previous page", "OK");

		MessagingCenter.Send<LoginPage, User>(this, MessagingCenterMessages.LoginSuccess, user);
    }
}
