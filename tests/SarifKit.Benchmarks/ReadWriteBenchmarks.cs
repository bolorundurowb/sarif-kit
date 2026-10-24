using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using SarifKit.IO;
using Sdk = Microsoft.CodeAnalysis.Sarif;

namespace SarifKit.Benchmarks;

[MemoryDiagnoser]
public class ReadWriteBenchmarks
{
    private const int ResultCount = 50_000;
    private const int MinimumPayloadBytes = 10 * 1024 * 1024;

    private byte[] _sarifBytes = [];
    private SarifKit.Models.SarifLog _kitLog = null!;
    private Sdk.SarifLog _sdkLog = null!;

    [GlobalSetup]
    public void Setup()
    {
        var results = new List<SarifKit.Models.Result>(ResultCount);
        for (int i = 0; i < ResultCount; i++)
        {
            results.Add(new SarifKit.Models.Result
            {
                RuleId = $"RULE{i:D5}",
                Message = new SarifKit.Models.Message { Text = $"This is a sample result message with enough text to inflate size. Index {i}" },
                Locations =
                [
                    new SarifKit.Models.Location
                    {
                        PhysicalLocation = new SarifKit.Models.PhysicalLocation
                        {
                            ArtifactLocation = new SarifKit.Models.ArtifactLocation { Uri = $"file:///src/component/folder/file{i:D5}.cs" },
                            Region = new SarifKit.Models.Region { StartLine = i + 1, StartColumn = 1, EndColumn = 80 }
                        }
                    }
                ]
            });
        }

        _kitLog = new SarifKit.Models.SarifLog
        {
            Version = "2.1.0",
            Runs =
            [
                new SarifKit.Models.SarifRun
                {
                    Tool = new SarifKit.Models.Tool
                    {
                        Driver = new SarifKit.Models.ToolComponent
                        {
                            Name = "BenchmarkTool",
                            Version = "1.0.0",
                            Rules =
                            [
                                new SarifKit.Models.ReportingDescriptor
                                {
                                    Id = "RULE00001",
                                    Name = "SampleRule",
                                    ShortDescription = new SarifKit.Models.MultiformatMessageString { Text = "A sample rule for benchmarking." }
                                }
                            ]
                        }
                    },
                    Results = results
                }
            ]
        };

        _sarifBytes = SarifWriter.WriteToUtf8Bytes(_kitLog, indented: false);
        if (_sarifBytes.Length < MinimumPayloadBytes)
        {
            throw new InvalidOperationException(
                $"Benchmark payload is {_sarifBytes.Length:N0} bytes; expected at least {MinimumPayloadBytes:N0}.");
        }

        using var sdkSource = new MemoryStream(_sarifBytes, writable: false);
        _sdkLog = Sdk.SarifLog.Load(sdkSource);
    }

    [Benchmark(Baseline = true)]
    public Sdk.SarifLog Read_SarifSdk()
    {
        using var source = new MemoryStream(_sarifBytes, writable: false);
        return Sdk.SarifLog.Load(source);
    }

    [Benchmark]
    public SarifKit.Models.SarifLog Read_SarifKit()
    {
        using var source = new MemoryStream(_sarifBytes, writable: false);
        return SarifReader.Read(source);
    }

    [Benchmark]
    public void Write_SarifSdk()
    {
        using var destination = new MemoryStream();
        _sdkLog.Save(destination);
    }

    [Benchmark]
    public void Write_SarifKit()
    {
        using var destination = new MemoryStream();
        SarifWriter.Write(_kitLog, destination, indented: false);
    }

    [Benchmark]
    public void Buffer_PooledByteBufferWriter()
    {
        using var writer = new SarifKit.Internal.PooledByteBufferWriter();
        _sarifBytes.CopyTo(writer.GetSpan(_sarifBytes.Length));
        writer.Advance(_sarifBytes.Length);
        _ = writer.WrittenSpan.ToArray();
    }

    [Benchmark]
    public void Buffer_MemoryStream()
    {
        using var ms = new MemoryStream();
        ms.Write(_sarifBytes, 0, _sarifBytes.Length);
        _ = ms.ToArray();
    }
}

public static class Program
{
    public static void Main(string[] args)
    {
        _ = BenchmarkRunner.Run<ReadWriteBenchmarks>(args: args);
    }
}
