using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Specifies the failure level for a result or notification.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<FailureLevel>))]
public enum FailureLevel
{
    None,
    Note,
    Warning,
    Error
}
