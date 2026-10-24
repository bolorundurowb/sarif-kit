using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Describes a runtime exception encountered by a tool.
/// </summary>
public sealed class ExceptionData
{
    /// <summary>
    /// A string that identifies the type of the exception.
    /// </summary>
    [JsonPropertyName("kind")]
    public string? Kind { get; init; }

    /// <summary>
    /// A string that describes the exception.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; init; }

    /// <summary>
    /// The stack trace for the exception.
    /// </summary>
    [JsonPropertyName("stack")]
    public Stack? Stack { get; init; }

    /// <summary>
    /// An array of exception objects representing the inner exceptions.
    /// </summary>
    [JsonPropertyName("innerExceptions")]
    public IReadOnlyList<ExceptionData>? InnerExceptions { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the exception.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
