using System.Text.Json.Serialization;
using SarifKit.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Specifies the state of a result relative to a baseline.
/// </summary>
[JsonConverter(typeof(SarifStringEnumConverter<BaselineState>))]
public enum BaselineState
{
    /// <summary>The result is new in the current run.</summary>
    New,

    /// <summary>The result is unchanged from the baseline.</summary>
    Unchanged,

    /// <summary>The result exists in both the baseline and the current run, but has changed.</summary>
    Updated,

    /// <summary>The result was present in the baseline but is absent in the current run.</summary>
    Absent
}
