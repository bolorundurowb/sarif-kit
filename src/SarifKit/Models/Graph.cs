using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Describes a graph of nodes and edges.
/// </summary>
public sealed class Graph
{
    /// <summary>
    /// A description of the graph.
    /// </summary>
    [JsonPropertyName("description")]
    public Message? Description { get; init; }

    /// <summary>
    /// An array of node objects representing the nodes of the graph.
    /// </summary>
    [JsonPropertyName("nodes")]
    public IReadOnlyList<Node>? Nodes { get; init; }

    /// <summary>
    /// An array of edge objects representing the edges of the graph.
    /// </summary>
    [JsonPropertyName("edges")]
    public IReadOnlyList<Edge>? Edges { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the graph.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
