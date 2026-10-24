using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A location relevant to an SARIF result.
/// </summary>
public sealed class Location
{
    /// <summary>
    /// A value that uniquely identifies this location within its parent run.
    /// </summary>
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    /// <summary>
    /// Identifies the artifact and region.
    /// </summary>
    [JsonPropertyName("physicalLocation")]
    public PhysicalLocation? PhysicalLocation { get; init; }

    /// <summary>
    /// The logical location such as a namespace, type, or function.
    /// </summary>
    [JsonPropertyName("logicalLocations")]
    public IReadOnlyList<LogicalLocation>? LogicalLocations { get; init; }

    /// <summary>
    /// A message relevant to the location.
    /// </summary>
    [JsonPropertyName("message")]
    public Message? Message { get; init; }

    /// <summary>
    /// A set of regions relevant to the location.
    /// </summary>
    [JsonPropertyName("annotations")]
    public IReadOnlyList<Region>? Annotations { get; init; }

    /// <summary>
    /// An array of objects that describe relationships between this location and others.
    /// </summary>
    [JsonPropertyName("relationships")]
    public IReadOnlyList<LocationRelationship>? Relationships { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the location.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
