using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Information that describes a single run.
/// </summary>
public sealed class RunAutomationDetails
{
    /// <summary>
    /// A description of the identity and role played within the engineering system by this object's containing run object.
    /// </summary>
    [JsonPropertyName("description")]
    public Message? Description { get; init; }

    /// <summary>
    /// A stable, unique identifier for the run.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// A stable, unique identifier for the run, in the form of a GUID.
    /// </summary>
    [JsonPropertyName("guid")]
    public string? Guid { get; init; }

    /// <summary>
    /// A dictionary of additional strings that can be used to identify the run.
    /// </summary>
    [JsonPropertyName("correlationGuid")]
    public string? CorrelationGuid { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the run automation details.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
