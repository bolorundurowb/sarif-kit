using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A node in a graph.
/// </summary>
public sealed class Node
{
    /// <summary>
    /// A string that uniquely identifies the node within its graph.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// A description of the node.
    /// </summary>
    [JsonPropertyName("label")]
    public Message? Label { get; init; }

    /// <summary>
    /// A code location associated with the node.
    /// </summary>
    [JsonPropertyName("location")]
    public Location? Location { get; init; }

    /// <summary>
    /// Array of child nodes.
    /// </summary>
    [JsonPropertyName("children")]
    public IReadOnlyList<string>? Children { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the node.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
