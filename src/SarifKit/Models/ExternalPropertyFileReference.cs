using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Contains information that enables a SARIF consumer to locate the external property file that contains the value of a property.
/// </summary>
public sealed class ExternalPropertyFileReference
{
    /// <summary>
    /// The location of the external property file.
    /// </summary>
    [JsonPropertyName("location")]
    public ArtifactLocation? Location { get; init; }

    /// <summary>
    /// A stable, unique identifier for the external property file.
    /// </summary>
    [JsonPropertyName("guid")]
    public string? Guid { get; init; }

    /// <summary>
    /// A non-negative integer specifying the number of items in the external property file.
    /// </summary>
    [JsonPropertyName("itemCount")]
    public int? ItemCount { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the external property file reference.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
