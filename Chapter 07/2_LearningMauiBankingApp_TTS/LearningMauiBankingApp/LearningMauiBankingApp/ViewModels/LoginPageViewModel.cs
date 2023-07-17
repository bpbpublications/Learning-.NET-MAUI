using System.Windows.Input;
using LearningMauiBankingApp.Pages;
using LearningMauiBankingApp.Models;
using LearningMauiBankingApp.Interfaces;

namespace LearningMauiBankingApp.ViewModels
{
	public class LoginPageViewModel : ViewModelBase
    {
        private readonly ITextToSpeech _textToSpeech;

        public string Username { get; set; }
        public string Password { get; set; }

        public LoginCredentials LoginCredentials { get; set; }

        public ICommand LoginButtonCommand { get; }

        public LoginPageViewModel(INavigationService navigationService, ITextToSpeech textToSpeech)
            : base(navigationService)
        {
            _textToSpeech = textToSpeech;

            LoginCredentials = new LoginCredentials();
            LoginButtonCommand = new Command(OnLoginButtonClicked);
        }

        private async void OnLoginButtonClicked()
        {
            await _textToSpeech.SpeakAsync($"{Localization.Strings.TTS_WelcomeBack} {Username}");
            await _navigationService.NavigateToAsync<HomePage, HomePageViewModel>();
        }
	}
}