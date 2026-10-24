using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A call stack.
/// </summary>
public sealed class Stack
{
    /// <summary>
    /// An array of stackFrame objects representing each function call in the stack.
    /// </summary>
    [JsonPropertyName("frames")]
    public required IReadOnlyList<StackFrame> Frames { get; init; }

    /// <summary>
    /// A message relevant to this call stack.
    /// </summary>
    [JsonPropertyName("message")]
    public Message? Message { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the stack.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
