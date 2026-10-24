using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Identifies a particular toolComponent object, along with its tool component.
/// </summary>
public sealed class ReportingDescriptorReference
{
    /// <summary>
    /// The id of the report.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// The GUID of the report.
    /// </summary>
    [JsonPropertyName("guid")]
    public string? Guid { get; init; }

    /// <summary>
    /// A reference used to locate the toolComponent for this report.
    /// </summary>
    [JsonPropertyName("toolComponent")]
    public ToolComponentReference? ToolComponent { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the reference.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
