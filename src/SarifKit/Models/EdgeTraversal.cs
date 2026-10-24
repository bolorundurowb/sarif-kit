using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Represents the traversal of a single edge in a graph.
/// </summary>
public sealed class EdgeTraversal
{
    /// <summary>
    /// A string that uniquely identifies the edge within its graph.
    /// </summary>
    [JsonPropertyName("edgeId")]
    public required string EdgeId { get; init; }

    /// <summary>
    /// The index in the graph.edges array of the edge object associated with this edge traversal.
    /// </summary>
    [JsonPropertyName("edgeIndex")]
    public int? EdgeIndex { get; init; }

    /// <summary>
    /// A description of the edge traversal.
    /// </summary>
    [JsonPropertyName("message")]
    public Message? Message { get; init; }

    /// <summary>
    /// The values of relevant expressions after the edge has been traversed.
    /// </summary>
    [JsonPropertyName("finalState")]
    public IReadOnlyDictionary<string, MultiformatMessageString>? FinalState { get; init; }

    /// <summary>
    /// The number of edge traversals contributing to this edge traversal.
    /// </summary>
    [JsonPropertyName("stepOverEdgeCount")]
    public int? StepOverEdgeCount { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the edge traversal.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
