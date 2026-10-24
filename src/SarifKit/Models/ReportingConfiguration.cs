using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Contains information about how a reporting descriptor can be configured.
/// </summary>
public sealed class ReportingConfiguration
{
    /// <summary>
    /// Specifies whether the report is enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; init; }

    /// <summary>
    /// Specifies the default failure level for the report.
    /// </summary>
    [JsonPropertyName("defaultLevel")]
    public FailureLevel? DefaultLevel { get; init; }

    /// <summary>
    /// Specifies the default rank for the report.
    /// </summary>
    [JsonPropertyName("defaultRank")]
    public double? DefaultRank { get; init; }

    /// <summary>
    /// Contains configuration information specific to a report.
    /// </summary>
    [JsonPropertyName("parameters")]
    public IReadOnlyDictionary<string, JsonElement>? Parameters { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the configuration.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
