using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A result produced by an analysis tool.
/// </summary>
public sealed class Result
{
    /// <summary>
    /// A stable, unique identifier for the result.
    /// </summary>
    [JsonPropertyName("guid")]
    public string? Guid { get; init; }

    /// <summary>
    /// A value that specifies the failure level of the result.
    /// </summary>
    [JsonPropertyName("level")]
    public FailureLevel? Level { get; init; }

    /// <summary>
    /// A value specifying the state of the result relative to a baseline of a previous run.
    /// </summary>
    [JsonPropertyName("baselineState")]
    public BaselineState? BaselineState { get; init; }

    /// <summary>
    /// A value that categorizes results by evaluation nature.
    /// </summary>
    [JsonPropertyName("kind")]
    public ResultKind? Kind { get; init; }

    /// <summary>
    /// A string that describes the result.
    /// </summary>
    [JsonPropertyName("message")]
    public required Message Message { get; init; }

    /// <summary>
    /// A string that identifies the defect category assigned by the analysis tool.
    /// </summary>
    [JsonPropertyName("ruleId")]
    public string? RuleId { get; init; }

    /// <summary>
    /// A reference to the reporting descriptor that produced this result.
    /// </summary>
    [JsonPropertyName("rule")]
    public ReportingDescriptorReference? Rule { get; init; }

    /// <summary>
    /// A unique identifier for the rule that generated this result in the form of a GUID.
    /// </summary>
    [JsonPropertyName("ruleGuid")]
    public string? RuleGuid { get; init; }

    /// <summary>
    /// A set of locations relevant to this result.
    /// </summary>
    [JsonPropertyName("locations")]
    public IReadOnlyList<Location>? Locations { get; init; }

    /// <summary>
    /// A set of files relevant to this result.
    /// </summary>
    [JsonPropertyName("analysisTarget")]
    public ArtifactLocation? AnalysisTarget { get; init; }

    /// <summary>
    /// A set of code flows that describe the progress of the analysis through the code.
    /// </summary>
    [JsonPropertyName("codeFlows")]
    public IReadOnlyList<CodeFlow>? CodeFlows { get; init; }

    /// <summary>
    /// A set of graphs relevant to the result.
    /// </summary>
    [JsonPropertyName("graphs")]
    public IReadOnlyList<Graph>? Graphs { get; init; }

    /// <summary>
    /// A set of graph traversals relevant to the result.
    /// </summary>
    [JsonPropertyName("graphTraversals")]
    public IReadOnlyList<GraphTraversal>? GraphTraversals { get; init; }

    /// <summary>
    /// A set of stacks relevant to the result.
    /// </summary>
    [JsonPropertyName("stacks")]
    public IReadOnlyList<Stack>? Stacks { get; init; }

    /// <summary>
    /// A set of related locations relevant to this result.
    /// </summary>
    [JsonPropertyName("relatedLocations")]
    public IReadOnlyList<Location>? RelatedLocations { get; init; }

    /// <summary>
    /// A set of suppressions relevant to this result.
    /// </summary>
    [JsonPropertyName("suppressions")]
    public IReadOnlyList<Suppression>? Suppressions { get; init; }

    /// <summary>
    /// Information about how and when the result was detected.
    /// </summary>
    [JsonPropertyName("provenance")]
    public IReadOnlyList<ResultProvenance>? Provenance { get; init; }

    /// <summary>
    /// An array of fix objects that propose fixes for the problem indicated by the result.
    /// </summary>
    [JsonPropertyName("fixes")]
    public IReadOnlyList<Fix>? Fixes { get; init; }

    /// <summary>
    /// A value that specifies whether a result is mapped to a set of taxa.
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
    /// Automation details that describe the result.
    /// </summary>
    [JsonPropertyName("automationDetails")]
    public AutomationDetails? AutomationDetails { get; init; }

    /// <summary>
    /// A non-negative integer specifying the number of times this logically identical result was observed.
    /// </summary>
    [JsonPropertyName("occurrenceCount")]
    public int? OccurrenceCount { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the result.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
