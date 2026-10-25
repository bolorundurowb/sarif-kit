using SarifKit.Internal;
using Xunit;

namespace SarifKit.Tests;

/// <summary>
/// Exercises <see cref="PooledByteBufferWriter"/> directly. <see cref="SarifWriter"/> only drives this type through
/// <see cref="System.Text.Json.Utf8JsonWriter"/>, which never calls <see cref="PooledByteBufferWriter.GetSpan"/> or
/// requests a zero size hint, so those paths need their own tests.
/// </summary>
public sealed class PooledByteBufferWriterTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_NonPositiveInitialCapacity_Throws(int initialCapacity)
    {
        Assert.Throws<ArgumentException>(() => new PooledByteBufferWriter(initialCapacity));
    }

    [Fact]
    public void Advance_NegativeCount_Throws()
    {
        using var writer = new PooledByteBufferWriter();
        Assert.Throws<ArgumentException>(() => writer.Advance(-1));
    }

    [Fact]
    public void Advance_PastBufferEnd_Throws()
    {
        using var writer = new PooledByteBufferWriter(4);

        // ArrayPool<byte>.Shared.Rent can return a buffer larger than requested, so size the overshoot against the
        // actual rented capacity rather than the requested initial capacity.
        var capacity = writer.GetSpan().Length;
        Assert.Throws<InvalidOperationException>(() => writer.Advance(capacity + 1));
    }

    [Fact]
    public void GetSpan_NegativeSizeHint_Throws()
    {
        using var writer = new PooledByteBufferWriter();
        Assert.Throws<ArgumentException>(() => writer.GetSpan(-1));
    }

    [Fact]
    public void GetMemory_NegativeSizeHint_Throws()
    {
        using var writer = new PooledByteBufferWriter();
        Assert.Throws<ArgumentException>(() => writer.GetMemory(-1));
    }

    [Fact]
    public void GetSpan_DefaultSizeHint_ReturnsNonEmptySpan()
    {
        using var writer = new PooledByteBufferWriter(4);
        Assert.True(writer.GetSpan().Length >= 4);
    }

    [Fact]
    public void WrittenCount_And_WrittenMemory_ReflectAdvance()
    {
        using var writer = new PooledByteBufferWriter();
        var span = writer.GetSpan(2);
        span[0] = 1;
        span[1] = 2;
        writer.Advance(2);

        Assert.Equal(2, writer.WrittenCount);
        Assert.Equal(new byte[] { 1, 2 }, writer.WrittenMemory.ToArray());
        Assert.Equal(new byte[] { 1, 2 }, writer.WrittenSpan.ToArray());
    }

    [Fact]
    public void GetSpan_GrowthPreservesPreviouslyWrittenData()
    {
        using var writer = new PooledByteBufferWriter(4);

        var first = writer.GetSpan(2);
        first[0] = 0xAA;
        first[1] = 0xBB;
        writer.Advance(2);

        // Request far more space than the initial 4-byte buffer holds, forcing a grow-and-copy.
        var grown = writer.GetSpan(64);
        Assert.True(grown.Length >= 64);
        grown[0] = 0xCC;
        writer.Advance(1);

        Assert.Equal(new byte[] { 0xAA, 0xBB, 0xCC }, writer.WrittenSpan.ToArray());
    }

    [Fact]
    public void Dispose_CalledTwice_DoesNotThrow()
    {
        var writer = new PooledByteBufferWriter();
        writer.Dispose();
        writer.Dispose();
    }

    [Fact]
    public void Dispose_ClearsWrittenData()
    {
        var writer = new PooledByteBufferWriter();
        writer.GetSpan(1);
        writer.Advance(1);

        writer.Dispose();

        Assert.Equal(0, writer.WrittenCount);
        Assert.True(writer.WrittenSpan.IsEmpty);
    }
}
