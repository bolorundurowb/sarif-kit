using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// A single artifact relevant to a run.
/// </summary>
public sealed class Artifact
{
    /// <summary>
    /// A short description of the artifact.
    /// </summary>
    [JsonPropertyName("description")]
    public Message? Description { get; init; }

    /// <summary>
    /// The location of the artifact.
    /// </summary>
    [JsonPropertyName("location")]
    public ArtifactLocation? Location { get; init; }

    /// <summary>
    /// Identifies the index of the artifact within the run artifacts array.
    /// </summary>
    [JsonPropertyName("parentIndex")]
    public int? ParentIndex { get; init; }

    /// <summary>
    /// The offset in bytes of the artifact within its containing artifact.
    /// </summary>
    [JsonPropertyName("offset")]
    public int? Offset { get; init; }

    /// <summary>
    /// The length of the artifact in bytes.
    /// </summary>
    [JsonPropertyName("length")]
    public int? Length { get; init; }

    /// <summary>
    /// The role or roles played by the artifact in the result.
    /// </summary>
    [JsonPropertyName("roles")]
    public IReadOnlyList<string>? Roles { get; init; }

    /// <summary>
    /// The MIME type (RFC 2045) of the artifact.
    /// </summary>
    [JsonPropertyName("mimeType")]
    public string? MimeType { get; init; }

    /// <summary>
    /// The contents of the artifact.
    /// </summary>
    [JsonPropertyName("contents")]
    public ArtifactContent? Contents { get; init; }

    /// <summary>
    /// Specifies the encoding for an artifact object that refers to a text file.
    /// </summary>
    [JsonPropertyName("encoding")]
    public string? Encoding { get; init; }

    /// <summary>
    /// Specifies the source language for any artifact object that refers to a text file.
    /// </summary>
    [JsonPropertyName("sourceLanguage")]
    public string? SourceLanguage { get; init; }

    /// <summary>
    /// A dictionary of hashes of the artifact contents.
    /// </summary>
    [JsonPropertyName("hashes")]
    public IReadOnlyDictionary<string, string>? Hashes { get; init; }

    /// <summary>
    /// The date and time at which the artifact was last modified.
    /// </summary>
    [JsonPropertyName("lastModifiedTimeUtc")]
    public DateTimeOffset? LastModifiedTimeUtc { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the artifact.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
