using System.Text.Json.Serialization;

namespace Fylth.Models.E621;

public class Sample
{
    [JsonPropertyName("has")]
    public bool Has { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("alternates")]
    public Alternates Alternates { get; set; }
}