using System.Text.Json.Serialization;
using SarifKit.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Specifies the failure level for a result or notification.
/// </summary>
[JsonConverter(typeof(SarifStringEnumConverter<FailureLevel>))]
public enum FailureLevel
{
    /// <summary>The failure level is not specified.</summary>
    None,

    /// <summary>A note-level result.</summary>
    Note,

    /// <summary>A warning-level result.</summary>
    Warning,

    /// <summary>An error-level result.</summary>
    Error
}
