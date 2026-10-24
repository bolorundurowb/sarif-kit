using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A logical location such as a namespace, type, or function.
/// </summary>
public sealed class LogicalLocation
{
    /// <summary>
    /// Identifies the construct in which the result occurred.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// The index into the run logicalLocations array of the parent logical location.
    /// </summary>
    [JsonPropertyName("index")]
    public int? Index { get; init; }

    /// <summary>
    /// The fully qualified name of the logical location.
    /// </summary>
    [JsonPropertyName("fullyQualifiedName")]
    public string? FullyQualifiedName { get; init; }

    /// <summary>
    /// The logical location kind.
    /// </summary>
    [JsonPropertyName("kind")]
    public string? Kind { get; init; }

    /// <summary>
    /// The machine-readable name for the logical location.
    /// </summary>
    [JsonPropertyName("decoratedName")]
    public string? DecoratedName { get; init; }

    /// <summary>
    /// Identifies the parent logical location.
    /// </summary>
    [JsonPropertyName("parentIndex")]
    public int? ParentIndex { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the logical location.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
