using System.Text;
using System.Text.Json;
using SarifKit.IO;
using SarifKit.Models;
using Xunit;

namespace SarifKit.Tests;

public sealed class RoundTripTests
{
    private static SarifLog MakeLog()
    {
        return new SarifLog
        {
            Version = "2.1.0",
            Runs =
            [
                new SarifRun
                {
                    Tool = new Tool
                    {
                        Driver = new ToolComponent
                        {
                            Name = "TestTool",
                            Version = "1.0.0",
                            Rules =
                            [
                                new ReportingDescriptor
                                {
                                    Id = "RULE001",
                                    Name = "TestRule",
                                    ShortDescription = new MultiformatMessageString { Text = "Short" },
                                    HelpUri = "https://example.com"
                                }
                            ]
                        }
                    },
                    Results =
                    [
                        new Result
                        {
                            RuleId = "RULE001",
                            Level = FailureLevel.Warning,
                            Kind = ResultKind.Fail,
                            Message = new Message { Text = "A warning" },
                            Locations =
                            [
                                new Location
                                {
                                    PhysicalLocation = new PhysicalLocation
                                    {
                                        ArtifactLocation = new ArtifactLocation { Uri = "file:///src/program.cs" },
                                        Region = new Region { StartLine = 10, StartColumn = 5 }
                                    }
                                }
                            ]
                        }
                    ],
                    Invocations =
                    [
                        new Invocation
                        {
                            CommandLine = "test.exe",
                            ExecutionSuccessful = true
                        }
                    ]
                }
            ]
        };
    }

    [Fact]
    public void RoundTrip_PreservesStructure()
    {
        var original = MakeLog();

        var json = SarifWriter.WriteToString(original);
        var roundTripped = SarifReader.Read(json);

        Assert.Equal(original.Version, roundTripped.Version);
        Assert.Single(roundTripped.Runs);

        var run = roundTripped.Runs[0];
        Assert.Equal("TestTool", run.Tool.Driver.Name);
        Assert.Equal("1.0.0", run.Tool.Driver.Version);
        Assert.NotNull(run.Results);
        Assert.Single(run.Results);

        var result = run.Results![0];
        Assert.Equal("RULE001", result.RuleId);
        Assert.Equal(FailureLevel.Warning, result.Level);
        Assert.Equal("A warning", result.Message.Text);
        Assert.NotNull(result.Locations);
        Assert.Single(result.Locations);
        Assert.Equal("file:///src/program.cs", result.Locations![0].PhysicalLocation!.ArtifactLocation!.Uri);
        Assert.Equal(10, result.Locations![0].PhysicalLocation!.Region!.StartLine);

        Assert.NotNull(run.Invocations);
        Assert.Single(run.Invocations);
        Assert.True(run.Invocations![0].ExecutionSuccessful);
    }

    [Fact]
    public void RoundTrip_StreamApi()
    {
        var original = MakeLog();
        using var ms = new MemoryStream();
        SarifWriter.Write(original, ms);
        ms.Position = 0;
        var roundTripped = SarifReader.Read(ms);
        Assert.Equal(original.Version, roundTripped.Version);
        Assert.Single(roundTripped.Runs);
    }

    [Fact]
    public void RoundTrip_SpanApi_MatchesStream()
    {
        var original = MakeLog();
        using var ms = new MemoryStream();
        SarifWriter.Write(original, ms);
        var bytes = ms.ToArray();

        var fromSpan = SarifReader.Read(bytes.AsSpan());
        var fromString = SarifReader.Read(Encoding.UTF8.GetString(bytes));

        Assert.Equal(fromSpan.Version, fromString.Version);
        Assert.Equal(fromSpan.Runs.Count, fromString.Runs.Count);
    }

    [Fact]
    public void RoundTrip_EmptyRuns()
    {
        var log = new SarifLog { Version = "2.1.0", Runs = [] };
        var json = SarifWriter.WriteToString(log);
        Assert.Contains("\"runs\": []", json);

        var roundTripped = SarifReader.Read(json);
        Assert.Empty(roundTripped.Runs);
    }

    [Fact]
    public void RoundTrip_Unicode()
    {
        var log = new SarifLog
        {
            Version = "2.1.0",
            Runs =
            [
                new SarifRun
                {
                    Tool = new Tool { Driver = new ToolComponent { Name = "tool" } },
                    Results =
                    [
                        new Result
                        {
                            Message = new Message { Text = "日本語 🎉" }
                        }
                    ]
                }
            ]
        };

        var json = SarifWriter.WriteToString(log);
        var roundTripped = SarifReader.Read(json);
        Assert.Equal("日本語 🎉", roundTripped.Runs[0].Results![0].Message.Text);
    }

    [Fact]
    public void RoundTrip_LargeLog_UnderTwoSeconds()
    {
        const int count = 50_000;
        var results = new List<Result>(count);
        for (int i = 0; i < count; i++)
        {
            results.Add(new Result
            {
                RuleId = $"RULE{i}",
                Message = new Message { Text = $"Message {i}" },
                Locations =
                [
                    new Location
                    {
                        PhysicalLocation = new PhysicalLocation
                        {
                            ArtifactLocation = new ArtifactLocation { Uri = $"file:///src/{i}.cs" },
                            Region = new Region { StartLine = i }
                        }
                    }
                ]
            });
        }

        var log = new SarifLog
        {
            Version = "2.1.0",
            Runs =
            [
                new SarifRun
                {
                    Tool = new Tool { Driver = new ToolComponent { Name = "perf" } },
                    Results = results
                }
            ]
        };

        var sw = System.Diagnostics.Stopwatch.StartNew();
        var json = SarifWriter.WriteToString(log);
        var roundTripped = SarifReader.Read(json);
        sw.Stop();

        Assert.Equal(count, roundTripped.Runs[0].Results!.Count);
        Assert.True(sw.Elapsed.TotalSeconds < 2, $"Round-trip took {sw.Elapsed.TotalSeconds:F2}s");
    }
}
