using System.Windows.Input;
using LearningMauiBankingApp.Pages;
using LearningMauiBankingApp.Models;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Services;
using LearningMauiBankingApp.Tools;
using CommunityToolkit.Mvvm.Input;

namespace LearningMauiBankingApp.ViewModels
{
	public class LoginPageViewModel : ViewModelBase
    {
        private readonly ITextToSpeech _textToSpeech;
        private readonly IApplicationPreferences _applicationPreferences;

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password { get; set; }

        public LoginCredentials LoginCredentials { get; set; }

        public ICommand LoginButtonCommand { get; }
        public ICommand SpeakCommand { get; }

        public LoginPageViewModel(
            IStrongShellNavigation strongShellNavigation,
            ITextToSpeech textToSpeech,
            IApplicationPreferences applicationPreferences)
            : base(strongShellNavigation)
        {
            _textToSpeech = textToSpeech;

            LoginCredentials = new LoginCredentials();
            LoginButtonCommand = new AsyncRelayCommand(OnLoginButtonClickedAsync);
            SpeakCommand = new AsyncRelayCommand<string>(SpeakAsync);
            _applicationPreferences = applicationPreferences;
        }

        public override void OnNavigatedTo()
        {
            Username = _applicationPreferences.Username;
            base.OnNavigatedTo();
        }

        private async Task OnLoginButtonClickedAsync()
        {
            _applicationPreferences.Username = Username;

            _ = _textToSpeech.SpeakAsync($"{Localization.Strings.TTS_WelcomeBack} {Username}");
            await _strongShellNavigation.NavigateToAsync(ShellRouteIdHelper.GetRootId<HomePage>());
        }

        private async Task SpeakAsync(string textToSpeak)
        {
            await _textToSpeech.SpeakAsync(textToSpeak);
        }
    }
}