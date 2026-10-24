using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A request to suppress a result.
/// </summary>
public sealed class Suppression
{
    /// <summary>
    /// A string that indicates where the suppression is persisted.
    /// </summary>
    [JsonPropertyName("kind")]
    public required string Kind { get; init; }

    /// <summary>
    /// A string that indicates the status of the suppression.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// A string representing the justification for the suppression.
    /// </summary>
    [JsonPropertyName("justification")]
    public string? Justification { get; init; }

    /// <summary>
    /// Identifies the location associated with the suppression.
    /// </summary>
    [JsonPropertyName("location")]
    public Location? Location { get; init; }

    /// <summary>
    /// A string that indicates the identity and version of the tool that created the suppression.
    /// </summary>
    [JsonPropertyName("guid")]
    public string? Guid { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the suppression.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
