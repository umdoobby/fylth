#nullable enable
namespace Fylth.Models.Settings;

public interface ISettings
{
    string Key { get; }
    string? ContainerName { get; }
}