using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Specifies locations that are special within the run.
/// </summary>
public sealed class SpecialLocations
{
    /// <summary>
    /// A location that is relevant to the run as a whole, which serves as the base for displaying artifact locations.
    /// </summary>
    [JsonPropertyName("displayBase")]
    public ArtifactLocation? DisplayBase { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the special locations.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
