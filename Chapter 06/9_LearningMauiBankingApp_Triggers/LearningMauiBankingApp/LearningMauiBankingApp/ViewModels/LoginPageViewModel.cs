using System.Windows.Input;
using LearningMauiBankingApp.Pages;
using LearningMauiBankingApp.Models;
using LearningMauiBankingApp.Interfaces;

namespace LearningMauiBankingApp.ViewModels
{
	public class LoginPageViewModel : ViewModelBase
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginCredentials LoginCredentials { get; set; }

        public ICommand LoginButtonCommand { get; }

        public LoginPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            LoginCredentials = new LoginCredentials();
            LoginButtonCommand = new Command(OnLoginButtonClicked);
        }

        private async void OnLoginButtonClicked()
        {
            await _navigationService.NavigateToAsync<HomePage, HomePageViewModel>();
        }
	}
}