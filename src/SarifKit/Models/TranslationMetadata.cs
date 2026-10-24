using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Provides additional metadata for a translation.
/// </summary>
public sealed class TranslationMetadata
{
    /// <summary>
    /// The name of the translated tool component.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// The full name associated with the translated tool component.
    /// </summary>
    [JsonPropertyName("fullName")]
    public string? FullName { get; init; }

    /// <summary>
    /// A short description of the translated tool component.
    /// </summary>
    [JsonPropertyName("shortDescription")]
    public MultiformatMessageString? ShortDescription { get; init; }

    /// <summary>
    /// A comprehensive description of the translated tool component.
    /// </summary>
    [JsonPropertyName("fullDescription")]
    public MultiformatMessageString? FullDescription { get; init; }

    /// <summary>
    /// The absolute URI from which the translation metadata can be downloaded.
    /// </summary>
    [JsonPropertyName("downloadUri")]
    public string? DownloadUri { get; init; }

    /// <summary>
    /// The absolute URI at which information about the translation metadata can be found.
    /// </summary>
    [JsonPropertyName("informationUri")]
    public string? InformationUri { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the translation metadata.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
