using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Pages;
using LearningMauiBankingApp.Pages.ModalPages;
using LearningMauiBankingApp.ViewModels;
using StrongInject.Extensions.DependencyInjection;
using LearningMauiBankingApp.Themes;
using LearningMauiBankingApp.Services;
using CommunityToolkit.Maui;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace LearningMauiBankingApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
			.ConfigureFonts(fontCollection =>
			{
                fontCollection.AddFont("Poppins-Bold.ttf", "Poppins-Bold");
                fontCollection.AddFont("Poppins-Regular.ttf", "Poppins-Regular");
                fontCollection.AddFont("Poppins-SemiBold.ttf", "Poppins-SemiBold");
            });

        builder.Services.AddTransientServiceUsingContainer<StrongContainer, LoginPage>();
        builder.Services.AddTransientServiceUsingContainer<StrongContainer, LoginPageViewModel>();

        builder.Services.AddTransientServiceUsingContainer<StrongContainer, HomePage>();
        builder.Services.AddTransientServiceUsingContainer<StrongContainer, HomePageViewModel>();

        builder.Services.AddTransientServiceUsingContainer<StrongContainer, TransferModalPage>();
        builder.Services.AddTransientServiceUsingContainer<StrongContainer, TransferModalPageViewModel>();

        builder.Services.AddTransientServiceUsingContainer<StrongContainer, SettingsPage>();
        builder.Services.AddTransientServiceUsingContainer<StrongContainer, SettingsPageViewModel>();

        builder.Services.AddSingletonServiceUsingContainer<StrongContainer, ILocalizationManager>();
        builder.Services.AddSingletonServiceUsingContainer<StrongContainer, IBankCardManager>();
        builder.Services.AddSingletonServiceUsingContainer<StrongContainer, ILocalStorage>();
        builder.Services.AddTransientServiceUsingContainer<StrongContainer, INavigationService>();
        builder.Services.AddTransientServiceUsingContainer<StrongContainer, IThemeManager>();

        builder.Services.AddTransientServiceUsingContainer<StrongContainer, DefaultColorScheme>();
        builder.Services.AddTransientServiceUsingContainer<StrongContainer, AlternativeColorScheme>();

        return builder.Build();
	}
}

