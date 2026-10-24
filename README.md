# SarifKit

A zero-dependency, Native-AOT-ready C# library for reading and writing [SARIF 2.1.0](https://docs.oasis-open.org/sarif/sarif/v2.1.0/) logs using `System.Text.Json` source generation.

## Quick start

```csharp
using SarifKit.IO;
using SarifKit.Models;

// Read
SarifLog log;
using (var input = File.OpenRead("scan.sarif"))
{
    log = SarifReader.Read(input);
}

Console.WriteLine(log.Runs[0].Results?.Count ?? 0);

// Write
using (var output = File.Create("output.sarif"))
{
    SarifWriter.Write(log, output);
}
```

`SarifReader.ReadAsync` and `SarifWriter.WriteAsync` stream asynchronously. `SarifWriter.WriteToString` and `SarifWriter.WriteToUtf8Bytes` serialize into memory.

## Features

- **Zero dependencies** — only the in-box `System.Text.Json` is used.
- **Native AOT / trimming compatible** — source-generated serializers, no reflection.
- **High performance** — pooled buffers and UTF-8 streaming.
- **Full SARIF 2.1.0 object model** — runs, results, locations, code flows, graphs, stacks, and more.

## Behaviour to be aware of

- **Property bags** (`properties` on every object) are exposed as `IReadOnlyDictionary<string, JsonElement>`. Use the `JsonElement` API to read values, for example `run.Properties!["count"].GetInt32()`. This keeps arbitrary JSON intact without needing runtime type information, which Native AOT does not allow.
- **Enumerations** such as `level`, `kind` and `baselineState` are written as camelCase strings and read case-insensitively. SARIF defines these as closed sets, so an unrecognised value causes a `JsonException`.
- **Required members** defined by the SARIF schema, such as `result.message` and `tool.driver`, must be present. If one is missing, reading throws a `JsonException`.
- **Unknown members** are ignored on read and are not written back.
- **`"runs": null`**, which SARIF permits when a tool failed to start, is read as an empty `Runs` list.
- **Null members** are omitted on write.

## Build

```bash
dotnet build -c Release
```

## Test

```bash
dotnet test -c Release
```

The wall-clock performance test has the trait `Category=Performance`. Exclude it on shared CI agents with `--filter "Category!=Performance"`.

## Sample (Native AOT)

```bash
cd samples/SarifKit.Sample
dotnet publish -c Release -r win-x64
```

Native AOT cannot cross-compile between operating systems. Publish for `linux-x64` on Linux, for example under WSL or in CI.

## Benchmarks

```bash
dotnet run -c Release --project tests/SarifKit.Benchmarks
```

This compares SarifKit with `Sarif.Sdk` on a synthetic log of more than 10 MB. Both libraries read from the same in-memory stream, and each write benchmark measures only serialization.

## Package

```bash
dotnet pack src/SarifKit -c Release
```

The resulting `SarifKit` package has no NuGet dependencies.
