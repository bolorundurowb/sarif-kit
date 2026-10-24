using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Describes a condition relevant to the tool itself, as opposed to being relevant to a target being analyzed by the tool.
/// </summary>
public sealed class Notification
{
    /// <summary>
    /// The locations relevant to this notification.
    /// </summary>
    [JsonPropertyName("locations")]
    public IReadOnlyList<Location>? Locations { get; init; }

    /// <summary>
    /// A message that describes the condition that was encountered.
    /// </summary>
    [JsonPropertyName("message")]
    public required Message Message { get; init; }

    /// <summary>
    /// A value specifying the severity level of the notification.
    /// </summary>
    [JsonPropertyName("level")]
    public FailureLevel? Level { get; init; }

    /// <summary>
    /// The thread identifier of the code that generated the notification.
    /// </summary>
    [JsonPropertyName("threadId")]
    public int? ThreadId { get; init; }

    /// <summary>
    /// The time at which the analysis tool generated the notification.
    /// </summary>
    [JsonPropertyName("timeUtc")]
    public DateTimeOffset? TimeUtc { get; init; }

    /// <summary>
    /// The runtime exception, if any, relevant to this notification.
    /// </summary>
    [JsonPropertyName("exception")]
    public ExceptionData? Exception { get; init; }

    /// <summary>
    /// A reference used to locate the descriptor relevant to this notification.
    /// </summary>
    [JsonPropertyName("descriptor")]
    public ReportingDescriptorReference? Descriptor { get; init; }

    /// <summary>
    /// A reference used to locate the rule descriptor associated with this notification.
    /// </summary>
    [JsonPropertyName("associatedRule")]
    public ReportingDescriptorReference? AssociatedRule { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the notification.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
