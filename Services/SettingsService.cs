using Fylth.Models.Settings;

namespace Fylth.Services;

/// <summary>
/// Common class to make reading and writing to the settings easier.
/// </summary>
public static class SettingsService
{
    /// <summary>
    /// Check to see if a settings key exists on the device
    /// </summary>
    /// <param name="key">Settings key to check for</param>
    /// <returns>True if the key was found on the device, false if it wasn't</returns>
    public static bool Contains(ISettings key)
    {
        return Preferences.Default.ContainsKey(key.Key);
    }

    /// <summary>
    /// Saves a setting to the device
    /// </summary>
    /// <param name="key">Settings key to save the setting as</param>
    /// <param name="value">New value to write to the the settings</param>
    /// <typeparam name="T">Type of the value being saved</typeparam>
    public static void Write<T>(Settings<T> key, T value)
    {
        Preferences.Default.Set(key.Key, value, key.ContainerName);
    }

    /// <summary>
    /// Reads a setting from the device if it's present, otherwise it returns the default value from the settings key
    /// </summary>
    /// <param name="key">Settings key to read from the settings</param>
    /// <typeparam name="T">Type of value to be read from the settings</typeparam>
    /// <returns>Value read from the device or default value for the settings key</returns>
    public static T Read<T>(Settings<T> key)
    {
        return Preferences.Default.Get(key.Key, key.DefaultValue, key.ContainerName);
    }
    
    /// <summary>
    /// Reads the default value for a settings key
    /// </summary>
    /// <param name="key">Settings key to read the default value from</param>
    /// <typeparam name="T">Type of value for the given settings key</typeparam>
    /// <returns>The default value for the settings key</returns>
    public static T GetDefault<T>(Settings<T> key)
    {
        return key.DefaultValue;
    }

    /// <summary>
    /// Deletes a setting from the device
    /// </summary>
    /// <param name="key">Settings key to be deleted from the device</param>
    public static void Delete(ISettings key)
    {
        Preferences.Default.Remove(key.Key, key.ContainerName);
    }

    /// <summary>
    /// Deletes all settings on the device
    /// </summary>
    public static void DeleteAll()
    {
        Preferences.Default.Clear();
    }
    
    /// <summary>
    /// Deletes all settings in the container for that settings key
    /// </summary>
    /// <param name="key">Settings key for what container to delete all keys from</param>
    public static void DeleteAll(ISettings key)
    {
        Preferences.Default.Clear(key.ContainerName);
    }

    /// <summary>
    /// Saves a setting to the device's secure storage, only strings are supported
    /// </summary>
    /// <param name="key">Settings key to save the setting as</param>
    /// <param name="value">New value to write to the the settings</param>
    /// <returns>Task of the save operation</returns>
    public static Task WriteSecure(Settings<string> key, string value)
    {
        return SecureStorage.Default.SetAsync(key.Key, value);
    }

    /// <summary>
    /// Reads a setting from the device's secure storage, only strings are supported
    /// </summary>
    /// <param name="key">Settings key to read from the settings</param>
    /// <returns>Value read from the device or default value for the settings key</returns>
    public static Task<string> ReadSecure(Settings<string> key)
    {
        return SecureStorage.Default.GetAsync(key.Key);
    }
    
    /// <summary>
    /// Deletes a setting from the device's secure storage
    /// </summary>
    /// <param name="key">Settings key to be deleted from the device</param>
    /// <returns>True if the setting was deleted, false if it failed</returns>
    public static bool DeleteSecure(ISettings key)
    {
        return SecureStorage.Default.Remove(key.Key);
    }

    /// <summary>
    /// Deletes all settings from the device's secure  
    /// </summary>
    public static void DeleteAllSecure()
    {
        SecureStorage.Default.RemoveAll();
    }
    
    /// <summary>
    /// Encodes a string into a Base64 string
    /// </summary>
    /// <param name="plainText">Text to be encoded</param>
    /// <returns>Base64 encoded string</returns>
    public static string Base64Encode(string plainText) 
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }
    
    /// <summary>
    /// Decodes a Base64 string into plain text
    /// </summary>
    /// <param name="base64EncodedData">Text to be decoded</param>
    /// <returns>Plain text decoded string</returns>
    public static string Base64Decode(string base64EncodedData) 
    {
        var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }

}