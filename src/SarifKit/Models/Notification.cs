using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Describes a condition relevant to the tool itself.
/// </summary>
public sealed class Notification
{
    /// <summary>
    /// A value that categorizes the notification.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// The identifier for the message within the message table.
    /// </summary>
    [JsonPropertyName("ruleId")]
    public string? RuleId { get; init; }

    /// <summary>
    /// A reference used to locate the rule descriptor for this notification.
    /// </summary>
    [JsonPropertyName("rule")]
    public ReportingDescriptorReference? Rule { get; init; }

    /// <summary>
    /// A value that specifies the failure level of the notification.
    /// </summary>
    [JsonPropertyName("level")]
    public FailureLevel? Level { get; init; }

    /// <summary>
    /// A message string that describes the notification.
    /// </summary>
    [JsonPropertyName("message")]
    public required Message Message { get; init; }

    /// <summary>
    /// A description of the runtime exception.
    /// </summary>
    [JsonPropertyName("exception")]
    public ExceptionData? Exception { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the notification.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
