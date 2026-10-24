using System.Text.Json.Serialization;
using SarifKit.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Specifies where a suppression is persisted.
/// </summary>
[JsonConverter(typeof(SarifStringEnumConverter<SuppressionKind>))]
public enum SuppressionKind
{
    /// <summary>The suppression is persisted in the source code.</summary>
    InSource,

    /// <summary>The suppression is persisted outside the source code.</summary>
    External
}
