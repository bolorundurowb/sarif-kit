using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Describes a sequence of code locations that specify a possible path through code.
/// </summary>
public sealed class CodeFlow
{
    /// <summary>
    /// A message relevant to the code flow.
    /// </summary>
    [JsonPropertyName("message")]
    public Message? Message { get; init; }

    /// <summary>
    /// An array of one or more unique threadFlow objects, each of which describes a sequence of code locations.
    /// </summary>
    [JsonPropertyName("threadFlows")]
    public required IReadOnlyList<ThreadFlow> ThreadFlows { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the code flow.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
