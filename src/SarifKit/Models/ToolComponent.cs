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
    /// A brief description of the tool component.
    /// </summary>
    [JsonPropertyName("shortDescription")]
    public MultiformatMessageString? ShortDescription { get; init; }

    /// <summary>
    /// A comprehensive description of the tool component.
    /// </summary>
    [JsonPropertyName("fullDescription")]
    public MultiformatMessageString? FullDescription { get; init; }

    /// <summary>
    /// The name of the tool component along with its version and any other useful identifying information, such as its locale.
    /// </summary>
    [JsonPropertyName("fullName")]
    public string? FullName { get; init; }

    /// <summary>
    /// The tool component version, in whatever format the component natively provides.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; init; }

    /// <summary>
    /// The tool component version in the format specified by Semantic Versioning 2.0.
    /// </summary>
    [JsonPropertyName("semanticVersion")]
    public string? SemanticVersion { get; init; }

    /// <summary>
    /// The binary version of the tool component's primary executable file expressed as four non-negative integers
    /// separated by a period (for operating systems that express file versions in this way).
    /// </summary>
    [JsonPropertyName("dottedQuadFileVersion")]
    public string? DottedQuadFileVersion { get; init; }

    /// <summary>
    /// A string specifying the UTC date (and optionally, the time) of the component's release.
    /// </summary>
    [JsonPropertyName("releaseDateUtc")]
    public string? ReleaseDateUtc { get; init; }

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
    /// An array of reportingDescriptor objects relevant to the notifications related to the configuration and runtime
    /// execution of the tool component.
    /// </summary>
    [JsonPropertyName("notifications")]
    public IReadOnlyList<ReportingDescriptor>? Notifications { get; init; }

    /// <summary>
    /// An array of reportingDescriptor objects relevant to the analysis performed by the tool component.
    /// </summary>
    [JsonPropertyName("rules")]
    public IReadOnlyList<ReportingDescriptor>? Rules { get; init; }

    /// <summary>
    /// An array of reportingDescriptor objects relevant to the definitions of both standalone and tool-defined taxonomies.
    /// </summary>
    [JsonPropertyName("taxa")]
    public IReadOnlyList<ReportingDescriptor>? Taxa { get; init; }

    /// <summary>
    /// An array of the artifactLocation objects associated with the tool component.
    /// </summary>
    [JsonPropertyName("locations")]
    public IReadOnlyList<ArtifactLocation>? Locations { get; init; }

    /// <summary>
    /// The language of the messages emitted into the log file during this run, expressed as an RFC 5646 language tag.
    /// </summary>
    [JsonPropertyName("language")]
    public string? Language { get; init; }

    /// <summary>
    /// The kinds of data contained in this object, such as <c>localizedData</c> and <c>nonLocalizedData</c>.
    /// </summary>
    [JsonPropertyName("contents")]
    public IReadOnlyList<string>? Contents { get; init; }

    /// <summary>
    /// Specifies whether this object contains a complete definition of the localizable and/or non-localizable data
    /// for this component, as opposed to including only data that is relevant to the results persisted to this log file.
    /// </summary>
    [JsonPropertyName("isComprehensive")]
    public bool? IsComprehensive { get; init; }

    /// <summary>
    /// The semantic version of the localized strings defined in this component.
    /// </summary>
    [JsonPropertyName("localizedDataSemanticVersion")]
    public string? LocalizedDataSemanticVersion { get; init; }

    /// <summary>
    /// The minimum value of localizedDataSemanticVersion required in translations consumed by this component.
    /// </summary>
    [JsonPropertyName("minimumRequiredLocalizedDataSemanticVersion")]
    public string? MinimumRequiredLocalizedDataSemanticVersion { get; init; }

    /// <summary>
    /// The component which is strongly associated with this component. For a translation, this refers to the component
    /// which has been translated. For an extension, this is the driver that provides the extension's plugin model.
    /// </summary>
    [JsonPropertyName("associatedComponent")]
    public ToolComponentReference? AssociatedComponent { get; init; }

    /// <summary>
    /// Translation metadata, required for a translation, not populated by other component types.
    /// </summary>
    [JsonPropertyName("translationMetadata")]
    public TranslationMetadata? TranslationMetadata { get; init; }

    /// <summary>
    /// An array of toolComponentReference objects to declare the taxonomies supported by the tool component.
    /// </summary>
    [JsonPropertyName("supportedTaxonomies")]
    public IReadOnlyList<ToolComponentReference>? SupportedTaxonomies { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the tool component.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
