using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Encapsulates a message intended to be read by the user.
/// </summary>
public sealed class Message
{
    /// <summary>
    /// A plain text message string.
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text { get; init; }

    /// <summary>
    /// A Markdown message string.
    /// </summary>
    [JsonPropertyName("markdown")]
    public string? Markdown { get; init; }

    /// <summary>
    /// The identifier for the message within the message table.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// An array of strings to substitute into the message string.
    /// </summary>
    [JsonPropertyName("arguments")]
    public IReadOnlyList<string>? Arguments { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the message.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
