using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A suppression that is relevant to a result.
/// </summary>
public sealed class Suppression
{
    /// <summary>
    /// A stable, unique identifier for the suppression in the form of a GUID.
    /// </summary>
    [JsonPropertyName("guid")]
    public string? Guid { get; init; }

    /// <summary>
    /// A value that indicates where the suppression is persisted.
    /// </summary>
    [JsonPropertyName("kind")]
    public required SuppressionKind Kind { get; init; }

    /// <summary>
    /// A value that indicates the review status of the suppression.
    /// </summary>
    [JsonPropertyName("status")]
    public SuppressionStatus? Status { get; init; }

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
    /// Key/value pairs that provide additional information about the suppression.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
