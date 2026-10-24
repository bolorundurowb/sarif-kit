using System.Text.Json.Serialization;
using SarifKit.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Specifies the state of a suppression.
/// </summary>
[JsonConverter(typeof(SarifStringEnumConverter<SuppressionStatus>))]
public enum SuppressionStatus
{
    /// <summary>The suppression has been accepted.</summary>
    Accepted,

    /// <summary>The suppression is awaiting review.</summary>
    UnderReview,

    /// <summary>The suppression has been rejected.</summary>
    Rejected
}
