using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SarifKit.Internal;

/// <summary>
/// An <see cref="IBufferWriter{T}"/> implementation that rents buffers from <see cref="ArrayPool{T}"/>.
/// </summary>
internal sealed class PooledByteBufferWriter : IBufferWriter<byte>, IDisposable
{
    private const int MinimumBufferSize = 256;

    private byte[] _buffer;
    private int _index;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="PooledByteBufferWriter"/> class.
    /// </summary>
    /// <param name="initialCapacity">The initial capacity of the buffer.</param>
    public PooledByteBufferWriter(int initialCapacity = MinimumBufferSize)
    {
        if (initialCapacity <= 0)
        {
            throw new ArgumentException("Initial capacity must be greater than zero.", nameof(initialCapacity));
        }

        _buffer = ArrayPool<byte>.Shared.Rent(initialCapacity);
        _index = 0;
    }

    /// <summary>
    /// Gets the total amount of data written to the underlying buffer so far.
    /// </summary>
    public int WrittenCount => _index;

    /// <summary>
    /// Gets the amount of data written to the underlying buffer so far as a <see cref="ReadOnlySpan{T}"/>.
    /// </summary>
    public ReadOnlySpan<byte> WrittenSpan => _buffer.AsSpan(0, _index);

    /// <summary>
    /// Gets the amount of data written to the underlying buffer so far as a <see cref="ReadOnlyMemory{T}"/>.
    /// </summary>
    public ReadOnlyMemory<byte> WrittenMemory => _buffer.AsMemory(0, _index);

    /// <inheritdoc />
    public void Advance(int count)
    {
        if (count < 0)
        {
            throw new ArgumentException("Advance count must be non-negative.", nameof(count));
        }

        if (_index > _buffer.Length - count)
        {
            throw new InvalidOperationException("Cannot advance past the end of the buffer.");
        }

        _index += count;
    }

    /// <inheritdoc />
    public Memory<byte> GetMemory(int sizeHint = 0)
    {
        CheckAndResizeBuffer(sizeHint);
        return _buffer.AsMemory(_index);
    }

    /// <inheritdoc />
    public Span<byte> GetSpan(int sizeHint = 0)
    {
        CheckAndResizeBuffer(sizeHint);
        return _buffer.AsSpan(_index);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        if (!_disposed)
        {
            _disposed = true;
            byte[] buffer = _buffer;
            _buffer = Array.Empty<byte>();
            _index = 0;
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void CheckAndResizeBuffer(int sizeHint)
    {
        if (sizeHint < 0)
        {
            throw new ArgumentException("Size hint must be non-negative.", nameof(sizeHint));
        }

        if (sizeHint == 0)
        {
            sizeHint = MinimumBufferSize;
        }

        int availableSpace = _buffer.Length - _index;
        if (sizeHint > availableSpace)
        {
            int growBy = Math.Max(sizeHint, _buffer.Length);
            int newSize = checked(_buffer.Length + growBy);
            byte[] newBuffer = ArrayPool<byte>.Shared.Rent(newSize);
            Buffer.BlockCopy(_buffer, 0, newBuffer, 0, _index);
            byte[] oldBuffer = _buffer;
            _buffer = newBuffer;
            ArrayPool<byte>.Shared.Return(oldBuffer);
        }

        Debug.Assert(_buffer.Length - _index > 0);
    }
}
