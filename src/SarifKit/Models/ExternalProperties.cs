using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// The top-level object in an external property file.
/// </summary>
public sealed class ExternalProperties
{
    /// <summary>
    /// The SARIF version of this external property file.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; init; } = "2.1.0";

    /// <summary>
    /// The URI of the JSON schema against which this document may be validated.
    /// </summary>
    [JsonPropertyName("$schema")]
    public string? Schema { get; init; }

    /// <summary>
    /// A SARIF run object.
    /// </summary>
    [JsonPropertyName("runGuid")]
    public string? RunGuid { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the external properties.
    /// </summary>
    [JsonPropertyName("conversion")]
    public Tool? Conversion { get; init; }

    /// <summary>
    /// A list of file objects representing the artifacts relevant to the run.
    /// </summary>
    [JsonPropertyName("artifacts")]
    public IReadOnlyList<Artifact>? Artifacts { get; init; }

    /// <summary>
    /// A list of invocation objects describing the invocations of analysis tools.
    /// </summary>
    [JsonPropertyName("invocations")]
    public IReadOnlyList<Invocation>? Invocations { get; init; }

    /// <summary>
    /// A list of logical locations.
    /// </summary>
    [JsonPropertyName("logicalLocations")]
    public IReadOnlyList<LogicalLocation>? LogicalLocations { get; init; }

    /// <summary>
    /// A list of threadFlowLocation objects cached at the run level.
    /// </summary>
    [JsonPropertyName("threadFlowLocations")]
    public IReadOnlyList<ThreadFlowLocation>? ThreadFlowLocations { get; init; }

    /// <summary>
    /// A list of result objects representing the results of the run.
    /// </summary>
    [JsonPropertyName("results")]
    public IReadOnlyList<Result>? Results { get; init; }

    /// <summary>
    /// An array of toolComponent objects relevant to a taxonomy or taxonomies.
    /// </summary>
    [JsonPropertyName("taxonomies")]
    public IReadOnlyList<ToolComponent>? Taxonomies { get; init; }

    /// <summary>
    /// Addresses associated with this run instance, if any.
    /// </summary>
    [JsonPropertyName("addresses")]
    public IReadOnlyList<Address>? Addresses { get; init; }

    /// <summary>
    /// The set of locations known at the run level.
    /// </summary>
    [JsonPropertyName("driver")]
    public ToolComponent? Driver { get; init; }

    /// <summary>
    /// Tool extensions that contributed to or reconfigured the analysis tool.
    /// </summary>
    [JsonPropertyName("extensions")]
    public IReadOnlyList<ToolComponent>? Extensions { get; init; }

    /// <summary>
    /// Tool policies.
    /// </summary>
    [JsonPropertyName("policies")]
    public IReadOnlyList<ToolComponent>? Policies { get; init; }

    /// <summary>
    /// Tool translations.
    /// </summary>
    [JsonPropertyName("translations")]
    public IReadOnlyList<ToolComponent>? Translations { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the external properties.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
