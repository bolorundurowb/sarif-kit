using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A network or remote access point.
/// </summary>
public sealed class Address
{
    /// <summary>
    /// An integer that uniquely identifies this address within its parent context.
    /// </summary>
    [JsonPropertyName("absoluteAddress")]
    public long? AbsoluteAddress { get; init; }

    /// <summary>
    /// The address expressed as a relative offset from another address.
    /// </summary>
    [JsonPropertyName("relativeAddress")]
    public long? RelativeAddress { get; init; }

    /// <summary>
    /// The index within the run addresses array of the parent address.
    /// </summary>
    [JsonPropertyName("parentIndex")]
    public int? ParentIndex { get; init; }

    /// <summary>
    /// A string that identifies the address kind.
    /// </summary>
    [JsonPropertyName("kind")]
    public string? Kind { get; init; }

    /// <summary>
    /// A string that provides additional information about the address.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// A string that is a fully qualified name associated with the address.
    /// </summary>
    [JsonPropertyName("fullyQualifiedName")]
    public string? FullyQualifiedName { get; init; }

    /// <summary>
    /// The byte offset of this address from the absolute or relative address of the parent.
    /// </summary>
    [JsonPropertyName("offsetFromParent")]
    public long? OffsetFromParent { get; init; }

    /// <summary>
    /// The index of this address within the parent context.
    /// </summary>
    [JsonPropertyName("index")]
    public int? Index { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the address.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
