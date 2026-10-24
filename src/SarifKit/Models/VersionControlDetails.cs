using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Describes the relevant aspects of a version control system.
/// </summary>
public sealed class VersionControlDetails
{
    /// <summary>
    /// The URI of the repository.
    /// </summary>
    [JsonPropertyName("repositoryUri")]
    public required string RepositoryUri { get; init; }

    /// <summary>
    /// A string that uniquely and persistently identifies the revision.
    /// </summary>
    [JsonPropertyName("revisionId")]
    public string? RevisionId { get; init; }

    /// <summary>
    /// The name of a branch containing the revision.
    /// </summary>
    [JsonPropertyName("branch")]
    public string? Branch { get; init; }

    /// <summary>
    /// A tag that has been applied to the revision.
    /// </summary>
    [JsonPropertyName("revisionTag")]
    public string? RevisionTag { get; init; }

    /// <summary>
    /// The time at which the repository was in the state described by this object.
    /// </summary>
    [JsonPropertyName("asOfTimeUtc")]
    public DateTimeOffset? AsOfTimeUtc { get; init; }

    /// <summary>
    /// The location in the local file system to which the root of the repository was mapped at the time of the analysis.
    /// </summary>
    [JsonPropertyName("mappedTo")]
    public ArtifactLocation? MappedTo { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the version control details.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
