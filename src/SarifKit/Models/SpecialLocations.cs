using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Specifies locations that are special within the run.
/// </summary>
public sealed class SpecialLocations
{
    /// <summary>
    /// Provides a location to display for this run if no other locations are available.
    /// </summary>
    [JsonPropertyName("displayLocation")]
    public Location? DisplayLocation { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the special locations.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
