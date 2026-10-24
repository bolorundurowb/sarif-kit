using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// The top-level SARIF log file object.
/// </summary>
public sealed class SarifLog
{
    /// <summary>
    /// The URI of the JSON schema against which this document may be validated.
    /// </summary>
    [JsonPropertyName("$schema")]
    public string? Schema { get; init; } = "https://json.schemastore.org/sarif-2.1.0.json";

    /// <summary>
    /// The SARIF version of this log file.
    /// </summary>
    [JsonPropertyName("version")]
    public required string Version { get; init; } = "2.1.0";

    /// <summary>
    /// The set of runs contained in this log file.
    /// </summary>
    [JsonPropertyName("runs")]
    public required IReadOnlyList<SarifRun> Runs { get; init; }

    /// <summary>
   /// References to external property files that share data between runs.
    /// </summary>
    [JsonPropertyName("inlineExternalProperties")]
    public IReadOnlyList<ExternalProperties>? InlineExternalProperties { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the log file.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
