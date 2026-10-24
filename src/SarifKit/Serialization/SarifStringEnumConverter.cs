using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Serialization;

/// <summary>
/// Converts enum values to and from camelCase JSON strings.
/// </summary>
internal sealed class SarifStringEnumConverter<TEnum> : JsonConverter<TEnum>
    where TEnum : struct, Enum
{
    public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value is null)
        {
            throw new JsonException($"Expected a string value for enum '{typeof(TEnum).Name}'.");
        }

        foreach (var name in Enum.GetNames<TEnum>())
        {
            if (ToCamelCase(name).Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                return Enum.Parse<TEnum>(name);
            }
        }

        throw new JsonException($"Unable to convert '{value}' to enum '{typeof(TEnum).Name}'.");
    }

    public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(ToCamelCase(value.ToString()));
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
