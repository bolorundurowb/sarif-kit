using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// An artifact relevant to a result.
/// </summary>
public sealed class Attachment
{
    /// <summary>
    /// A message describing the role played by the attachment.
    /// </summary>
    [JsonPropertyName("description")]
    public Message? Description { get; init; }

    /// <summary>
    /// The location of the attachment.
    /// </summary>
    [JsonPropertyName("artifactLocation")]
    public required ArtifactLocation ArtifactLocation { get; init; }

    /// <summary>
    /// An array of regions of interest within the attachment.
    /// </summary>
    [JsonPropertyName("regions")]
    public IReadOnlyList<Region>? Regions { get; init; }

    /// <summary>
    /// An array of rectangles specifying areas of interest within the image.
    /// </summary>
    [JsonPropertyName("rectangles")]
    public IReadOnlyList<Rectangle>? Rectangles { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the attachment.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
