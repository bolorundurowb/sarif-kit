using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A change to a single artifact.
/// </summary>
public sealed class ArtifactChange
{
    /// <summary>
    /// The location of the artifact to change.
    /// </summary>
    [JsonPropertyName("artifactLocation")]
    public required ArtifactLocation ArtifactLocation { get; init; }

    /// <summary>
    /// An array of replacement objects, each of which represents the replacement of a single region.
    /// </summary>
    [JsonPropertyName("replacements")]
    public required IReadOnlyList<Replacement> Replacements { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the artifact change.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
