using CommunityToolkit.Maui;
using Fylth.Models.Settings;
using Fylth.Services;
using Fylth.ViewModels;
using Fylth.Views;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.Maui.Platform;

#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

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
            })
            .ConfigureLifecycleEvents(events => 
            {
#if WINDOWS
                events.AddWindows(windows => windows
                    .OnWindowCreated(window =>
                    {
                        IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                        WindowId win32WindowsId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
                        AppWindow winuiAppWindow = AppWindow.GetFromWindowId(win32WindowsId);
                        if (winuiAppWindow.Presenter is OverlappedPresenter p && SettingsService.Read(SettingsKeys.WasMaximized))
                            p.Maximize();
                        else
                        {
                            double height = SettingsService.Read(SettingsKeys.LastHeight);
                            double width = SettingsService.Read(SettingsKeys.LastWidth);
                            double yPos = SettingsService.Read(SettingsKeys.LastYPosition);
                            double xPos = SettingsService.Read(SettingsKeys.LastXPosition);

                            winuiAppWindow.MoveAndResize(new RectInt32((int)Math.Round(xPos), (int)Math.Round(yPos),
                                (int)Math.Round(width), (int)Math.Round(height)));
                        }
                    })
                    .OnClosed((window, args) =>
		            {
                        IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                        WindowId win32WindowsId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
                        AppWindow winuiAppWindow = AppWindow.GetFromWindowId(win32WindowsId);
                        if (winuiAppWindow.Presenter is OverlappedPresenter p)
                        {
                            if (p.State == OverlappedPresenterState.Maximized)
                            {
                                SettingsService.Write(SettingsKeys.WasMaximized, true);
                            }
                            else
                            {
                                SettingsService.Write(SettingsKeys.WasMaximized, false);
                                SettingsService.Write(SettingsKeys.LastWidth, window.Bounds.Width);
                                SettingsService.Write(SettingsKeys.LastHeight, window.Bounds.Height);
                                SettingsService.Write(SettingsKeys.LastXPosition, winuiAppWindow.Position.X);
                                SettingsService.Write(SettingsKeys.LastYPosition, winuiAppWindow.Position.Y);
                            }
                        }
                    })
	            );
#endif
            });

        builder.Services.AddSingleton<E621Service>();

		builder.Services.AddSingleton<E621PostsViewModel>();
        builder.Services.AddTransient<E621ViewPostViewModel>();
        builder.Services.AddTransient<SettingsViewModel>();

        builder.Services.AddSingleton<E621PostsPage>();
		builder.Services.AddTransient<E621ViewPostPage>();
        builder.Services.AddTransient<SettingsPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
