using System.Text.Json.Serialization;

namespace Fylth.Models.E621;

public class Tags
{
    [JsonPropertyName("general")]
    public List<string> General { get; set; }

    [JsonPropertyName("species")]
    public List<string> Species { get; set; }

    [JsonPropertyName("character")]
    public List<string> Character { get; set; }

    [JsonPropertyName("copyright")]
    public List<string> Copyright { get; set; }

    [JsonPropertyName("artist")]
    public List<string> Artist { get; set; }

    [JsonPropertyName("invalid")]
    public List<object> Invalid { get; set; }

    [JsonPropertyName("lore")]
    public List<object> Lore { get; set; }

    [JsonPropertyName("meta")]
    public List<string> Meta { get; set; }
}