using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Contains information that enables a SARIF consumer to locate the external property file that contains the value of a property.
/// </summary>
public sealed class ExternalPropertyFileReferences
{
    /// <summary>
    /// An external property file containing a run.conversion object.
    /// </summary>
    [JsonPropertyName("conversion")]
    public ExternalPropertyFileReference? Conversion { get; init; }

    /// <summary>
    /// An array of external property files containing a run.graphs object.
    /// </summary>
    [JsonPropertyName("graphs")]
    public IReadOnlyList<ExternalPropertyFileReference>? Graphs { get; init; }

    /// <summary>
    /// An external property file containing a run.properties object.
    /// </summary>
    [JsonPropertyName("externalizedProperties")]
    public ExternalPropertyFileReference? ExternalizedProperties { get; init; }

    /// <summary>
    /// An array of external property files containing run.artifacts.
    /// </summary>
    [JsonPropertyName("artifacts")]
    public IReadOnlyList<ExternalPropertyFileReference>? Artifacts { get; init; }

    /// <summary>
    /// An array of external property files containing run.invocations.
    /// </summary>
    [JsonPropertyName("invocations")]
    public IReadOnlyList<ExternalPropertyFileReference>? Invocations { get; init; }

    /// <summary>
    /// An array of external property files containing run.logicalLocations.
    /// </summary>
    [JsonPropertyName("logicalLocations")]
    public IReadOnlyList<ExternalPropertyFileReference>? LogicalLocations { get; init; }

    /// <summary>
    /// An array of external property files containing run.threadFlowLocations.
    /// </summary>
    [JsonPropertyName("threadFlowLocations")]
    public IReadOnlyList<ExternalPropertyFileReference>? ThreadFlowLocations { get; init; }

    /// <summary>
    /// An array of external property files containing run.results.
    /// </summary>
    [JsonPropertyName("results")]
    public IReadOnlyList<ExternalPropertyFileReference>? Results { get; init; }

    /// <summary>
    /// An array of external property files containing run.taxonomies.
    /// </summary>
    [JsonPropertyName("taxonomies")]
    public IReadOnlyList<ExternalPropertyFileReference>? Taxonomies { get; init; }

    /// <summary>
    /// An array of external property files containing run.addresses.
    /// </summary>
    [JsonPropertyName("addresses")]
    public IReadOnlyList<ExternalPropertyFileReference>? Addresses { get; init; }

    /// <summary>
    /// An external property file containing a run.driver object.
    /// </summary>
    [JsonPropertyName("driver")]
    public ExternalPropertyFileReference? Driver { get; init; }

    /// <summary>
    /// An array of external property files containing run.extensions.
    /// </summary>
    [JsonPropertyName("extensions")]
    public IReadOnlyList<ExternalPropertyFileReference>? Extensions { get; init; }

    /// <summary>
    /// An array of external property files containing run.policies.
    /// </summary>
    [JsonPropertyName("policies")]
    public IReadOnlyList<ExternalPropertyFileReference>? Policies { get; init; }

    /// <summary>
    /// An array of external property files containing run.translations.
    /// </summary>
    [JsonPropertyName("translations")]
    public IReadOnlyList<ExternalPropertyFileReference>? Translations { get; init; }

    /// <summary>
    /// An array of external property files containing run.requests.
    /// </summary>
    [JsonPropertyName("webRequests")]
    public IReadOnlyList<ExternalPropertyFileReference>? WebRequests { get; init; }

    /// <summary>
    /// An array of external property files containing run.responses.
    /// </summary>
    [JsonPropertyName("webResponses")]
    public IReadOnlyList<ExternalPropertyFileReference>? WebResponses { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the external property file references.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
