using System.Text.Json.Serialization;
using SarifKit.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Specifies the importance of a role played by an artifact.
/// </summary>
[JsonConverter(typeof(SarifStringEnumConverter<Importance>))]
public enum Importance
{
    /// <summary>The artifact is important to the result.</summary>
    Important,

    /// <summary>The artifact is essential to the result.</summary>
    Essential,

    /// <summary>The artifact is unimportant to the result.</summary>
    Unimportant
}
