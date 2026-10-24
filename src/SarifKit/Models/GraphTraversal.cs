using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Represents a path through a graph.
/// </summary>
public sealed class GraphTraversal
{
    /// <summary>
    /// A description of the graph traversal.
    /// </summary>
    [JsonPropertyName("description")]
    public Message? Description { get; init; }

    /// <summary>
    /// The index within the run.graphs array of the graph object that this object traverses.
    /// </summary>
    [JsonPropertyName("runGraphIndex")]
    public int? RunGraphIndex { get; init; }

    /// <summary>
    /// The index within the result.graphs array of the graph object that this object traverses.
    /// </summary>
    [JsonPropertyName("resultGraphIndex")]
    public int? ResultGraphIndex { get; init; }

    /// <summary>
    /// The sequences of edges traversed in this graph traversal.
    /// </summary>
    [JsonPropertyName("edgeTraversals")]
    public IReadOnlyList<EdgeTraversal>? EdgeTraversals { get; init; }

    /// <summary>
    /// Values of relevant expressions at the start of the graph traversal that may change during graph traversal.
    /// </summary>
    [JsonPropertyName("initialState")]
    public IReadOnlyDictionary<string, MultiformatMessageString>? InitialState { get; init; }

    /// <summary>
    /// Values of relevant expressions at the start of the graph traversal that remain constant.
    /// </summary>
    [JsonPropertyName("immutableState")]
    public IReadOnlyDictionary<string, MultiformatMessageString>? ImmutableState { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the graph traversal.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
