using LearningMauiBankingApp.Pages;
using LearningMauiBankingApp.ViewModels;
using LearningMauiBankingApp.Interfaces;

namespace LearningMauiBankingApp;

public partial class App : Application
{
    private NetworkAccess _lastKnownNetworkAccess;

	public App(INavigationService navigationService)
	{
        InitializeComponent();
        navigationService.Initialize<LoginPage, LoginPageViewModel>();
	}

    protected override void OnStart()
    {
        _lastKnownNetworkAccess = Connectivity.NetworkAccess;
        Connectivity.ConnectivityChanged += OnConnectivityChanged;
        base.OnStart();
    }

    protected override void OnResume()
    {
        Connectivity.ConnectivityChanged += OnConnectivityChanged;
        base.OnResume();
    }

    protected override void OnSleep()
    {
        Connectivity.ConnectivityChanged -= OnConnectivityChanged;
        base.OnSleep();
    }

    private async void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        //return if ConnectionProfiles collection has been changed, not NetworkAccess
        if (_lastKnownNetworkAccess == e.NetworkAccess)
            return;
        
        Connectivity.ConnectivityChanged -= OnConnectivityChanged;
        
        if (e.NetworkAccess == NetworkAccess.Internet)
            await MainPage.DisplayAlert(
                Localization.Strings.ConnectivityAlert_InternetOkTitle,
                Localization.Strings.ConnectivityAlert_InternetOkMessage,
                Localization.Strings.ConnectivityAlert_ButtonText);
        else
            await MainPage.DisplayAlert(
                Localization.Strings.ConnectivityAlert_NoInternetTitle,
                Localization.Strings.ConnectivityAlert_NoInternetMessage,
                Localization.Strings.ConnectivityAlert_ButtonText);

        _lastKnownNetworkAccess = e.NetworkAccess;

        Connectivity.ConnectivityChanged += OnConnectivityChanged;
    }
}