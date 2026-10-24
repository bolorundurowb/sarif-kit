using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A function call within a stack.
/// </summary>
public sealed class StackFrame
{
    /// <summary>
    /// The location to which this stack frame refers.
    /// </summary>
    [JsonPropertyName("location")]
    public Location? Location { get; init; }

    /// <summary>
    /// The name of the module that contains the code for this stack frame.
    /// </summary>
    [JsonPropertyName("module")]
    public string? Module { get; init; }

    /// <summary>
    /// The thread identifier for the stack frame.
    /// </summary>
    [JsonPropertyName("threadId")]
    public int? ThreadId { get; init; }

    /// <summary>
    /// The parameters of the call that is executing.
    /// </summary>
    [JsonPropertyName("parameters")]
    public IReadOnlyList<string>? Parameters { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the stack frame.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
