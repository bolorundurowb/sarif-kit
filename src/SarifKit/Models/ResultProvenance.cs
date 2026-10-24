using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Contains information about how and when a result was detected.
/// </summary>
public sealed class ResultProvenance
{
    /// <summary>
    /// A description of the result provenance.
    /// </summary>
    [JsonPropertyName("firstDetectionTimeUtc")]
    public DateTimeOffset? FirstDetectionTimeUtc { get; init; }

    /// <summary>
    /// The Coordinated Universal Time (UTC) date and time at which the result was last detected.
    /// </summary>
    [JsonPropertyName("lastDetectionTimeUtc")]
    public DateTimeOffset? LastDetectionTimeUtc { get; init; }

    /// <summary>
    /// A string that identifies the invocation instance within which the result was detected.
    /// </summary>
    [JsonPropertyName("invocationIndex")]
    public int? InvocationIndex { get; init; }

    /// <summary>
    /// A GUID-valued string equal to the automationDetails.guid property of the run in which the result was first detected.
    /// </summary>
    [JsonPropertyName("firstDetectionRunGuid")]
    public string? FirstDetectionRunGuid { get; init; }

    /// <summary>
    /// A GUID-valued string equal to the automationDetails.guid property of the run in which the result was most recently detected.
    /// </summary>
    [JsonPropertyName("lastDetectionRunGuid")]
    public string? LastDetectionRunGuid { get; init; }

    /// <summary>
    /// An array of physicalLocation objects which specify the portions of an analysis tool's output that a converter
    /// transformed into the result.
    /// </summary>
    [JsonPropertyName("conversionSources")]
    public IReadOnlyList<PhysicalLocation>? ConversionSources { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the result provenance.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
