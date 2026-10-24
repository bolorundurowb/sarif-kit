---
name: sarif-kit
description: >-
  Reads and writes SARIF 2.1.0 logs with the SarifKit NuGet package. Use when a
  C# project references SarifKit, or when the task is to read or write .sarif
  files, construct SarifLog, SarifRun, or Result objects, or map analysis
  findings into SARIF.
---

# SarifKit

SarifKit is a zero-dependency, Native-AOT-ready C# library for SARIF 2.1.0. It targets `net8.0`, `net9.0`, and `net10.0`. Add it with `dotnet add package SarifKit`.

Use `SarifKit.IO` and `SarifKit.Models`. Read and write through `SarifReader` and `SarifWriter`. The source-generated serializer is internal, so a `JsonSerializer` call from consuming code does not round-trip these types correctly under trimming or Native AOT.

## Read

```csharp
using SarifKit.IO;
using SarifKit.Models;

using var input = File.OpenRead("scan.sarif");
SarifLog log = SarifReader.Read(input);
```

Also available: `SarifReader.Read(string)`, `SarifReader.Read(ReadOnlySpan<byte>)`, and `SarifReader.ReadAsync(Stream, CancellationToken)`. The reader does not dispose the stream.

`JsonException` means malformed JSON, a missing required member, or an unrecognised enumeration value. `InvalidDataException` means the document was the literal `null`.

## Write

```csharp
using var output = File.Create("output.sarif");
SarifWriter.Write(log, output);                  // indented
SarifWriter.Write(log, output, indented: false); // compact
```

Also available: `WriteToString`, `WriteToUtf8Bytes`, and `WriteAsync`. The writer does not dispose the stream. Null members are omitted. The default `$schema` is `https://json.schemastore.org/sarif-2.1.0.json` and the default `version` is `2.1.0`.

## Build a log

Models are sealed and init-only. Construct them with object initialisers. To change a value, build a new object.

`SarifLog.Runs` and `SarifRun.Tool` are required. `Tool.Driver` and `ToolComponent.Name` are required. Each `Result.Message` is required; set `Message.Text`, or `Message.Id` with `Message.Arguments`. `ReportingDescriptor.Id` is required for a rule.

```csharp
var log = new SarifLog
{
    Runs =
    [
        new SarifRun
        {
            Tool = new Tool
            {
                Driver = new ToolComponent
                {
                    Name = "example",
                    Rules = [new ReportingDescriptor { Id = "EX001" }]
                }
            },
            Results =
            [
                new Result
                {
                    RuleId = "EX001",
                    RuleIndex = 0,
                    Kind = ResultKind.Fail,
                    Level = FailureLevel.Warning,
                    Message = new Message { Text = "Something is wrong." },
                    Locations =
                    [
                        new Location
                        {
                            PhysicalLocation = new PhysicalLocation
                            {
                                ArtifactLocation = new ArtifactLocation { Uri = "src/Program.cs" },
                                Region = new Region { StartLine = 10, StartColumn = 1 }
                            }
                        }
                    ]
                }
            ]
        }
    ]
};
```

`startLine` and `startColumn` follow SARIF and are 1-based. `charOffset` and `byteOffset` are 0-based. The library does not convert between them. `SarifLog.Schema` is the `$schema` member.

## Results that are missing

`SarifRun.Results == null` means the tool did not run properly. An empty list means the tool ran and produced no results. Keep that distinction when reading and when writing.

`"runs": null` is read as an empty `Runs` list. `Runs` itself is never null.

## Property bags

Every object's `properties` member is `IReadOnlyDictionary<string, JsonElement>?`. Read values with the `JsonElement` API (`GetInt32`, `GetString`, `GetBoolean`, `EnumerateArray`, `EnumerateObject`). Clone an element before the document that owns it is disposed.

Build a bag by cloning parsed JSON so the value stays valid and no reflection is required:

```csharp
static JsonElement Element(string json)
{
    using var document = JsonDocument.Parse(json);
    return document.RootElement.Clone();
}

IReadOnlyDictionary<string, JsonElement> properties = new Dictionary<string, JsonElement>
{
    ["number"] = Element("42"),
    ["text"] = Element("\"hello\""),
};
```

Unknown JSON members outside `properties` are ignored on read and are not written back. Put vendor data in `properties` when it has to survive a round trip.

## Enumerations

These enumerations are written as camelCase strings and read without regard to case. SARIF treats them as closed sets, so an unrecognised value throws `JsonException` on read and on write.

| Enumeration | JSON values |
|-------------|-------------|
| `FailureLevel` | `none`, `note`, `warning`, `error` |
| `ResultKind` | `notApplicable`, `pass`, `fail`, `open`, `review`, `informational` |
| `BaselineState` | `new`, `unchanged`, `updated`, `absent` |
| `ColumnKind` | `utf16CodeUnits`, `unicodeCodePoints` |
| `SuppressionKind` | `inSource`, `external` |
| `SuppressionStatus` | `accepted`, `underReview`, `rejected` |
| `Importance` | `important`, `essential`, `unimportant` |

When `columnKind` is absent, SARIF consumers treat columns as UTF-16 code units.

## Required members

These members throw `JsonException` when they are absent on read:

| Type | Required members |
|------|------------------|
| `SarifLog` | `runs` |
| `SarifRun` | `tool` |
| `Tool` | `driver` |
| `ToolComponent` | `name` |
| `Result`, `Notification` | `message` |
| `ReportingDescriptor`, `Node`, `Edge` | `id` (`Edge` also requires `sourceNodeId` and `targetNodeId`) |
| `Invocation` | `executionSuccessful` |
| `Suppression` | `kind` |
| `CodeFlow` | `threadFlows` |
| `ThreadFlow` | `locations` |
| `Stack` | `frames` |
| `Fix` | `artifactChanges` |
| `ArtifactChange` | `artifactLocation`, `replacements` |
| `Replacement` | `deletedRegion` |
| `Attachment` | `artifactLocation` |
| `MultiformatMessageString` | `text` |
| `TranslationMetadata` | `name` |
| `VersionControlDetails` | `repositoryUri` |
| `Conversion` | `tool` |
| `ConfigurationOverride` | `configuration`, `descriptor` |
| `LocationRelationship` | `target` |
| `ReportingDescriptorRelationship` | `target` |
| `EdgeTraversal` | `edgeId` |

For the rest of the object graph, see [references/object-model.md](references/object-model.md).
