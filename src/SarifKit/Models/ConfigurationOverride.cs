using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Information about how a specific rule or notification was reconfigured at runtime.
/// </summary>
public sealed class ConfigurationOverride
{
    /// <summary>
    /// Specifies how the rule or notification was configured during the scan.
    /// </summary>
    [JsonPropertyName("configuration")]
    public required ReportingConfiguration Configuration { get; init; }

    /// <summary>
    /// A reference used to locate the descriptor whose configuration was overridden.
    /// </summary>
    [JsonPropertyName("descriptor")]
    public required ReportingDescriptorReference Descriptor { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the configuration override.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
