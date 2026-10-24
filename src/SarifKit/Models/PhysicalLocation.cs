using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A physical location relevant to a result.
/// </summary>
public sealed class PhysicalLocation
{
    /// <summary>
    /// The location of the artifact.
    /// </summary>
    [JsonPropertyName("artifactLocation")]
    public ArtifactLocation? ArtifactLocation { get; init; }

    /// <summary>
    /// Specifies a portion of the artifact.
    /// </summary>
    [JsonPropertyName("region")]
    public Region? Region { get; init; }

    /// <summary>
    /// The portion of the artifact that encloses the region.
    /// </summary>
    [JsonPropertyName("contextRegion")]
    public Region? ContextRegion { get; init; }

    /// <summary>
    /// The address of the location within the program or process.
    /// </summary>
    [JsonPropertyName("address")]
    public Address? Address { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the physical location.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
