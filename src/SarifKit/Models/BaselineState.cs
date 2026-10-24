using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Specifies the state of a result relative to a baseline.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<BaselineState>))]
public enum BaselineState
{
    New,
    Unchanged,
    Updated,
    Absent
}
