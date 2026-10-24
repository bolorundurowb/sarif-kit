using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// The replacement of a single region of an artifact.
/// </summary>
public sealed class Replacement
{
    /// <summary>
    /// A region of the artifact to delete.
    /// </summary>
    [JsonPropertyName("deletedRegion")]
    public required Region DeletedRegion { get; init; }

    /// <summary>
    /// The content to insert at the location specified by the deleted region.
    /// </summary>
    [JsonPropertyName("insertedContent")]
    public ArtifactContent? InsertedContent { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the replacement.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
