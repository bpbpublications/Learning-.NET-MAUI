using LearningMauiBankingApp.Pages;
using LearningMauiBankingApp.ViewModels;
using LearningMauiBankingApp.Interfaces;
using CommunityToolkit.Maui.Core;
using System.Threading;
using CommunityToolkit.Maui.Alerts;

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

        var font = Microsoft.Maui.Font.OfSize("Poppins-Regular", 16);

        var snackbarOptions = new SnackbarOptions
        {
            BackgroundColor = (Color) (RequestedTheme == AppTheme.Dark ? Resources["DarkPrimaryBackgroundColor"] : Resources["LightPrimaryBackgroundColor"]),
            TextColor = (Color)(RequestedTheme == AppTheme.Dark ? Resources["DarkSecondaryTextColor"] : Resources["LightSecondaryTextColor"]),
            ActionButtonTextColor = (Color)(RequestedTheme == AppTheme.Dark ? Resources["DarkPrimaryTextColor"] : Resources["LightPrimaryTextColor"]),
            CornerRadius = new CornerRadius(15),
            Font = Microsoft.Maui.Font.OfSize("Poppins-Regular", 16),
            ActionButtonFont = Microsoft.Maui.Font.OfSize("Poppins-Bold", 14)
        };
        var duration = TimeSpan.FromSeconds(5);
        var messageText = string.Empty;
        var actionButtonText = Localization.Strings.ConnectivityAlert_ButtonText;

        var cancelationToken = new CancellationTokenSource();
        Action buttonAction = () => cancelationToken.Cancel();

        if (e.NetworkAccess == NetworkAccess.Internet)
            messageText = Localization.Strings.ConnectivityAlert_InternetOkMessage;
        else
            messageText = Localization.Strings.ConnectivityAlert_NoInternetMessage;

        var snackbar = Snackbar.Make(
                messageText,
                buttonAction,
                actionButtonText,
                duration,
                snackbarOptions);

        await snackbar.Show(cancelationToken.Token);

        _lastKnownNetworkAccess = e.NetworkAccess;

        Connectivity.ConnectivityChanged += OnConnectivityChanged;
    }
}