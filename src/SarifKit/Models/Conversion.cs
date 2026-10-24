using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Describes how a converter transformed the output of a static analysis tool from the analysis tool's native output
/// format into the SARIF format.
/// </summary>
public sealed class Conversion
{
    /// <summary>
    /// A tool object that describes the converter.
    /// </summary>
    [JsonPropertyName("tool")]
    public required Tool Tool { get; init; }

    /// <summary>
    /// An invocation object that describes the invocation of the converter.
    /// </summary>
    [JsonPropertyName("invocation")]
    public Invocation? Invocation { get; init; }

    /// <summary>
    /// The locations of the analysis tool's per-run log files.
    /// </summary>
    [JsonPropertyName("analysisToolLogFiles")]
    public IReadOnlyList<ArtifactLocation>? AnalysisToolLogFiles { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the conversion.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
