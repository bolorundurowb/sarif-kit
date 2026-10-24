using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A region within an artifact where a result was detected.
/// </summary>
public sealed class Region
{
    /// <summary>
    /// The line number of the first character in the region.
    /// </summary>
    [JsonPropertyName("startLine")]
    public int? StartLine { get; init; }

    /// <summary>
    /// The column number of the first character in the region.
    /// </summary>
    [JsonPropertyName("startColumn")]
    public int? StartColumn { get; init; }

    /// <summary>
    /// The line number of the last character in the region.
    /// </summary>
    [JsonPropertyName("endLine")]
    public int? EndLine { get; init; }

    /// <summary>
    /// The column number of the last character in the region.
    /// </summary>
    [JsonPropertyName("endColumn")]
    public int? EndColumn { get; init; }

    /// <summary>
    /// The zero-based offset from the beginning of the artifact.
    /// </summary>
    [JsonPropertyName("charOffset")]
    public int? CharOffset { get; init; }

    /// <summary>
    /// The length of the region in characters.
    /// </summary>
    [JsonPropertyName("charLength")]
    public int? CharLength { get; init; }

    /// <summary>
    /// The zero-based offset from the beginning of the artifact in bytes.
    /// </summary>
    [JsonPropertyName("byteOffset")]
    public int? ByteOffset { get; init; }

    /// <summary>
    /// The length of the region in bytes.
    /// </summary>
    [JsonPropertyName("byteLength")]
    public int? ByteLength { get; init; }

    /// <summary>
    /// The portion of the artifact contents within the region.
    /// </summary>
    [JsonPropertyName("snippet")]
    public ArtifactContent? Snippet { get; init; }

    /// <summary>
    /// A message relevant to the region.
    /// </summary>
    [JsonPropertyName("message")]
    public Message? Message { get; init; }

    /// <summary>
    /// Specifies the unit for measuring columns.
    /// </summary>
    [JsonPropertyName("sourceLanguage")]
    public string? SourceLanguage { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the region.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
