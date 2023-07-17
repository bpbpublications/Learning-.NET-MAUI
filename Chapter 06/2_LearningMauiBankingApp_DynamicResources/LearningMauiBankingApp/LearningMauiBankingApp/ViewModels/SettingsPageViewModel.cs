using System.Windows.Input;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Themes;
using LearningMauiBankingApp.Pages;
using LearningMauiBankingApp.Enums;

namespace LearningMauiBankingApp.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        private readonly IThemeManager _themeManager;

        public ICommand SwitchThemeCommand { get; }

        public SettingsPageViewModel(INavigationService navigationService, IThemeManager themeManager)
            : base(navigationService)
        {
            _themeManager = themeManager;
            SwitchThemeCommand = new Command(OnSwitchThemeButtonClicked);
        }

        private async void OnSwitchThemeButtonClicked()
        {
            if (_themeManager.CurrentTheme is ColorScheme.Alternative)
                _themeManager.SwitchThemeTo(ColorScheme.Default);
            else
                _themeManager.SwitchThemeTo(ColorScheme.Alternative);

            await Task.Delay(2000);
            await _navigationService.NavigateToAsync<HomePage, HomePageViewModel>();
        }
    }
}