using System.Text.Json;
using SarifKit.IO;
using SarifKit.Models;
using SarifKit.Serialization;
using Xunit;

namespace SarifKit.Tests;

public sealed class EdgeCaseTests
{
    [Fact]
    public void NullProperties_AreOmitted()
    {
        var log = new SarifLog
        {
            Version = "2.1.0",
            Runs =
            [
                new SarifRun
                {
                    Tool = new Tool { Driver = new ToolComponent { Name = "tool" } },
                    Results = null
                }
            ]
        };

        var json = SarifWriter.WriteToString(log);
        Assert.DoesNotContain("\"results\"", json);
    }

    [Theory]
    [InlineData("ruleId")]
    [InlineData("RuleId")]
    public void PropertyNameCase_IsInsensitive(string propertyName)
    {
        var json = $$"""
            {
              "version": "2.1.0",
              "runs": [
                {
                  "tool": { "driver": { "name": "tool" } },
                  "results": [
                    {
                      "{{propertyName}}": "RULE001",
                      "message": { "text": "hello" }
                    }
                  ]
                }
              ]
            }
            """;

        var log = SarifReader.Read(json);
        Assert.Equal("RULE001", log.Runs[0].Results![0].RuleId);
    }

    [Fact]
    public void MissingOptionalMembers_DoNotThrow()
    {
        var json = """
            {
              "version": "2.1.0",
              "runs": [
                {
                  "tool": { "driver": { "name": "tool" } }
                }
              ]
            }
            """;

        var log = SarifReader.Read(json);
        Assert.Single(log.Runs);
        Assert.Null(log.Runs[0].Results);
        Assert.Null(log.Runs[0].Artifacts);
    }

    [Fact]
    public void UnknownMembers_AreIgnored()
    {
        var json = """
            {
              "version": "2.1.0",
              "runs": [],
              "customField": 42,
              "nested": { "a": 1 }
            }
            """;

        var log = SarifReader.Read(json);
        Assert.Empty(log.Runs);
    }

    [Fact]
    public void PropertyBag_RoundTrips()
    {
        var json = """
            {
              "version": "2.1.0",
              "runs": [
                {
                  "tool": { "driver": { "name": "tool" } },
                  "properties": {
                    "number": 42,
                    "text": "hello",
                    "flag": true
                  }
                }
              ]
            }
            """;

        var log = SarifReader.Read(json);
        Assert.NotNull(log.Runs[0].Properties);
        Assert.Equal(JsonValueKind.Number, log.Runs[0].Properties!["number"].ValueKind);
        Assert.Equal(42, log.Runs[0].Properties!["number"].GetInt32());
        Assert.Equal("hello", log.Runs[0].Properties!["text"].GetString());
        Assert.True(log.Runs[0].Properties!["flag"].GetBoolean());

        var written = SarifWriter.WriteToString(log);
        Assert.Contains("\"number\": 42", written);
        Assert.Contains("\"text\": \"hello\"", written);
        Assert.Contains("\"flag\": true", written);
    }

    [Fact]
    public void EmptyRuns_MinimalJson()
    {
        var json = """{"version":"2.1.0","runs":[]}""";
        var log = SarifReader.Read(json);
        Assert.Empty(log.Runs);

        var written = SarifWriter.WriteToString(log);
        Assert.Contains("\"version\": \"2.1.0\"", written);
        Assert.Contains("\"runs\": []", written);
    }

    [Fact]
    public void EnumValues_AreCamelCase()
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
                            Level = FailureLevel.Warning,
                            Kind = ResultKind.Fail,
                            Message = new Message { Text = "x" }
                        }
                    ]
                }
            ]
        };

        var json = SarifWriter.WriteToString(log);
        Assert.Contains("\"level\": \"warning\"", json);
        Assert.Contains("\"kind\": \"fail\"", json);
    }

    [Fact]
    public void MissingRequiredMember_Throws()
    {
        var json = """
            {
              "version": "2.1.0",
              "runs": [
                {
                  "tool": { "driver": { "name": "tool" } },
                  "results": [ { "ruleId": "RULE001" } ]
                }
              ]
            }
            """;

        Assert.Throws<JsonException>(() => SarifReader.Read(json));
    }

    [Fact]
    public void NullRuns_AreReadAsEmpty()
    {
        var log = SarifReader.Read("""{"version":"2.1.0","runs":null}""");

        Assert.NotNull(log.Runs);
        Assert.Empty(log.Runs);
    }

    [Theory]
    [InlineData(ColumnKind.Utf16CodeUnits, "utf16CodeUnits")]
    [InlineData(ColumnKind.UnicodeCodePoints, "unicodeCodePoints")]
    [InlineData(ResultKind.NotApplicable, "notApplicable")]
    [InlineData(SuppressionKind.InSource, "inSource")]
    [InlineData(SuppressionStatus.UnderReview, "underReview")]
    [InlineData(FailureLevel.None, "none")]
    [InlineData(BaselineState.Unchanged, "unchanged")]
    [InlineData(Importance.Essential, "essential")]
    public void EnumValue_UsesSarifName(object value, string expectedName)
    {
        var json = JsonSerializer.Serialize(value, value.GetType(), SarifJsonContext.Default);

        Assert.Equal($"\"{expectedName}\"", json);
        Assert.Equal(value, JsonSerializer.Deserialize(json, value.GetType(), SarifJsonContext.Default));
    }

    [Fact]
    public void EnumValue_IsReadCaseInsensitively()
    {
        var level = JsonSerializer.Deserialize("\"WARNING\"", SarifJsonContext.Default.FailureLevel);

        Assert.Equal(FailureLevel.Warning, level);
    }

    [Theory]
    [InlineData("\"critical\"")]
    [InlineData("2")]
    public void EnumValue_Unknown_Throws(string json)
    {
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize(json, SarifJsonContext.Default.FailureLevel));
    }

    [Fact]
    public void EnumValue_Undefined_ThrowsOnWrite()
    {
        Assert.Throws<JsonException>(() => JsonSerializer.Serialize((FailureLevel)42, SarifJsonContext.Default.FailureLevel));
    }
}
