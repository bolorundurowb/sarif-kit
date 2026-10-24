using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A message string that can be rendered as plain text or Markdown.
/// </summary>
public sealed class MultiformatMessageString
{
    /// <summary>
    /// A plain text message string.
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; init; }

    /// <summary>
    /// A Markdown message string.
    /// </summary>
    [JsonPropertyName("markdown")]
    public string? Markdown { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the message.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
