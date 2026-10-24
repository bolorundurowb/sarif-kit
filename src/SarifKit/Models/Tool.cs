using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Describes an analysis tool or converter.
/// </summary>
public sealed class Tool
{
    /// <summary>
    /// The analysis tool that produced the results.
    /// </summary>
    [JsonPropertyName("driver")]
    public required ToolComponent Driver { get; init; }

    /// <summary>
    /// Tool extensions that contributed to or reconfigured the analysis tool.
    /// </summary>
    [JsonPropertyName("extensions")]
    public IReadOnlyList<ToolComponent>? Extensions { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the tool.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
