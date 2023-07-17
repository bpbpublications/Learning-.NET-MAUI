using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Pages;
using LearningMauiBankingApp.Pages.ModalPages;
using LearningMauiBankingApp.Services;
using LearningMauiBankingApp.ViewModels;
using StrongInject;

namespace LearningMauiBankingApp
{
    [Register(typeof(LoginPage))]
    [Register(typeof(LoginPageViewModel))]
    [Register(typeof(HomePage))]
    [Register(typeof(HomePageViewModel))]
    [Register(typeof(TransferModalPage))]
    [Register(typeof(TransferModalPageViewModel))]
    [Register(typeof(DummyBankCardManager), typeof(IBankCardManager))]
    [Register(typeof(HierarchicalNavigationService), typeof(INavigationService))]
    public partial class StrongContainer :
        IContainer<LoginPage>,
        IContainer<LoginPageViewModel>,
        IContainer<HomePage>,
        IContainer<HomePageViewModel>,
        IContainer<TransferModalPage>,
        IContainer<TransferModalPageViewModel>,
        IContainer<IBankCardManager>,
        IContainer<INavigationService>
    {
        [Instance]
        private readonly IServiceProvider _serviceProvider;

        public StrongContainer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}

