using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A result produced by an analysis tool.
/// </summary>
public sealed class Result
{
    /// <summary>
    /// The stable, unique identifier of the rule, if any, to which this result is relevant.
    /// </summary>
    [JsonPropertyName("ruleId")]
    public string? RuleId { get; init; }

    /// <summary>
    /// The index within the tool component rules array of the rule object associated with this result.
    /// </summary>
    [JsonPropertyName("ruleIndex")]
    public int? RuleIndex { get; init; }

    /// <summary>
    /// A reference used to locate the rule descriptor relevant to this result.
    /// </summary>
    [JsonPropertyName("rule")]
    public ReportingDescriptorReference? Rule { get; init; }

    /// <summary>
    /// A value that categorizes results by evaluation state.
    /// </summary>
    [JsonPropertyName("kind")]
    public ResultKind? Kind { get; init; }

    /// <summary>
    /// A value specifying the severity level of the result.
    /// </summary>
    [JsonPropertyName("level")]
    public FailureLevel? Level { get; init; }

    /// <summary>
    /// A message that describes the result.
    /// </summary>
    [JsonPropertyName("message")]
    public required Message Message { get; init; }

    /// <summary>
    /// Identifies the artifact that the analysis tool was instructed to scan.
    /// </summary>
    [JsonPropertyName("analysisTarget")]
    public ArtifactLocation? AnalysisTarget { get; init; }

    /// <summary>
    /// The set of locations where the result was detected.
    /// </summary>
    [JsonPropertyName("locations")]
    public IReadOnlyList<Location>? Locations { get; init; }

    /// <summary>
    /// A stable, unique identifier for the result in the form of a GUID.
    /// </summary>
    [JsonPropertyName("guid")]
    public string? Guid { get; init; }

    /// <summary>
    /// A stable, unique identifier for the equivalence class of logically identical results to which this result
    /// belongs, in the form of a GUID.
    /// </summary>
    [JsonPropertyName("correlationGuid")]
    public string? CorrelationGuid { get; init; }

    /// <summary>
    /// A positive integer specifying the number of times this logically unique result was observed in this run.
    /// </summary>
    [JsonPropertyName("occurrenceCount")]
    public int? OccurrenceCount { get; init; }

    /// <summary>
    /// A set of strings that contribute to the stable, unique identity of the result.
    /// </summary>
    [JsonPropertyName("partialFingerprints")]
    public IReadOnlyDictionary<string, string>? PartialFingerprints { get; init; }

    /// <summary>
    /// A set of strings each of which individually defines a stable, unique identity for the result.
    /// </summary>
    [JsonPropertyName("fingerprints")]
    public IReadOnlyDictionary<string, string>? Fingerprints { get; init; }

    /// <summary>
    /// An array of stack objects relevant to the result.
    /// </summary>
    [JsonPropertyName("stacks")]
    public IReadOnlyList<Stack>? Stacks { get; init; }

    /// <summary>
    /// An array of codeFlow objects relevant to the result.
    /// </summary>
    [JsonPropertyName("codeFlows")]
    public IReadOnlyList<CodeFlow>? CodeFlows { get; init; }

    /// <summary>
    /// An array of zero or more unique graph objects associated with the result.
    /// </summary>
    [JsonPropertyName("graphs")]
    public IReadOnlyList<Graph>? Graphs { get; init; }

    /// <summary>
    /// An array of one or more unique graphTraversal objects.
    /// </summary>
    [JsonPropertyName("graphTraversals")]
    public IReadOnlyList<GraphTraversal>? GraphTraversals { get; init; }

    /// <summary>
    /// A set of locations relevant to this result.
    /// </summary>
    [JsonPropertyName("relatedLocations")]
    public IReadOnlyList<Location>? RelatedLocations { get; init; }

    /// <summary>
    /// A set of suppressions relevant to this result.
    /// </summary>
    [JsonPropertyName("suppressions")]
    public IReadOnlyList<Suppression>? Suppressions { get; init; }

    /// <summary>
    /// The state of a result relative to a baseline of a previous run.
    /// </summary>
    [JsonPropertyName("baselineState")]
    public BaselineState? BaselineState { get; init; }

    /// <summary>
    /// A number representing the priority or importance of the result, from 0.0 to 100.0.
    /// </summary>
    [JsonPropertyName("rank")]
    public double? Rank { get; init; }

    /// <summary>
    /// A set of artifacts relevant to the result.
    /// </summary>
    [JsonPropertyName("attachments")]
    public IReadOnlyList<Attachment>? Attachments { get; init; }

    /// <summary>
    /// An absolute URI at which the result can be viewed.
    /// </summary>
    [JsonPropertyName("hostedViewerUri")]
    public string? HostedViewerUri { get; init; }

    /// <summary>
    /// The URIs of the work items associated with this result.
    /// </summary>
    [JsonPropertyName("workItemUris")]
    public IReadOnlyList<string>? WorkItemUris { get; init; }

    /// <summary>
    /// Information about how and when the result was detected.
    /// </summary>
    [JsonPropertyName("provenance")]
    public ResultProvenance? Provenance { get; init; }

    /// <summary>
    /// An array of fix objects that propose fixes for the problem indicated by the result.
    /// </summary>
    [JsonPropertyName("fixes")]
    public IReadOnlyList<Fix>? Fixes { get; init; }

    /// <summary>
    /// An array of references to taxonomy reporting descriptors that are applicable to the result.
    /// </summary>
    [JsonPropertyName("taxa")]
    public IReadOnlyList<ReportingDescriptorReference>? Taxa { get; init; }

    /// <summary>
    /// A web request associated with this result.
    /// </summary>
    [JsonPropertyName("webRequest")]
    public WebRequest? WebRequest { get; init; }

    /// <summary>
    /// A web response associated with this result.
    /// </summary>
    [JsonPropertyName("webResponse")]
    public WebResponse? WebResponse { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the result.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
