using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// The location of an artifact.
/// </summary>
public sealed class ArtifactLocation
{
    /// <summary>
    /// A string containing a valid relative or absolute URI.
    /// </summary>
    [JsonPropertyName("uri")]
    public string? Uri { get; init; }

    /// <summary>
    /// A string that identifies the artifact associated with the location.
    /// </summary>
    [JsonPropertyName("uriBaseId")]
    public string? UriBaseId { get; init; }

    /// <summary>
    /// The index within the run artifacts array of the artifact object associated with the artifact location.
    /// </summary>
    [JsonPropertyName("index")]
    public int? Index { get; init; }

    /// <summary>
    /// A description of the identity and role of this artifact location.
    /// </summary>
    [JsonPropertyName("description")]
    public Message? Description { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the artifact location.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
