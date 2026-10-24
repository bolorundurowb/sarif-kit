using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Metadata that describes a specific report produced by the tool.
/// </summary>
public sealed class ReportingDescriptor
{
    /// <summary>
    /// A stable, opaque identifier for the report.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// An array of stable, opaque identifiers by which this report was known in some previous version of the analysis tool.
    /// </summary>
    [JsonPropertyName("deprecatedIds")]
    public IReadOnlyList<string>? DeprecatedIds { get; init; }

    /// <summary>
    /// A unique identifier for the reporting descriptor in the form of a GUID.
    /// </summary>
    [JsonPropertyName("guid")]
    public string? Guid { get; init; }

    /// <summary>
    /// An array of unique identifiers in the form of a GUID by which this report was known in some previous version of the analysis tool.
    /// </summary>
    [JsonPropertyName("deprecatedGuids")]
    public IReadOnlyList<string>? DeprecatedGuids { get; init; }

    /// <summary>
    /// A report identifier that is understandable to an end user.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// An array of readable identifiers by which this report was known in some previous version of the analysis tool.
    /// </summary>
    [JsonPropertyName("deprecatedNames")]
    public IReadOnlyList<string>? DeprecatedNames { get; init; }

    /// <summary>
    /// A concise description of the report.
    /// </summary>
    [JsonPropertyName("shortDescription")]
    public MultiformatMessageString? ShortDescription { get; init; }

    /// <summary>
    /// A description of the report.
    /// </summary>
    [JsonPropertyName("fullDescription")]
    public MultiformatMessageString? FullDescription { get; init; }

    /// <summary>
    /// A set of name/value pairs with arbitrary names for this reporting descriptor.
    /// </summary>
    [JsonPropertyName("defaultConfiguration")]
    public ReportingConfiguration? DefaultConfiguration { get; init; }

    /// <summary>
    /// A URI at which documentation about the report can be found.
    /// </summary>
    [JsonPropertyName("helpUri")]
    public string? HelpUri { get; init; }

    /// <summary>
    /// Provides the primary documentation for the report.
    /// </summary>
    [JsonPropertyName("help")]
    public MultiformatMessageString? Help { get; init; }

    /// <summary>
    /// A description of the relationship between the current reporting descriptor and a related reporting descriptor.
    /// </summary>
    [JsonPropertyName("relationships")]
    public IReadOnlyList<ReportingDescriptorRelationship>? Relationships { get; init; }

    /// <summary>
    /// A dictionary of message identifiers to message strings for the report.
    /// </summary>
    [JsonPropertyName("messageStrings")]
    public IReadOnlyDictionary<string, MultiformatMessageString>? MessageStrings { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the reporting descriptor.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
