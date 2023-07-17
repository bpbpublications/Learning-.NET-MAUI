using System.Windows.Input;
using LearningMauiBankingApp.Pages;
using LearningMauiBankingApp.Models;
using LearningMauiBankingApp.Interfaces;

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

        public LoginPageViewModel(
            INavigationService navigationService,
            ITextToSpeech textToSpeech,
            IApplicationPreferences applicationPreferences)
            : base(navigationService)
        {
            _textToSpeech = textToSpeech;

            LoginCredentials = new LoginCredentials();
            LoginButtonCommand = new Command(OnLoginButtonClicked);
            _applicationPreferences = applicationPreferences;
        }

        public override void OnNavigatedTo()
        {
            Username = _applicationPreferences.Username;
            base.OnNavigatedTo();
        }

        private async void OnLoginButtonClicked()
        {
            _applicationPreferences.Username = Username;

            await _textToSpeech.SpeakAsync($"{Localization.Strings.TTS_WelcomeBack} {Username}");
            await _navigationService.NavigateToAsync<HomePage, HomePageViewModel>();
        }
	}
}