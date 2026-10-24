using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A network response.
/// </summary>
public sealed class WebResponse
{
    /// <summary>
    /// The index within the run.webResponses array of the response object associated with this result.
    /// </summary>
    [JsonPropertyName("index")]
    public int? Index { get; init; }

    /// <summary>
    /// The response protocol and version.
    /// </summary>
    [JsonPropertyName("protocol")]
    public string? Protocol { get; init; }

    /// <summary>
    /// The response version.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; init; }

    /// <summary>
    /// The response status code.
    /// </summary>
    [JsonPropertyName("statusCode")]
    public int? StatusCode { get; init; }

    /// <summary>
    /// The response reason phrase.
    /// </summary>
    [JsonPropertyName("reasonPhrase")]
    public string? ReasonPhrase { get; init; }

    /// <summary>
    /// The response headers.
    /// </summary>
    [JsonPropertyName("headers")]
    public IReadOnlyDictionary<string, string>? Headers { get; init; }

    /// <summary>
    /// The body of the response.
    /// </summary>
    [JsonPropertyName("body")]
    public ArtifactContent? Body { get; init; }

    /// <summary>
    /// Specifies whether a response was received from the server.
    /// </summary>
    [JsonPropertyName("noResponseReceived")]
    public bool? NoResponseReceived { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the response.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
