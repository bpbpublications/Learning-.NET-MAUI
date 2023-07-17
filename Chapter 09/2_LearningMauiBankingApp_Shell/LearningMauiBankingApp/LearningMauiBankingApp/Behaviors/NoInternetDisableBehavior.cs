using System;
namespace LearningMauiBankingApp.Behaviors
{
	public class NoInternetDisableBehavior : Behavior<VisualElement>
    {
        private VisualElement _bindable;
        private NetworkAccess _lastKnownNetworkAccess;

        protected override void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);
            _bindable = bindable;
            _lastKnownNetworkAccess = Connectivity.NetworkAccess;
            Connectivity.ConnectivityChanged += OnConnectivityChanged;
        }

        protected override void OnDetachingFrom(VisualElement bindable)
        {
            base.OnDetachingFrom(bindable);
            Connectivity.ConnectivityChanged -= OnConnectivityChanged;
        }

        private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (_lastKnownNetworkAccess == e.NetworkAccess)
                return;

            _lastKnownNetworkAccess = e.NetworkAccess;
            Connectivity.ConnectivityChanged -= OnConnectivityChanged;

            if (e.NetworkAccess == NetworkAccess.Internet)
                _bindable.IsEnabled = true;
            else
                _bindable.IsEnabled = false;

            Connectivity.ConnectivityChanged += OnConnectivityChanged;
        }
    }
}

