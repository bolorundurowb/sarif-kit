using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A location visited by an analysis tool in the course of simulating or monitoring program execution.
/// </summary>
public sealed class ThreadFlowLocation
{
    /// <summary>
    /// A numeric value that can be used to sort thread flow locations in chronological order.
    /// </summary>
    [JsonPropertyName("executionOrder")]
    public int? ExecutionOrder { get; init; }

    /// <summary>
    /// Coordinates of the location within the thread flow.
    /// </summary>
    [JsonPropertyName("executionTimeUtc")]
    public DateTimeOffset? ExecutionTimeUtc { get; init; }

    /// <summary>
    /// The importance of this location in understanding the code flow.
    /// </summary>
    [JsonPropertyName("importance")]
    public Importance? Importance { get; init; }

    /// <summary>
    /// The index within the run threadFlowLocations array for this threadFlowLocation.
    /// </summary>
    [JsonPropertyName("index")]
    public int? Index { get; init; }

    /// <summary>
    /// A code location in the thread flow.
    /// </summary>
    [JsonPropertyName("location")]
    public Location? Location { get; init; }

    /// <summary>
    /// The reason for the location.
    /// </summary>
    [JsonPropertyName("kinds")]
    public IReadOnlyList<string>? Kinds { get; init; }

    /// <summary>
    /// A set of statements in the code that this location is associated with.
    /// </summary>
    [JsonPropertyName("module")]
    public string? Module { get; init; }

    /// <summary>
    /// The call to the current module from the previous module.
    /// </summary>
    [JsonPropertyName("nestingLevel")]
    public int? NestingLevel { get; init; }

    /// <summary>
    /// The address of the location.
    /// </summary>
    [JsonPropertyName("address")]
    public Address? Address { get; init; }

    /// <summary>
    /// A stack associated with the location.
    /// </summary>
    [JsonPropertyName("stack")]
    public Stack? Stack { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the thread flow location.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
