using System.Text.Json.Serialization;
using SarifKit.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Specifies the nature of the result.
/// </summary>
[JsonConverter(typeof(SarifStringEnumConverter<ResultKind>))]
public enum ResultKind
{
    /// <summary>The rule does not apply at the location.</summary>
    NotApplicable,

    /// <summary>The rule was evaluated and passed.</summary>
    Pass,

    /// <summary>The rule was evaluated and failed.</summary>
    Fail,

    /// <summary>The rule requires manual review.</summary>
    Open,

    /// <summary>The result requires review.</summary>
    Review,

    /// <summary>The result is informational only.</summary>
    Informational
}
