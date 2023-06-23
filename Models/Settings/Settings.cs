#nullable enable
namespace Fylth.Models.Settings;

public class Settings<T>: ISettings
{
    #region Public variables

    /// <summary>
    /// The name or key for this setting.
    /// </summary>
    public string Key { get; private set; }
    
    /// <summary>
    /// The default value for a given setting.
    /// </summary>
    public T DefaultValue { get; private set; }

    /// <summary>
    /// Optional container name for shared settings.
    /// </summary>
    public string? ContainerName { get; private set; }

    #endregion

    
    #region Constructors

    /// <summary>
    /// Creates a new instance of a settings option
    /// </summary>
    /// <param name="key">String name of the option</param>
    /// <param name="defaultValue">The default value for this setting</param>
    public Settings(string key, T defaultValue)
    {
        Key = key;
        DefaultValue = defaultValue;
        ContainerName = null;
    }

    /// <summary>
    /// Creates a new instance of a settings option
    /// </summary>
    /// <param name="key">String name of the option</param>
    /// <param name="defaultValue">The default value for this setting</param>
    /// <param name="containerName">Optional shared container for this setting</param>
    public Settings(string key, T defaultValue, string containerName)
    {
        Key = key;
        DefaultValue = defaultValue;
        ContainerName = containerName;
    }

    #endregion
    

    #region Methods

    /// <summary>
    /// The string representation of a setting's key used as the key part of the key/value pairs used to store user preferences.
    /// </summary>
    /// <returns>Settings key as a string.</returns>
    public override string ToString()
    {
        return Key;
    }

    #endregion
}