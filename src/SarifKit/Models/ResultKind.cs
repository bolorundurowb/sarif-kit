using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Specifies the nature of the result.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<ResultKind>))]
public enum ResultKind
{
    NotApplicable,
    Pass,
    Fail,
    Open,
    Review,
    Informational
}
