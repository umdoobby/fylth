namespace Fylth.Models.Settings;

/// <summary>
/// A complete list of every setting accessed and used by Fylth.
/// Settings are saved and read via key/value pairs with a constant default value.
/// This serves as a singular repository of every key and it's default value.
/// </summary>
public static class SettingsKeys
{
    /// <summary>
    /// Determines the color scheme the app should use.
    /// Supports string values.
    /// Default value is an empty string.
    /// This value is empty when the app should try to match the device's theme.
    /// </summary>
    public static Settings<string> Theme => new("appTheme", "");
    
    /// <summary>
    /// On desktop platforms, this is used to know what width the window should be when it is opened
    /// Default value is 800.0
    /// </summary>
    public static Settings<double> LastWidth => new("lastWidth", 800);
    
    /// <summary>
    /// On desktop platforms, this is used to know what height the window should be when it is opened
    /// Default value is 600.0
    /// </summary>
    public static Settings<double> LastHeight => new("lastHeight", 600);

    /// <summary>
    /// On desktop platforms, this is used to know if the window should be maximized when it is opened
    /// Default value is false
    /// </summary>
    public static Settings<bool> WasMaximized => new("wasMaximized", false);
    
    /// <summary>
    /// On desktop platforms, this is used to store the previous X coordinate of the main window on the screen
    /// Default value is 50
    /// </summary>
    public static Settings<double> LastXPosition => new("lastXPosition", 50);
    
    /// <summary>
    /// On desktop platforms, this is used to store the previous Y coordinate of the main window on the screen
    /// Default value is 50
    /// </summary>
    public static Settings<double> LastYPosition => new("lastYPosition", 50);

    /// <summary>
    /// The username used to sign into e621.
    /// Supports string values.
    /// Default value is an empty string.
    /// This value is empty when the user is not logged in.
    /// </summary>
    public static Settings<string> E621Username => new("e621Username", "");
    
    /// <summary>
    /// The API key used to sign into e621.
    /// Supports string values.
    /// Default value is an empty string.
    /// This value is empty when the user is not logged in.
    /// </summary>
    public static Settings<string> E621ApiKey => new("e621ApiKey", "");

    /// <summary>
    /// A boolean used on first launch to tell if the client needs to look for any login credentials or not.
    /// This boolean should not be saved in the secure store as that is slower and more failure prone.
    /// Supports boolean values only.
    /// Default value is 'false'.
    /// </summary>
    public static Settings<bool> E621IsLoggedIn => new("e621IsLoggedIn", false);
    
    /// <summary>
    /// Determines if any usernames, passwords, and/or API keys should be stored using the devices native secure storage.
    /// Supports boolean values only.
    /// Default value is 'true'.
    /// </summary>
    public static Settings<bool> UseSecureStore => new("useSecureStore", true);
    
    /// <summary>
    /// Determines how the preview image fits in the preview frame.
    /// 'true' means to use the 'AspectFill' option.
    /// 'false' means to use the 'AspectFit' option.
    /// Supports boolean values only.
    /// Default value is 'false'.
    /// </summary>
    public static Settings<bool> FillPreview => new("fillPreview", false);

    /// <summary>
    /// Determines if the video player should be muted when it first appears.
    /// Supports boolean values only.
    /// Default value is 'true'.
    /// </summary>
    public static Settings<bool> VideoShouldMute => new("videoShouldMute", true);
    
    /// <summary>
    /// Determines if the video player should loop the video playback when it first appears.
    /// Supports boolean values only.
    /// Default value is 'true'.
    /// </summary>
    public static Settings<bool> VideoShouldLoop => new("videoShouldLoop", true);
    
    /// <summary>
    /// Determines the initial volume of the video player when it first appears.
    /// Supports double values only.
    /// Default value is '0.75'.
    /// This value only supports numbers between 0 and 1.
    /// </summary>
    public static Settings<double> VideoDefaultVolume => new("videoDefaultVolume", 0.75);
    
    /// <summary>
    /// Determines if the video player should immediately begin the video playback when it first appears.
    /// Supports boolean values only.
    /// Default value is 'false'.
    /// </summary>
    public static Settings<bool> VideoShouldAutoplay => new("videoShouldAutoplay", false);
}