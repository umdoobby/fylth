using System.Text.Json.Serialization;

namespace Fylth.Models.E621;

public class Relationships
{
    [JsonPropertyName("parent_id")]
    public int? ParentId { get; set; }

    [JsonPropertyName("has_children")]
    public bool HasChildren { get; set; }

    [JsonPropertyName("has_active_children")]
    public bool HasActiveChildren { get; set; }

    [JsonPropertyName("children")]
    public List<int> Children { get; set; }
}