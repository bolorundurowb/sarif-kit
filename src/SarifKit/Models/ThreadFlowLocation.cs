using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A location visited by an analysis tool in the course of simulating or monitoring program execution.
/// </summary>
public sealed class ThreadFlowLocation
{
    /// <summary>
    /// The index within the run threadFlowLocations array for this threadFlowLocation.
    /// </summary>
    [JsonPropertyName("index")]
    public int? Index { get; init; }

    /// <summary>
    /// The code location.
    /// </summary>
    [JsonPropertyName("location")]
    public Location? Location { get; init; }

    /// <summary>
    /// The call stack leading to this location.
    /// </summary>
    [JsonPropertyName("stack")]
    public Stack? Stack { get; init; }

    /// <summary>
    /// A set of distinct strings that categorize the thread flow location.
    /// </summary>
    [JsonPropertyName("kinds")]
    public IReadOnlyList<string>? Kinds { get; init; }

    /// <summary>
    /// An array of references to rule or taxonomy reporting descriptors that are applicable to the thread flow location.
    /// </summary>
    [JsonPropertyName("taxa")]
    public IReadOnlyList<ReportingDescriptorReference>? Taxa { get; init; }

    /// <summary>
    /// The name of the module that contains the code that is executing.
    /// </summary>
    [JsonPropertyName("module")]
    public string? Module { get; init; }

    /// <summary>
    /// A dictionary, each of whose keys specifies a variable or expression, the associated value of which represents
    /// the variable or expression value.
    /// </summary>
    [JsonPropertyName("state")]
    public IReadOnlyDictionary<string, MultiformatMessageString>? State { get; init; }

    /// <summary>
    /// An integer representing a containment hierarchy within the thread flow.
    /// </summary>
    [JsonPropertyName("nestingLevel")]
    public int? NestingLevel { get; init; }

    /// <summary>
    /// An integer representing the temporal order in which execution reached this location.
    /// </summary>
    [JsonPropertyName("executionOrder")]
    public int? ExecutionOrder { get; init; }

    /// <summary>
    /// The time at which this location was executed.
    /// </summary>
    [JsonPropertyName("executionTimeUtc")]
    public DateTimeOffset? ExecutionTimeUtc { get; init; }

    /// <summary>
    /// Specifies the importance of this location in understanding the code flow in which it occurs.
    /// </summary>
    [JsonPropertyName("importance")]
    public Importance? Importance { get; init; }

    /// <summary>
    /// A web request associated with this thread flow location.
    /// </summary>
    [JsonPropertyName("webRequest")]
    public WebRequest? WebRequest { get; init; }

    /// <summary>
    /// A web response associated with this thread flow location.
    /// </summary>
    [JsonPropertyName("webResponse")]
    public WebResponse? WebResponse { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the thread flow location.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
