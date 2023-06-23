using System.Text.Json.Serialization;
using Fylth.Models.E621;

namespace Fylth.Models;

public class GetPostsResponse
{
    [JsonPropertyName("posts")]
    public List<Post> Posts { get; set; }
}