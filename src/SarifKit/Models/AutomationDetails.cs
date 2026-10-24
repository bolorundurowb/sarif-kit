using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Information that describes the relation of a result to a set of runs.
/// </summary>
public sealed class AutomationDetails
{
    /// <summary>
    /// A description of the identity and role played within the engineering system by this result.
    /// </summary>
    [JsonPropertyName("description")]
    public Message? Description { get; init; }

    /// <summary>
    /// A string that identifies the result within a run.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// A stable, unique identifier for the result, in the form of a GUID.
    /// </summary>
    [JsonPropertyName("guid")]
    public string? Guid { get; init; }

    /// <summary>
    /// A dictionary of additional strings that can be used to identify the result.
    /// </summary>
    [JsonPropertyName("correlationGuid")]
    public string? CorrelationGuid { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the automation details.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
