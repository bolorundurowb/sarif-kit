using System.Text;
using System.Text.Json;
using SarifKit.Internal;
using SarifKit.Models;
using SarifKit.Serialization;

namespace SarifKit.IO;

/// <summary>
/// Provides high-performance methods for writing SARIF logs.
/// </summary>
public static class SarifWriter
{
    /// <summary>
    /// Writes the specified <see cref="SarifLog"/> to the destination stream.
    /// </summary>
    /// <param name="log">The SARIF log to write.</param>
    /// <param name="destination">The stream to which the SARIF JSON data is written.</param>
    /// <param name="indented">Whether the output JSON should be indented.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    public static void Write(
        SarifLog log,
        Stream destination,
        bool indented = true,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(log);
        ArgumentNullException.ThrowIfNull(destination);

        cancellationToken.ThrowIfCancellationRequested();

        using var writer = new Utf8JsonWriter(destination, new JsonWriterOptions
        {
            Indented = indented,
            SkipValidation = false
        });

        JsonSerializer.Serialize(writer, log, SarifJsonContext.Default.SarifLog);
    }

    /// <summary>
    /// Serializes the specified <see cref="SarifLog"/> to a string.
    /// </summary>
    /// <param name="log">The SARIF log to serialize.</param>
    /// <param name="indented">Whether the output JSON should be indented.</param>
    /// <returns>A JSON string representing the SARIF log.</returns>
    public static string WriteToString(SarifLog log, bool indented = true)
    {
        ArgumentNullException.ThrowIfNull(log);

        using var buffer = new PooledByteBufferWriter();
        using var writer = new Utf8JsonWriter(buffer, new JsonWriterOptions { Indented = indented });
        JsonSerializer.Serialize(writer, log, SarifJsonContext.Default.SarifLog);
        return Encoding.UTF8.GetString(buffer.WrittenSpan);
    }

    /// <summary>
    /// Serializes the specified <see cref="SarifLog"/> to a UTF-8 encoded byte array.
    /// </summary>
    /// <param name="log">The SARIF log to serialize.</param>
    /// <param name="indented">Whether the output JSON should be indented.</param>
    /// <returns>A UTF-8 encoded byte array representing the SARIF log.</returns>
    public static byte[] WriteToUtf8Bytes(SarifLog log, bool indented = true)
    {
        ArgumentNullException.ThrowIfNull(log);

        using var buffer = new PooledByteBufferWriter();
        using var writer = new Utf8JsonWriter(buffer, new JsonWriterOptions { Indented = indented });
        JsonSerializer.Serialize(writer, log, SarifJsonContext.Default.SarifLog);
        return buffer.WrittenSpan.ToArray();
    }

    /// <summary>
    /// Asynchronously writes the specified <see cref="SarifLog"/> to the destination stream.
    /// </summary>
    /// <param name="log">The SARIF log to write.</param>
    /// <param name="destination">The stream to which the SARIF JSON data is written.</param>
    /// <param name="indented">Whether the output JSON should be indented.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public static async Task WriteAsync(
        SarifLog log,
        Stream destination,
        bool indented = true,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(log);
        ArgumentNullException.ThrowIfNull(destination);

        cancellationToken.ThrowIfCancellationRequested();

        // For async writing, serialize to a pooled buffer first to avoid sync-over-async in Utf8JsonWriter.
        byte[] bytes = WriteToUtf8Bytes(log, indented);
        await destination.WriteAsync(bytes.AsMemory(0, bytes.Length), cancellationToken).ConfigureAwait(false);
    }
}
