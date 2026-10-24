using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Describes the relationship between a result and a related reporting descriptor.
/// </summary>
public sealed class ReportingDescriptorRelationship
{
    /// <summary>
    /// A reference to the related reporting descriptor.
    /// </summary>
    [JsonPropertyName("target")]
    public required ReportingDescriptorReference Target { get; init; }

    /// <summary>
    /// A set of distinct strings that specify the nature of the relationship.
    /// </summary>
    [JsonPropertyName("kinds")]
    public IReadOnlyList<string>? Kinds { get; init; }

    /// <summary>
    /// A description of the relationship.
    /// </summary>
    [JsonPropertyName("description")]
    public Message? Description { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the relationship.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
