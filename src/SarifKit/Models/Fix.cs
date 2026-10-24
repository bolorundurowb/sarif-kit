using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A proposed fix for the problem indicated by a result.
/// </summary>
public sealed class Fix
{
    /// <summary>
    /// A message that describes the proposed fix.
    /// </summary>
    [JsonPropertyName("description")]
    public Message? Description { get; init; }

    /// <summary>
    /// One or more artifact changes that comprise the fix.
    /// </summary>
    [JsonPropertyName("artifactChanges")]
    public required IReadOnlyList<ArtifactChange> ArtifactChanges { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the fix.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
