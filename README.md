# SarifKit

[![CI](https://github.com/bolorundurowb/sarif-kit/actions/workflows/ci.yml/badge.svg)](https://github.com/bolorundurowb/sarif-kit/actions/workflows/ci.yml) [![codecov](https://codecov.io/gh/bolorundurowb/sarif-kit/graph/badge.svg?token=ypHiwnKOif)](https://codecov.io/gh/bolorundurowb/sarif-kit) [![NuGet](https://img.shields.io/nuget/v/SarifKit.svg?logo=nuget)](https://www.nuget.org/packages/SarifKit/)

SarifKit is a zero-dependency, Native-AOT-ready C# library for reading and writing [SARIF 2.1.0](https://docs.oasis-open.org/sarif/sarif/v2.1.0/) logs. It targets `net8.0`, `net9.0`, and `net10.0`, and serialises with the in-box `System.Text.Json` source generator, so it stays compatible with trimming and Native AOT.

Consuming code uses `SarifKit.IO` and `SarifKit.Models`. Read and write through `SarifReader` and `SarifWriter`. The source-generated serializer is internal. Calling `JsonSerializer` on these types from your own code will not round-trip the model correctly under trimming or Native AOT.

## Install

```bash
dotnet add package SarifKit
```

The package has no NuGet dependencies.

## Read a log

```csharp
using SarifKit.IO;

using var input = File.OpenRead("scan.sarif");
SarifLog log = SarifReader.Read(input);
```

The reader also accepts a JSON string, a UTF-8 `ReadOnlySpan<byte>`, or a stream read asynchronously:

```csharp
SarifLog fromText = SarifReader.Read(json);
SarifLog fromUtf8 = SarifReader.Read(utf8Json);
SarifLog fromStream = await SarifReader.ReadAsync(input, cancellationToken);
```

The reader does not dispose the stream you pass in.

`JsonException` means the JSON is malformed, a required member is missing, or an enumeration value is not one SARIF defines. `InvalidDataException` means the document was the literal `null`.

## Write a log

```csharp
using var output = File.Create("output.sarif");
SarifWriter.Write(log, output);                  // indented
SarifWriter.Write(log, output, indented: false); // compact
```

`WriteToString` and `WriteToUtf8Bytes` serialise into memory. `WriteAsync` writes a stream asynchronously. The writer does not dispose the stream.

Null members are omitted. When `Schema` and `Version` are left at their defaults, the writer emits `$schema` as `https://json.schemastore.org/sarif-2.1.0.json` and `version` as `2.1.0`.

## Build a log

Models are sealed and init-only. Construct them with object initialisers. To change a value, build a new object.

`SarifLog.Runs` and `SarifRun.Tool` are required. `Tool.Driver` and `ToolComponent.Name` are required. Each `Result.Message` is required; set `Message.Text`, or `Message.Id` together with `Message.Arguments`. A rule needs `ReportingDescriptor.Id`.

```csharp
using SarifKit.Models;

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

JSON property names match the SARIF member names. `SarifLog.Schema` is the `$schema` member.

## Results that are missing

`SarifRun.Results == null` means the tool did not run properly. An empty list means the tool ran and produced no results. Keep that distinction when you read a log and when you write one.

`"runs": null`, which SARIF permits when a tool failed to start, is read as an empty `Runs` list. `Runs` itself is never null.

## Property bags

Every object's `properties` member is `IReadOnlyDictionary<string, JsonElement>?`. Read values with the `JsonElement` API (`GetInt32`, `GetString`, `GetBoolean`, `EnumerateArray`, `EnumerateObject`). Clone an element before the document that owns it is disposed.

Build a bag by cloning parsed JSON so the value stays valid:

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

`FailureLevel`, `ResultKind`, `BaselineState`, `ColumnKind`, `SuppressionKind`, `SuppressionStatus`, and `Importance` are written as camelCase strings (`warning`, `utf16CodeUnits`, `inSource`) and read without regard to case. SARIF treats them as closed sets, so an unrecognised value throws `JsonException` on read and on write.

| Enumeration | Values |
|-------------|--------|
| `FailureLevel` | `none`, `note`, `warning`, `error` |
| `ResultKind` | `notApplicable`, `pass`, `fail`, `open`, `review`, `informational` |
| `BaselineState` | `new`, `unchanged`, `updated`, `absent` |
| `ColumnKind` | `utf16CodeUnits`, `unicodeCodePoints` |
| `SuppressionKind` | `inSource`, `external` |
| `SuppressionStatus` | `accepted`, `underReview`, `rejected` |
| `Importance` | `important`, `essential`, `unimportant` |

When `columnKind` is absent, SARIF consumers treat columns as UTF-16 code units.

## Required members

These members are required and throw `JsonException` when they are absent on read:

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

## Agent skill

[`skills/sarif-kit`](skills/sarif-kit) is a skill any coding agent can load. It describes how to read and write SARIF with this library, and the same files are included in the NuGet package under `skills/sarif-kit`.

Copy that folder into the skills directory your agent reads. For agents that share one project skills folder, that path is `.agents/skills/sarif-kit`.

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for how to build, test, and change the library.

## Licence

See [LICENSE](LICENSE).
