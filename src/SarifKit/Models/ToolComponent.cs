using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A component, such as a plug-in or the driver, of an analysis tool.
/// </summary>
public sealed class ToolComponent
{
    /// <summary>
    /// A unique identifier for the tool component in the form of a GUID.
    /// </summary>
    [JsonPropertyName("guid")]
    public string? Guid { get; init; }

    /// <summary>
    /// The name of the tool component.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// The organization or company that produced the tool component.
    /// </summary>
    [JsonPropertyName("organization")]
    public string? Organization { get; init; }

    /// <summary>
    /// A product suite to which the tool component belongs.
    /// </summary>
    [JsonPropertyName("product")]
    public string? Product { get; init; }

    /// <summary>
    /// A localizable string containing the name of the suite of products to which the tool component belongs.
    /// </summary>
    [JsonPropertyName("productSuite")]
    public string? ProductSuite { get; init; }

    /// <summary>
    /// The tool component version, in whatever format the component natively provides.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; init; }

    /// <summary>
    /// The binary version of the tool component's semantic version if it exists.
    /// </summary>
    [JsonPropertyName("semanticVersion")]
    public string? SemanticVersion { get; init; }

    /// <summary>
    /// The absolute URI from which the tool component can be downloaded.
    /// </summary>
    [JsonPropertyName("downloadUri")]
    public string? DownloadUri { get; init; }

    /// <summary>
    /// The absolute URI at which information about the tool component can be found.
    /// </summary>
    [JsonPropertyName("informationUri")]
    public string? InformationUri { get; init; }

    /// <summary>
    /// A dictionary, each of whose keys is a resource identifier and each of whose values is a localized string.
    /// </summary>
    [JsonPropertyName("globalMessageStrings")]
    public IReadOnlyDictionary<string, MultiformatMessageString>? GlobalMessageStrings { get; init; }

    /// <summary>
    /// An array of reportingDescriptor objects relevant to the analysis performed by the tool component.
    /// </summary>
    [JsonPropertyName("rules")]
    public IReadOnlyList<ReportingDescriptor>? Rules { get; init; }

    /// <summary>
    /// An array of reportingDescriptor objects relevant to the notifications of the tool component.
    /// </summary>
    [JsonPropertyName("notifications")]
    public IReadOnlyList<ReportingDescriptor>? Notifications { get; init; }

    /// <summary>
    /// An array of reportingDescriptor objects relevant to the configuration of the tool component.
    /// </summary>
    [JsonPropertyName("taxa")]
    public IReadOnlyList<ReportingDescriptor>? Taxa { get; init; }

    /// <summary>
    /// An array of toolComponentReference objects to declare the embedded tool components.
    /// </summary>
    [JsonPropertyName("locations")]
    public IReadOnlyList<ArtifactLocation>? Locations { get; init; }

    /// <summary>
    /// The language of the localized strings defined in the component.
    /// </summary>
    [JsonPropertyName("language")]
    public string? Language { get; init; }

    /// <summary>
    /// Specifies whether the tool component is a driver or an extension.
    /// </summary>
    [JsonPropertyName("isDriver")]
    public bool? IsDriver { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the tool component.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
