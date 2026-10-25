# Contributing to SarifKit

This guide is for people changing the library. If you want to read or write SARIF logs from your own project, start with the [README](README.md).

## Prerequisites

Install the .NET 8, .NET 9, and .NET 10 SDKs. The library and the test project target all three. There is no `global.json`; any current SDK that can build those target frameworks is enough.

The solution file is `SarifKit.slnx`.

## Repository layout

| Path | What it contains |
|------|------------------|
| `src/SarifKit` | The library. The public surface is `SarifKit.IO` and `SarifKit.Models`. `SarifKit.Serialization` and `SarifKit.Internal` are internal. |
| `tests/SarifKit.Tests` | xUnit tests, multi-targeted to the same frameworks as the library. |
| `tests/SarifKit.Benchmarks` | BenchmarkDotNet project that compares SarifKit with `Sarif.Sdk`. |
| `samples/SarifKit.Sample` | A `net9.0` console app published with Native AOT. |
| `.github/workflows/ci.yml` | Build, test, pack, and the Native AOT smoke test. |

`Directory.Build.props` enables nullable reference types, the latest C# language version, and warnings as errors for every project.

## Build

```bash
dotnet build -c Release
```

The library enables the trim and Native AOT analysers (`IsAotCompatible`, `EnableTrimAnalyzer`, `EnableAotAnalyzer`). A change that introduces reflection, an unannotated public API, or a trimming warning fails the build.

Building `src/SarifKit` also produces a NuGet package, because `GeneratePackageOnBuild` is set.

## Test

```bash
dotnet test -c Release
```

Tests live in `tests/SarifKit.Tests` and cover round trips and edge cases. `TestData` holds sample SARIF files that are copied to the test output.

`RoundTrip_LargeLog_UnderTwoSeconds` has the trait `Category=Performance`. It builds a log of 50,000 results and asserts that a round trip finishes within two seconds. Skip it on a shared or busy machine with:

```bash
dotnet test -c Release --filter "Category!=Performance"
```

Continuous integration runs the full suite, including that test, on Ubuntu, Windows, and macOS.

## Native AOT sample

`samples/SarifKit.Sample` reads a SARIF file and writes it back out. Publish it for the operating system you are on. Native AOT does not cross-compile.

```bash
dotnet publish samples/SarifKit.Sample -c Release -r win-x64
```

On Linux, including WSL or CI, use `-r linux-x64`. The CI smoke test publishes `linux-x64` and runs the native binary against `samples/SarifKit.Sample/sample.sarif`.

## Benchmarks

```bash
dotnet run -c Release --project tests/SarifKit.Benchmarks
```

The benchmark compares SarifKit with `Sarif.Sdk` on a synthetic log of more than 10 MB. Both libraries read from the same in-memory stream, and each write benchmark measures only serialisation. `Sarif.Sdk` is a benchmark dependency only. Do not reference it from `src/SarifKit`.

## Package

```bash
dotnet pack src/SarifKit -c Release -p:GeneratePackageOnBuild=false
```

`GeneratePackageOnBuild` is set so a normal build also produces a package. `dotnet pack` skips its own build while that property is true, so a clean pack fails with NU5026. Pass `-p:GeneratePackageOnBuild=false` so pack builds every target framework and then creates the package.

The resulting `SarifKit` package has no NuGet dependencies. The repository README is packed as the package readme, so keep that file aimed at people who consume the library.

CI packs on every pull request. A push of a `v*` tag creates a GitHub release and attaches the package.

## Design constraints

Keep these properties of the library intact:

- `src/SarifKit` has no NuGet dependencies. Use the BCL.
- Serialisation goes through the source-generated `SarifJsonContext`. Do not add a reflection-based serializer, and do not make that context public.
- Models are sealed classes with init-only properties. A null reference-type property is omitted on write.
- JSON names match SARIF 2.1.0. Set `[JsonPropertyName]` to the SARIF member name, including names that differ from the C# property (`$schema` on `SarifLog.Schema`).
- Every object has a `properties` bag of `IReadOnlyDictionary<string, JsonElement>?`. That is how vendor data survives a round trip without runtime type information.
- Closed SARIF enumerations use `[JsonConverter(typeof(SarifStringEnumConverter<T>))]`. An unrecognised value throws `JsonException`. Do not add a value the specification does not define.
- `SarifLog.Runs` is never null. `"runs": null` is read as an empty list. `SarifRun.Results == null` still means the tool did not run properly, and an empty list means the tool ran and found nothing.
- Public API names follow existing US English identifiers (`SarifReader`, `WriteToUtf8Bytes`). Match the surrounding code when you add a member.
- Tests and benchmarks see internals through `InternalsVisibleTo` in `SarifKit.csproj`. A new test assembly needs the same attribute before it can reach internal types.

## Adding a SARIF object

1. Add a sealed model under `src/SarifKit/Models` with init-only properties, `[JsonPropertyName]` set to the SARIF member name, and a `properties` bag.
2. Mark members that the SARIF schema requires with `required`, following the existing models.
3. Register the type with `[JsonSerializable]` on `SarifJsonContext`.
4. Map a closed enumeration with `[JsonConverter(typeof(SarifStringEnumConverter<T>))]` and register that enum on the context as well.
5. Add a round-trip test in `tests/SarifKit.Tests` that reads the object back and compares it with what was written. Extend `TestData` when a fixture file is clearer than an object initialiser.

`SarifReader` and `SarifWriter` should stay thin wrappers over `JsonSerializer` and `SarifJsonContext`. Stream methods must not dispose the caller's stream.

## Pull requests

Open a pull request against `master`. CI builds in Release with the AOT and trim analysers, runs the tests, packs the library, and publishes the sample with Native AOT on Linux.

Keep a pull request focused on one change. Describe what changed and why, and say which commands you ran. A new object, enum, or behaviour change needs a test that would fail without it.
