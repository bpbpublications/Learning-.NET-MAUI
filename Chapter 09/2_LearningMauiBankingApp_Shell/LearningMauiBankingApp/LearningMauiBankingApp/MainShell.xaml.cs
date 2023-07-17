using LearningMauiBankingApp.Models;
using LearningMauiBankingApp.Pages;
using LearningMauiBankingApp.Pages.ModalPages;
using LearningMauiBankingApp.Services;
using LearningMauiBankingApp.Tools;

namespace LearningMauiBankingApp;

public partial class MainShell : Shell
{
	public MainShell()
	{
		InitializeComponent();

        var confirmationModalPageRouteId = ShellRouteIdHelper.GetId<ConfirmationModalPage>();
        Routing.RegisterRoute(confirmationModalPageRouteId.RouteId, confirmationModalPageRouteId.PageType);

        var transferModalPageRouteId = ShellRouteIdHelper.GetId<TransferModalPage>();
        Routing.RegisterRoute(transferModalPageRouteId.RouteId, transferModalPageRouteId.PageType);

        var customPage1RouteId = ShellRouteIdHelper.GetId<CustomPage1>();
        Routing.RegisterRoute(customPage1RouteId.RouteId, customPage1RouteId.PageType);

        var customPage2RouteId = ShellRouteIdHelper.GetId<CustomPage2>();
        Routing.RegisterRoute(customPage2RouteId.RouteId, customPage2RouteId.PageType);

        var customPage3RouteId = ShellRouteIdHelper.GetId<CustomPage3>();
        Routing.RegisterRoute(customPage3RouteId.RouteId, customPage3RouteId.PageType);
    }
}
