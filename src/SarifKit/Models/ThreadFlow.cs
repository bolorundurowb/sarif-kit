using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Describes a sequence of code locations within a single thread of execution.
/// </summary>
public sealed class ThreadFlow
{
    /// <summary>
    /// A string that identifies this threadFlow within the codeFlow.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// A message relevant to this thread flow.
    /// </summary>
    [JsonPropertyName("message")]
    public Message? Message { get; init; }

    /// <summary>
    /// Values of relevant expressions at the start of the thread flow that may change during thread flow execution.
    /// </summary>
    [JsonPropertyName("initialState")]
    public IReadOnlyDictionary<string, MultiformatMessageString>? InitialState { get; init; }

    /// <summary>
    /// Values of relevant expressions at the start of the thread flow that remain constant.
    /// </summary>
    [JsonPropertyName("immutableState")]
    public IReadOnlyDictionary<string, MultiformatMessageString>? ImmutableState { get; init; }

    /// <summary>
    /// An array of threadFlowLocation objects, each of which describes a location visited by the tool.
    /// </summary>
    [JsonPropertyName("locations")]
    public required IReadOnlyList<ThreadFlowLocation> Locations { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the thread flow.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
