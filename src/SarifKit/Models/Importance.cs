using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// Specifies the importance of a role played by an artifact.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<Importance>))]
public enum Importance
{
    Important,
    Essential,
    Unimportant
}
