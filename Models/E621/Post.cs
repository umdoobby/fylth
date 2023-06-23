using System.Text.Json.Serialization;

namespace Fylth.Models.E621;

public class Post
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("file")]
    public File File { get; set; }

    [JsonPropertyName("preview")]
    public Preview Preview { get; set; }

    [JsonPropertyName("sample")]
    public Sample Sample { get; set; }

    [JsonPropertyName("score")]
    public Score Score { get; set; }

    [JsonPropertyName("tags")]
    public Tags Tags { get; set; }

    [JsonPropertyName("locked_tags")]
    public List<object> LockedTags { get; set; }

    [JsonPropertyName("change_seq")]
    public int ChangeSeq { get; set; }

    [JsonPropertyName("flags")]
    public Flags Flags { get; set; }

    [JsonPropertyName("rating")]
    public string Rating { get; set; }

    [JsonPropertyName("fav_count")]
    public int FavCount { get; set; }

    [JsonPropertyName("sources")]
    public List<string> Sources { get; set; }

    [JsonPropertyName("pools")]
    public List<object> Pools { get; set; }

    [JsonPropertyName("relationships")]
    public Relationships Relationships { get; set; }

    [JsonPropertyName("approver_id")]
    public object ApproverId { get; set; }

    [JsonPropertyName("uploader_id")]
    public int UploaderId { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("comment_count")]
    public int CommentCount { get; set; }

    [JsonPropertyName("is_favorited")]
    public bool IsFavorited { get; set; }

    [JsonPropertyName("has_notes")]
    public bool HasNotes { get; set; }

    [JsonPropertyName("duration")]
    public object Duration { get; set; }
}