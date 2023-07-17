using System;
using System.Windows.Input;
using LearningMauiBankingApp.Tools;
using LearningMauiBankingApp.Pages;
using LearningMauiBankingApp.Models;

namespace LearningMauiBankingApp.ViewModels
{
	public class LoginPageViewModel : ViewModelBase
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginCredentials LoginCredentials { get; set; }

        public ICommand LoginButtonCommand { get; }

        public LoginPageViewModel()
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

