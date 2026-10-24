# SarifKit

A zero-dependency, Native-AOT-ready C# library for reading and writing [SARIF 2.1.0](https://docs.oasis-open.org/sarif/sarif/v2.1.0/) logs using `System.Text.Json` source generation.

## Quick start

```csharp
using SarifKit.IO;

// Read
var log = SarifReader.Read(File.OpenRead("scan.sarif"));
Console.WriteLine(log.Runs[0].Results?.Count ?? 0);

// Write
SarifWriter.Write(log, File.Create("output.sarif"));
```

## Features

- **Zero dependencies** — only the in-box `System.Text.Json` is used.
- **Native AOT / trimming compatible** — source-generated serializers, no reflection.
- **High performance** — pooled buffers and UTF-8 streaming.
- **Full SARIF 2.1.0 object model** — runs, results, locations, code flows, graphs, stacks, and more.

## Build

```bash
dotnet build -c Release
```

## Test

```bash
dotnet test -c Release
```

## Sample (Native AOT)

```bash
cd samples/SarifKit.Sample
dotnet publish -c Release -r win-x64 --self-contained
```

## Package

```bash
dotnet pack src/SarifKit -c Release
```

The resulting `SarifKit.0.1.0.nupkg` has no direct NuGet dependencies.
