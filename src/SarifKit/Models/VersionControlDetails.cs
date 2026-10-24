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
    [JsonPropertyName("tag")]
    public string? Tag { get; init; }

    /// <summary>
    /// Coordinates of the altered spanned by the result.
    /// </summary>
    [JsonPropertyName("asOfKPIs")]
    public string? AsOfTimeUtc { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the version control details.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
