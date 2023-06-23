using System.Text.Json.Serialization;

namespace Fylth.Models.E621;

public class Score
{
    [JsonPropertyName("up")]
    public int Up { get; set; }

    [JsonPropertyName("down")]
    public int Down { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }
}