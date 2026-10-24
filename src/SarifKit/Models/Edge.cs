using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A directed edge in a graph.
/// </summary>
public sealed class Edge
{
    /// <summary>
    /// A string that uniquely identifies the edge within its graph.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// A string that identifies the source node.
    /// </summary>
    [JsonPropertyName("sourceNodeId")]
    public required string SourceNodeId { get; init; }

    /// <summary>
    /// A string that identifies the target node.
    /// </summary>
    [JsonPropertyName("targetNodeId")]
    public required string TargetNodeId { get; init; }

    /// <summary>
    /// A description of the edge.
    /// </summary>
    [JsonPropertyName("label")]
    public Message? Label { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the edge.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
