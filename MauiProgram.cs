using CommunityToolkit.Maui;
using Fylth.Services;
using Fylth.ViewModels;
using Fylth.Views;
using Microsoft.Extensions.Logging;

namespace Fylth;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.UseMauiCommunityToolkitMediaElement()
			.ConfigureFonts(fonts =>
			{
				// Default fonts
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				
				// FontAwesome icons
				fonts.AddFont("FontAwesome-6-Brands-Regular-400.otf", "FaBrands");
				fonts.AddFont("FontAwesome-6-Free-Regular-400.otf", "FaRegular");
				fonts.AddFont("FontAwesome-6-Free-Solid-900.otf", "FaSolid");
			});
		
		builder.Services.AddSingleton<E621Service>();

		builder.Services.AddSingleton<E621PostsViewModel>();
		builder.Services.AddTransient<E621ViewPostViewModel>();

		builder.Services.AddSingleton<E621PostsPage>();
		builder.Services.AddTransient<E621ViewPostPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
