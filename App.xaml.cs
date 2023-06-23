using Fylth.Models.Settings;
using Fylth.Services;

namespace Fylth;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
	
	protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);
        if (DeviceInfo.Current.Idiom != DeviceIdiom.Desktop) return window;

        if (SettingsService.Read(SettingsKeys.WasMaximized))
        {
            // TODO: figure out how to programatically maximize the window, for now just set it back to false
            SettingsService.Write(SettingsKeys.WasMaximized, false);
        } 
        else 
        {
	        // DeviceDisplay is not currently working for now we are just gonna set it without any checking to make sure it will actually be on screen
            window.Height = SettingsService.Read(SettingsKeys.LastHeight);
            window.Width = SettingsService.Read(SettingsKeys.LastWidth);
            window.Y = SettingsService.Read(SettingsKeys.LastYPosition);
            window.X = SettingsService.Read(SettingsKeys.LastXPosition);

            // TODO: add the screen size checking
            if (DeviceDisplay.Current.MainDisplayInfo.Height >= SettingsService.Read(SettingsKeys.LastHeight) &&
            DeviceDisplay.Current.MainDisplayInfo.Width >= SettingsService.Read(SettingsKeys.LastWidth))
            {
	            window.Height = SettingsService.Read(SettingsKeys.LastHeight);
	            window.Width = SettingsService.Read(SettingsKeys.LastWidth);
            }
            else
            {
	            window.Height = SettingsService.GetDefault(SettingsKeys.LastHeight);
	            window.Width = SettingsService.GetDefault(SettingsKeys.LastWidth);
            }
            
            if (DeviceDisplay.Current.MainDisplayInfo.Height > SettingsService.Read(SettingsKeys.LastYPosition) &&
            DeviceDisplay.Current.MainDisplayInfo.Width > SettingsService.Read(SettingsKeys.LastXPosition))
            {
	            window.Y = SettingsService.Read(SettingsKeys.LastYPosition);
	            window.X = SettingsService.Read(SettingsKeys.LastXPosition);
            }
        }
        
        window.MinimumHeight = SettingsService.GetDefault(SettingsKeys.LastHeight);
        window.MinimumWidth = SettingsService.GetDefault(SettingsKeys.LastWidth);
        return window;
    }
	
	public override void CloseWindow(Window window)
	{
		if (DeviceInfo.Current.Idiom == DeviceIdiom.Desktop)
		{
			SettingsService.Write(SettingsKeys.LastHeight, window.Height);
			SettingsService.Write(SettingsKeys.LastWidth, window.Width);
			SettingsService.Write(SettingsKeys.LastYPosition, window.Y);
			SettingsService.Write(SettingsKeys.LastXPosition, window.X);
		}
		base.CloseWindow(window);
	}
}
