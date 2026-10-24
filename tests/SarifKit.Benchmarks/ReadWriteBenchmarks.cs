using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Newtonsoft.Json;
using SarifKit.IO;
using Sdk = Microsoft.CodeAnalysis.Sarif;

namespace SarifKit.Benchmarks;

[MemoryDiagnoser]
public class ReadWriteBenchmarks
{
    private byte[] _sarifBytes = [];
    private string _sarifString = "";
    private string _sarifFilePath = "";
    private SarifKit.Models.SarifLog _kitLog = null!;

    [GlobalSetup]
    public void Setup()
    {
        const int resultCount = 15_000;
        var results = new List<SarifKit.Models.Result>(resultCount);
        for (int i = 0; i < resultCount; i++)
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
                            Region = new SarifKit.Models.Region { StartLine = i, StartColumn = 1, EndColumn = 80 }
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
        _sarifString = Encoding.UTF8.GetString(_sarifBytes);
        _sarifFilePath = Path.Combine(Path.GetTempPath(), $"sarifkit-benchmark-{Guid.NewGuid()}.sarif");
        File.WriteAllText(_sarifFilePath, _sarifString);
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        if (File.Exists(_sarifFilePath))
        {
            File.Delete(_sarifFilePath);
        }
    }

    [Benchmark(Baseline = true)]
    public Sdk.SarifLog Read_SarifSdk()
    {
        return Sdk.SarifLog.Load(_sarifFilePath);
    }

    [Benchmark]
    public SarifKit.Models.SarifLog Read_SarifKit()
    {
        return SarifReader.Read(_sarifBytes);
    }

    [Benchmark]
    public void Write_SarifSdk()
    {
        var sdkLog = Sdk.SarifLog.Load(_sarifFilePath);
        using var ms = new MemoryStream();
        sdkLog.Save(ms);
    }

    [Benchmark]
    public void Write_SarifKit()
    {
        using var ms = new MemoryStream();
        SarifWriter.Write(_kitLog, ms, indented: false);
    }

    [Benchmark]
    public void Buffer_PooledByteBufferWriter()
    {
        using var writer = new SarifKit.Internal.PooledByteBufferWriter();
        writer.GetSpan(_sarifBytes.Length).Fill(0);
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
