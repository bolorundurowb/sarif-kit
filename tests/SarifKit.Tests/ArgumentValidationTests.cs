using System.Text;
using System.Text.Json;
using SarifKit.IO;
using SarifKit.Models;
using Xunit;

namespace SarifKit.Tests;

/// <summary>
/// Verifies the documented exception contracts of <see cref="SarifReader"/> and <see cref="SarifWriter"/>: which
/// argument is null-checked, and which malformed inputs produce <see cref="JsonException"/> versus
/// <see cref="InvalidDataException"/>.
/// </summary>
public sealed class ArgumentValidationTests
{
    private static SarifLog MinimalLog()
    {
        return new SarifLog
        {
            Version = "2.1.0",
            Runs = [new SarifRun { Tool = new Tool { Driver = new ToolComponent { Name = "tool" } } }]
        };
    }

    [Fact]
    public void Read_NullStream_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => SarifReader.Read((Stream)null!));
    }

    [Fact]
    public void Read_NullString_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => SarifReader.Read((string)null!));
    }

    [Fact]
    public async Task ReadAsync_NullStream_Throws()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => SarifReader.ReadAsync(null!).AsTask());
    }

    [Theory]
    [InlineData("null")]
    [InlineData("  null  ")]
    public void Read_LiteralNullJson_ThrowsInvalidDataException(string json)
    {
        Assert.Throws<InvalidDataException>(() => SarifReader.Read(json));
        Assert.Throws<InvalidDataException>(() => SarifReader.Read(Encoding.UTF8.GetBytes(json).AsSpan()));

        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
        Assert.Throws<InvalidDataException>(() => SarifReader.Read(stream));
    }

    [Fact]
    public async Task ReadAsync_LiteralNullJson_ThrowsInvalidDataException()
    {
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes("null"));
        await Assert.ThrowsAsync<InvalidDataException>(() => SarifReader.ReadAsync(stream).AsTask());
    }

    [Theory]
    [InlineData("")]
    [InlineData("{")]
    [InlineData("not json")]
    [InlineData("""{"version": "2.1.0", "runs": [}""")]
    public void Read_MalformedJson_ThrowsJsonException(string json)
    {
        Assert.Throws<JsonException>(() => SarifReader.Read(json));
    }

    [Fact]
    public async Task Write_NullLog_Throws()
    {
        using var stream = new MemoryStream();
        Assert.Throws<ArgumentNullException>(() => SarifWriter.Write(null!, stream));
        Assert.Throws<ArgumentNullException>(() => SarifWriter.WriteToString(null!));
        Assert.Throws<ArgumentNullException>(() => SarifWriter.WriteToUtf8Bytes(null!));
        await Assert.ThrowsAsync<ArgumentNullException>(() => SarifWriter.WriteAsync(null!, stream));
    }

    [Fact]
    public async Task Write_NullStream_Throws()
    {
        var log = MinimalLog();
        Assert.Throws<ArgumentNullException>(() => SarifWriter.Write(log, null!));
        await Assert.ThrowsAsync<ArgumentNullException>(() => SarifWriter.WriteAsync(log, null!));
    }
}
