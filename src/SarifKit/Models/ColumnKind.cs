using System.Text.Json.Serialization;
using SarifKit.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Specifies the unit for measuring columns in a region.
/// </summary>
[JsonConverter(typeof(SarifStringEnumConverter<ColumnKind>))]
public enum ColumnKind
{
    /// <summary>Columns are measured in UTF-16 code units.</summary>
    Utf16CodeUnits,

    /// <summary>Columns are measured in Unicode code points.</summary>
    UnicodeCodePoints
}
