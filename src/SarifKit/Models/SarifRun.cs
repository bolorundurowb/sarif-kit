using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Describes a single run of an analysis tool and produces a set of results.
/// </summary>
public sealed class SarifRun
{
    /// <summary>
    /// Information about the tool or tools that produced the results in this run.
    /// </summary>
    [JsonPropertyName("tool")]
    public required Tool Tool { get; init; }

    /// <summary>
    /// A list of invocation objects describing the invocations of analysis tools that produced the results.
    /// </summary>
    [JsonPropertyName("invocations")]
    public IReadOnlyList<Invocation>? Invocations { get; init; }

    /// <summary>
    /// A list of file objects representing the artifacts relevant to the run.
    /// </summary>
    [JsonPropertyName("artifacts")]
    public IReadOnlyList<Artifact>? Artifacts { get; init; }

    /// <summary>
    /// A list of logical locations such as namespaces, types, and functions.
    /// </summary>
    [JsonPropertyName("logicalLocations")]
    public IReadOnlyList<LogicalLocation>? LogicalLocations { get; init; }

    /// <summary>
    /// A list of result objects representing the results of the run.
    /// </summary>
    [JsonPropertyName("results")]
    public IReadOnlyList<Result>? Results { get; init; }

    /// <summary>
    /// Automation details that describe this run.
    /// </summary>
    [JsonPropertyName("automationDetails")]
    public RunAutomationDetails? AutomationDetails { get; init; }

    /// <summary>
    /// Automation details that describe the aggregate of runs to which this run belongs.
    /// </summary>
    [JsonPropertyName("runAggregations")]
    public IReadOnlyList<RunAutomationDetails>? RunAggregations { get; init; }

    /// <summary>
    /// The index into the localizedDataPartialRunGuids array of the run.
    /// </summary>
    [JsonPropertyName("baselineGuid")]
    public string? BaselineGuid { get; init; }

    /// <summary>
   /// The 'id' property of a run, which identifies it uniquely among all runs in the log file.
    /// </summary>
    [JsonPropertyName("id")]
    public RunAutomationDetails? Id { get; init; }

    /// <summary>
    /// Information about the scan constraints that influenced the run.
    /// </summary>
    [JsonPropertyName("newlineSequences")]
    public IReadOnlyList<string>? NewlineSequences { get; init; }

    /// <summary>
    /// The default encoding for any artifact object that refers to a text file.
    /// </summary>
    [JsonPropertyName("defaultEncoding")]
    public string? DefaultEncoding { get; init; }

    /// <summary>
    /// The default source language for any artifact object that refers to a text file.
    /// </summary>
    [JsonPropertyName("defaultSourceLanguage")]
    public string? DefaultSourceLanguage { get; init; }

    /// <summary>
    /// Specifies the unit in which the tool measures columns.
    /// </summary>
    [JsonPropertyName("columnKind")]
    public ColumnKind? ColumnKind { get; init; }

    /// <summary>
    /// An array of external property file references.
    /// </summary>
    [JsonPropertyName("externalPropertyFileReferences")]
    public ExternalPropertyFileReferences? ExternalPropertyFileReferences { get; init; }

    /// <summary>
    /// An array of threadFlowLocation objects cached at the run level.
    /// </summary>
    [JsonPropertyName("threadFlowLocations")]
    public IReadOnlyList<ThreadFlowLocation>? ThreadFlowLocations { get; init; }

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
    [JsonPropertyName("specialLocations")]
    public SpecialLocations? SpecialLocations { get; init; }

    /// <summary>
    /// A list of language-specific resources used to provide localized messages.
    /// </summary>
    [JsonPropertyName("language")]
    public string? Language { get; init; }

    /// <summary>
    /// Contains configuration information specific to a report.
    /// </summary>
    [JsonPropertyName("policies")]
    public IReadOnlyList<ToolComponent>? Policies { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the run.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
