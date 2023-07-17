using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Pages;
using LearningMauiBankingApp.Pages.ModalPages;
using LearningMauiBankingApp.Services;
using LearningMauiBankingApp.ViewModels;
using LearningMauiBankingApp.Themes;
using StrongInject;

namespace LearningMauiBankingApp
{
    [Register(typeof(LoginPage))]
    [Register(typeof(LoginPageViewModel))]
    [Register(typeof(HomePage))]
    [Register(typeof(HomePageViewModel))]
    [Register(typeof(TransferModalPage))]
    [Register(typeof(TransferModalPageViewModel))]
    [Register(typeof(SettingsPage))]
    [Register(typeof(SettingsPageViewModel))]
    [Register(typeof(HierarchicalNavigationService), typeof(INavigationService))]
    [Register(typeof(ThemeManager), typeof(IThemeManager))]
    [Register(typeof(DummyBankCardManager), Scope.SingleInstance, typeof(IBankCardManager))]
    [Register(typeof(LocalStorage), Scope.SingleInstance, typeof(ILocalStorage))]
    [Register(typeof(LocalizationManager), Scope.SingleInstance, typeof(ILocalizationManager))]
    [Register(typeof(DefaultColorScheme))]
    [Register(typeof(AlternativeColorScheme))]
    public partial class StrongContainer :
        IContainer<LoginPage>,
        IContainer<LoginPageViewModel>,
        IContainer<HomePage>,
        IContainer<HomePageViewModel>,
        IContainer<TransferModalPage>,
        IContainer<TransferModalPageViewModel>,
        IContainer<SettingsPage>,
        IContainer<SettingsPageViewModel>,
        IContainer<IBankCardManager>,
        IContainer<INavigationService>,
        IContainer<ILocalStorage>,
        IContainer<IThemeManager>,
        IContainer<DefaultColorScheme>,
        IContainer<AlternativeColorScheme>,
        IContainer<ILocalizationManager>
    {
        [Instance]
        private readonly IServiceProvider _serviceProvider;

        public static IServiceProvider ServiceProvider { get; private set;}

        public StrongContainer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            ServiceProvider = _serviceProvider;
        }
    }
}

