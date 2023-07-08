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

        window.MinimumHeight = SettingsService.GetDefault(SettingsKeys.LastHeight);
        window.MinimumWidth = SettingsService.GetDefault(SettingsKeys.LastWidth);
        return window;
    }
}
