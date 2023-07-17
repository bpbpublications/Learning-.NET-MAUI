using System.Windows.Input;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Themes;
using LearningMauiBankingApp.Pages;
using System.Globalization;
using LearningMauiBankingApp.Enums;

namespace LearningMauiBankingApp.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        private readonly IThemeManager _themeManager;
        private readonly ILocalizationManager _localizationManager;

        public ICommand SwitchThemeCommand { get; }
        public ICommand SwitchToEnglishCommand { get; }
        public ICommand SwitchToPolishCommand { get; }

        public SettingsPageViewModel(
            INavigationService navigationService,
            IThemeManager themeManager,
            ILocalizationManager localizationManager)
            : base(navigationService)
        {
            _themeManager = themeManager;
            _localizationManager = localizationManager;
            SwitchThemeCommand = new Command(OnSwitchThemeButtonClicked);
            SwitchToEnglishCommand = new Command(OnSwitchToEnglishClicked);
            SwitchToPolishCommand = new Command(OnSwitchToPolishClicked);
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

        private void OnSwitchToEnglishClicked()
            => _localizationManager.SetCulture(new CultureInfo("en"));

        private void OnSwitchToPolishClicked()
            => _localizationManager.SetCulture(new CultureInfo("pl"));
    }
}

