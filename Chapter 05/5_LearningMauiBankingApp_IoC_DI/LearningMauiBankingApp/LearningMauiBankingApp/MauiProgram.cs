using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Pages;
using LearningMauiBankingApp.Pages.ModalPages;
using LearningMauiBankingApp.Services;
using LearningMauiBankingApp.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace LearningMauiBankingApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fontCollection =>
			{
                fontCollection.AddFont("Poppins-Bold.ttf", "Poppins-Bold");
                fontCollection.AddFont("Poppins-Regular.ttf", "Poppins-Regular");
                fontCollection.AddFont("Poppins-SemiBold.ttf", "Poppins-SemiBold");
            });

		builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<LoginPageViewModel>();

        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<HomePageViewModel>();

        builder.Services.AddTransient<TransferModalPage>();
        builder.Services.AddTransient<TransferModalPageViewModel>();

        builder.Services.AddTransient<IBankCardManager, DummyBankCardManager>();
        builder.Services.AddTransient<INavigationService, HierarchicalNavigationService>();

        return builder.Build();
	}
}

