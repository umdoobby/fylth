﻿using System.Text.Json.Serialization;

namespace Fylth.Models.E621;

public class Flags
{
    [JsonPropertyName("pending")]
    public bool Pending { get; set; }

    [JsonPropertyName("flagged")]
    public bool Flagged { get; set; }

    [JsonPropertyName("note_locked")]
    public bool NoteLocked { get; set; }

    [JsonPropertyName("status_locked")]
    public bool StatusLocked { get; set; }

    [JsonPropertyName("rating_locked")]
    public bool RatingLocked { get; set; }

    [JsonPropertyName("comment_disabled")]
    public bool CommentDisabled { get; set; }

    [JsonPropertyName("deleted")]
    public bool Deleted { get; set; }
}