using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Serialization;

/// <summary>
/// Converts enum values to and from the camelCase JSON strings used by SARIF.
/// </summary>
/// <remarks>
/// SARIF enumerations are closed sets, so an unrecognised string causes a <see cref="JsonException"/> rather than
/// being silently mapped to a default value. Matching ignores case, in line with
/// <see cref="JsonSerializerOptions.PropertyNameCaseInsensitive"/>.
/// </remarks>
internal sealed class SarifStringEnumConverter<TEnum> : JsonConverter<TEnum>
    where TEnum : struct, Enum
{
    private static readonly Dictionary<TEnum, string> NamesByValue = BuildNamesByValue();

    private static readonly Dictionary<string, TEnum> ValuesByName = BuildValuesByName();

    public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException($"Expected a string value for enum '{typeof(TEnum).Name}'.");
        }

        var name = reader.GetString()!;
        if (ValuesByName.TryGetValue(name, out var value))
        {
            return value;
        }

        throw new JsonException($"Unable to convert '{name}' to enum '{typeof(TEnum).Name}'.");
    }

    public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
    {
        if (!NamesByValue.TryGetValue(value, out var name))
        {
            throw new JsonException($"'{value}' is not a defined value of enum '{typeof(TEnum).Name}'.");
        }

        writer.WriteStringValue(name);
    }

    private static Dictionary<TEnum, string> BuildNamesByValue()
    {
        var namesByValue = new Dictionary<TEnum, string>();
        foreach (var value in Enum.GetValues<TEnum>())
        {
            namesByValue[value] = ToCamelCase(value.ToString());
        }

        return namesByValue;
    }

    private static Dictionary<string, TEnum> BuildValuesByName()
    {
        var valuesByName = new Dictionary<string, TEnum>(StringComparer.OrdinalIgnoreCase);
        foreach (var (value, name) in NamesByValue)
        {
            valuesByName[name] = value;
        }

        return valuesByName;
    }

    private static string ToCamelCase(string value)
    {
        if (string.IsNullOrEmpty(value) || char.IsLower(value[0]))
        {
            return value;
        }

        return string.Create(value.Length, value, static (span, source) =>
        {
            source.AsSpan().CopyTo(span);
            span[0] = char.ToLowerInvariant(span[0]);
        });
    }
}
