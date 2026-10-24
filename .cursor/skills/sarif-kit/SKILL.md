---
name: sarif-kit
description: >-
  Reads and writes SARIF 2.1.0 logs with the SarifKit library. Use when reading
  or writing .sarif files, constructing SarifLog, SarifRun, Result, or location
  objects, mapping analysis findings into SARIF, or changing SarifKit's object
  model, reader, or writer.
---

# Using SarifKit

SarifKit is a zero-dependency, Native-AOT-ready C# library for SARIF 2.1.0. It targets `net8.0`, `net9.0`, and `net10.0`. Consuming code uses only `SarifKit.IO` and `SarifKit.Models`. `SarifKit.Serialization` and `SarifKit.Internal` are internal.

Read and write through `SarifReader` and `SarifWriter`. Do not call `JsonSerializer` on these types from a consumer. The source-generated context is internal, and a reflection serializer will not round-trip the model correctly under trimming or Native AOT.

## Read

```csharp
using SarifKit.IO;

using var input = File.OpenRead("scan.sarif");
SarifLog log = SarifReader.Read(input);
```

Also available: `SarifReader.Read(string)`, `SarifReader.Read(ReadOnlySpan<byte>)`, and `SarifReader.ReadAsync(Stream, CancellationToken)`. The reader does not dispose the stream.

`JsonException` means malformed JSON, a missing required member, or an unrecognised enumeration value. `InvalidDataException` means the document was the literal `null`.

## Write

```csharp
using var output = File.Create("output.sarif");
SarifWriter.Write(log, output);                 // indented
SarifWriter.Write(log, output, indented: false); // compact
```

Also available: `WriteToString`, `WriteToUtf8Bytes`, and `WriteAsync`. The writer does not dispose the stream. Null members are omitted. The default `$schema` and `version` (`2.1.0`) are written when left at their defaults.

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

`startLine` and `startColumn` follow SARIF and are 1-based. `charOffset` and `byteOffset` are 0-based. The library does not convert between them.

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

Unknown JSON members outside `properties` are ignored on read and are not written back. Put vendor data in `properties` if it must survive a round trip.

## Enumerations

`FailureLevel`, `ResultKind`, `BaselineState`, `ColumnKind`, `SuppressionKind`, `SuppressionStatus`, and `Importance` are written as camelCase strings (`warning`, `utf16CodeUnits`, `inSource`) and read without regard to case. SARIF treats them as closed sets, so an unrecognised value throws `JsonException` on read and on write. Do not add a value the specification does not define.

## Required members agents miss

These members are `required` and throw `JsonException` when absent on read:

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
| `MultiformatMessageString`, `TranslationMetadata` | `text` / `name` |
| `VersionControlDetails` | `repositoryUri` |
| `Conversion` | `tool` |
| `ConfigurationOverride` | `configuration`, `descriptor` |
| `LocationRelationship` | `target` |
| `ReportingDescriptorRelationship` | `target` |
| `EdgeTraversal` | `edgeId` |

For the rest of the object graph, see [reference.md](reference.md).

## Extending the library

When adding a SARIF object in this repository:

- Add a sealed model under `src/SarifKit/Models` with init-only properties, `[JsonPropertyName]` set to the SARIF member name, and a `properties` bag of `IReadOnlyDictionary<string, JsonElement>?`.
- Register the type with `[JsonSerializable]` on `SarifJsonContext`.
- Map a closed SARIF enumeration with `[JsonConverter(typeof(SarifStringEnumConverter<T>))]`.
- Add a round-trip test. Do not add a NuGet dependency. Keep the project trimmable and AOT-compatible.
