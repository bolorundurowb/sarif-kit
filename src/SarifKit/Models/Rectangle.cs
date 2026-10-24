using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// An area within an image.
/// </summary>
public sealed class Rectangle
{
    /// <summary>
    /// The Y coordinate of the top edge of the rectangle, measured in the image's natural units.
    /// </summary>
    [JsonPropertyName("top")]
    public double? Top { get; init; }

    /// <summary>
    /// The X coordinate of the left edge of the rectangle, measured in the image's natural units.
    /// </summary>
    [JsonPropertyName("left")]
    public double? Left { get; init; }

    /// <summary>
    /// The Y coordinate of the bottom edge of the rectangle, measured in the image's natural units.
    /// </summary>
    [JsonPropertyName("bottom")]
    public double? Bottom { get; init; }

    /// <summary>
    /// The X coordinate of the right edge of the rectangle, measured in the image's natural units.
    /// </summary>
    [JsonPropertyName("right")]
    public double? Right { get; init; }

    /// <summary>
    /// A message relevant to the rectangle.
    /// </summary>
    [JsonPropertyName("message")]
    public Message? Message { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the rectangle.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
