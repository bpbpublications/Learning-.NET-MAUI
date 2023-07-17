using System;
using System.Windows.Input;
using LearningMauiBankingApp.Tools;
using LearningMauiBankingApp.Pages;
using LearningMauiBankingApp.Models;

namespace LearningMauiBankingApp.ViewModels
{
	public class LoginPageViewModel : NotifyPropertyChangedBase
    {
        private readonly INavigation _navigation;

        public string Username { get; set; }
        public string Password { get; set; }

        public LoginCredentials LoginCredentials { get; set; }

        public ICommand LoginButtonCommand { get; }

        public LoginPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            LoginCredentials = new LoginCredentials();
            LoginButtonCommand = new Command(OnLoginButtonClicked);
        }

        private void OnLoginButtonClicked()
        {
            _navigation.PushAsync(new HomePage());
        }
	}
}

