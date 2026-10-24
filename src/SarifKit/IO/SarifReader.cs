using System.Text;
using System.Text.Json;
using SarifKit.Models;
using SarifKit.Serialization;

namespace SarifKit.IO;

/// <summary>
/// Provides high-performance methods for reading SARIF logs.
/// </summary>
public static class SarifReader
{
    /// <summary>
    /// Reads a <see cref="SarifLog"/> from the specified stream.
    /// </summary>
    /// <param name="source">The stream containing the SARIF JSON data.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>The deserialized <see cref="SarifLog"/>.</returns>
    /// <exception cref="InvalidDataException">Thrown when the source does not represent a valid SARIF log.</exception>
    public static SarifLog Read(Stream source, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(source);

        SarifLog? log = JsonSerializer.Deserialize(source, SarifJsonContext.Default.SarifLog);
        return log ?? throw new InvalidDataException("SARIF log deserialized to null.");
    }

    /// <summary>
    /// Reads a <see cref="SarifLog"/> from the specified UTF-8 encoded JSON span.
    /// </summary>
    /// <param name="utf8Json">The UTF-8 encoded JSON data.</param>
    /// <returns>The deserialized <see cref="SarifLog"/>.</returns>
    /// <exception cref="InvalidDataException">Thrown when the source does not represent a valid SARIF log.</exception>
    public static SarifLog Read(ReadOnlySpan<byte> utf8Json)
    {
        SarifLog? log = JsonSerializer.Deserialize(utf8Json, SarifJsonContext.Default.SarifLog);
        return log ?? throw new InvalidDataException("SARIF log deserialized to null.");
    }

    /// <summary>
    /// Reads a <see cref="SarifLog"/> from the specified JSON string.
    /// </summary>
    /// <param name="json">The JSON string.</param>
    /// <returns>The deserialized <see cref="SarifLog"/>.</returns>
    /// <exception cref="InvalidDataException">Thrown when the source does not represent a valid SARIF log.</exception>
    public static SarifLog Read(string json)
    {
        ArgumentNullException.ThrowIfNull(json);
        return Read(Encoding.UTF8.GetBytes(json));
    }

    /// <summary>
    /// Asynchronously reads a <see cref="SarifLog"/> from the specified stream.
    /// </summary>
    /// <param name="source">The stream containing the SARIF JSON data.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous read operation.</returns>
    public static ValueTask<SarifLog?> ReadAsync(Stream source, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(source);
        return JsonSerializer.DeserializeAsync(source, SarifJsonContext.Default.SarifLog, cancellationToken);
    }
}
