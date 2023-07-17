namespace MessagingCenterSample;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();

		MessagingCenter.Subscribe<LoginPage, User>(this, MessagingCenterMessages.LoginSuccess, OnLoginSuccessMessageRecieved);
	}

	private void NavigateToLoginPageButtonClicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new LoginPage());
	}

	private void OnLoginSuccessMessageRecieved(LoginPage sender, User user)
	{
		MessagingCenter.Unsubscribe<LoginPage, User>(this, MessagingCenterMessages.LoginSuccess);

		WelcomeLabel.Text = $"Welcome back, {user.FirstName} {user.LastName}";
		SignInButton.IsVisible = false;
    }
}


