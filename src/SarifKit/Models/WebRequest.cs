using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A network request.
/// </summary>
public sealed class WebRequest
{
    /// <summary>
    /// The index within the run.webRequests array of the request object associated with this result.
    /// </summary>
    [JsonPropertyName("index")]
    public int? Index { get; init; }

    /// <summary>
    /// The request protocol.
    /// </summary>
    [JsonPropertyName("protocol")]
    public string? Protocol { get; init; }

    /// <summary>
    /// The request version.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; init; }

    /// <summary>
    /// The target of the request.
    /// </summary>
    [JsonPropertyName("target")]
    public string? Target { get; init; }

    /// <summary>
    /// The HTTP method.
    /// </summary>
    [JsonPropertyName("method")]
    public string? Method { get; init; }

    /// <summary>
    /// The request headers.
    /// </summary>
    [JsonPropertyName("headers")]
    public IReadOnlyDictionary<string, string>? Headers { get; init; }

    /// <summary>
    /// The request parameters.
    /// </summary>
    [JsonPropertyName("parameters")]
    public IReadOnlyDictionary<string, string>? Parameters { get; init; }

    /// <summary>
    /// The body of the request.
    /// </summary>
    [JsonPropertyName("body")]
    public ArtifactContent? Body { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the request.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
