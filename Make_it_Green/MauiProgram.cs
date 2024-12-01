using Microsoft.Extensions.Logging;

namespace Make_it_Green;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("Cloud Soft-Bold.ttf", "CloudSoftBold");
				fonts.AddFont("Cloud Soft-Light.ttf", "CloudSoftLight");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
