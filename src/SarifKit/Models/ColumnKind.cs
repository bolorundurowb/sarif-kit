using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Specifies the unit for measuring columns in a region.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<ColumnKind>))]
public enum ColumnKind
{
    Utf16CodeUnits,
    CodeUnits
}
