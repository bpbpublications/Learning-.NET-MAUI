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

		return builder.Build();
	}
}

