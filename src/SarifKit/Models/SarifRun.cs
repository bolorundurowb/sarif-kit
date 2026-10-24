using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Describes a single run of an analysis tool, and contains the reported output of that run.
/// </summary>
public sealed class SarifRun
{
    /// <summary>
    /// Information about the tool or tool pipeline that generated the results in this run.
    /// </summary>
    [JsonPropertyName("tool")]
    public required Tool Tool { get; init; }

    /// <summary>
    /// Describes the invocation of the analysis tool.
    /// </summary>
    [JsonPropertyName("invocations")]
    public IReadOnlyList<Invocation>? Invocations { get; init; }

    /// <summary>
    /// A conversion object that describes how a converter transformed an analysis tool's native reporting format into
    /// the SARIF format.
    /// </summary>
    [JsonPropertyName("conversion")]
    public Conversion? Conversion { get; init; }

    /// <summary>
    /// The language of the messages emitted into the log file during this run, expressed as an RFC 5646 language tag.
    /// </summary>
    [JsonPropertyName("language")]
    public string? Language { get; init; }

    /// <summary>
    /// Specifies the revision in version control of the artifacts that were scanned.
    /// </summary>
    [JsonPropertyName("versionControlProvenance")]
    public IReadOnlyList<VersionControlDetails>? VersionControlProvenance { get; init; }

    /// <summary>
    /// The artifact location specified by each uriBaseId symbol on the machine where the tool originally ran.
    /// </summary>
    [JsonPropertyName("originalUriBaseIds")]
    public IReadOnlyDictionary<string, ArtifactLocation>? OriginalUriBaseIds { get; init; }

    /// <summary>
    /// An array of artifact objects relevant to the run.
    /// </summary>
    [JsonPropertyName("artifacts")]
    public IReadOnlyList<Artifact>? Artifacts { get; init; }

    /// <summary>
    /// An array of logical locations such as namespaces, types or functions.
    /// </summary>
    [JsonPropertyName("logicalLocations")]
    public IReadOnlyList<LogicalLocation>? LogicalLocations { get; init; }

    /// <summary>
    /// An array of zero or more unique graph objects associated with the run.
    /// </summary>
    [JsonPropertyName("graphs")]
    public IReadOnlyList<Graph>? Graphs { get; init; }

    /// <summary>
    /// The set of results contained in a SARIF log. A <see langword="null"/> value means the tool failed to run
    /// properly, whereas an empty list means no results were found.
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
    /// The automationDetails.guid property of a previous SARIF run that comprises the baseline that was used to
    /// compute result baselineState properties for the run.
    /// </summary>
    [JsonPropertyName("baselineGuid")]
    public string? BaselineGuid { get; init; }

    /// <summary>
    /// An array of strings used to replace sensitive information in a redaction-aware property.
    /// </summary>
    [JsonPropertyName("redactionTokens")]
    public IReadOnlyList<string>? RedactionTokens { get; init; }

    /// <summary>
    /// The default encoding for any artifact object that refers to a text file.
    /// </summary>
    [JsonPropertyName("defaultEncoding")]
    public string? DefaultEncoding { get; init; }

    /// <summary>
    /// The default source language for any artifact object that refers to a text file that contains source code.
    /// </summary>
    [JsonPropertyName("defaultSourceLanguage")]
    public string? DefaultSourceLanguage { get; init; }

    /// <summary>
    /// An ordered list of character sequences that were treated as line breaks when computing region information for the run.
    /// </summary>
    [JsonPropertyName("newlineSequences")]
    public IReadOnlyList<string>? NewlineSequences { get; init; }

    /// <summary>
    /// Specifies the unit in which the tool measures columns.
    /// </summary>
    [JsonPropertyName("columnKind")]
    public ColumnKind? ColumnKind { get; init; }

    /// <summary>
    /// References to external property files that should be inlined with the content of a root log file.
    /// </summary>
    [JsonPropertyName("externalPropertyFileReferences")]
    public ExternalPropertyFileReferences? ExternalPropertyFileReferences { get; init; }

    /// <summary>
    /// An array of threadFlowLocation objects cached at the run level.
    /// </summary>
    [JsonPropertyName("threadFlowLocations")]
    public IReadOnlyList<ThreadFlowLocation>? ThreadFlowLocations { get; init; }

    /// <summary>
    /// An array of toolComponent objects relevant to a taxonomy in which results are categorized.
    /// </summary>
    [JsonPropertyName("taxonomies")]
    public IReadOnlyList<ToolComponent>? Taxonomies { get; init; }

    /// <summary>
    /// Addresses associated with this run instance, if any.
    /// </summary>
    [JsonPropertyName("addresses")]
    public IReadOnlyList<Address>? Addresses { get; init; }

    /// <summary>
    /// The set of available translations of the localized data provided by the tool.
    /// </summary>
    [JsonPropertyName("translations")]
    public IReadOnlyList<ToolComponent>? Translations { get; init; }

    /// <summary>
    /// Contains configurations that may potentially override both reportingDescriptor.defaultConfiguration (the tool's
    /// default severities) and invocation.configurationOverrides (severities established at run-time from the command line).
    /// </summary>
    [JsonPropertyName("policies")]
    public IReadOnlyList<ToolComponent>? Policies { get; init; }

    /// <summary>
    /// An array of request objects cached at the run level.
    /// </summary>
    [JsonPropertyName("webRequests")]
    public IReadOnlyList<WebRequest>? WebRequests { get; init; }

    /// <summary>
    /// An array of response objects cached at the run level.
    /// </summary>
    [JsonPropertyName("webResponses")]
    public IReadOnlyList<WebResponse>? WebResponses { get; init; }

    /// <summary>
    /// A specialLocations object that defines locations of special significance to SARIF consumers.
    /// </summary>
    [JsonPropertyName("specialLocations")]
    public SpecialLocations? SpecialLocations { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the run.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
