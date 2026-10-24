using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Represents the contents of an artifact.
/// </summary>
public sealed class ArtifactContent
{
    /// <summary>
    /// UTF-8-encoded text content of the artifact.
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text { get; init; }

    /// <summary>
    /// Base64-encoded binary content of the artifact.
    /// </summary>
    [JsonPropertyName("binary")]
    public string? Binary { get; init; }

    /// <summary>
    /// The rendered text content of the artifact.
    /// </summary>
    [JsonPropertyName("rendered")]
    public MultiformatMessageString? Rendered { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the artifact content.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
