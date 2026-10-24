using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// The runtime environment of the analysis tool run.
/// </summary>
public sealed class Invocation
{
    /// <summary>
    /// A command line string that was used to invoke the analysis tool.
    /// </summary>
    [JsonPropertyName("commandLine")]
    public string? CommandLine { get; init; }

    /// <summary>
    /// An array of strings, containing in order the command line arguments passed to the tool.
    /// </summary>
    [JsonPropertyName("arguments")]
    public IReadOnlyList<string>? Arguments { get; init; }

    /// <summary>
    /// The locations of any response files used.
    /// </summary>
    [JsonPropertyName("responseFiles")]
    public IReadOnlyList<ArtifactLocation>? ResponseFiles { get; init; }

    /// <summary>
    /// The Coordinated Universal Time (UTC) date and time at which the invocation started.
    /// </summary>
    [JsonPropertyName("startTimeUtc")]
    public DateTimeOffset? StartTimeUtc { get; init; }

    /// <summary>
    /// The Coordinated Universal Time (UTC) date and time at which the invocation ended.
    /// </summary>
    [JsonPropertyName("endTimeUtc")]
    public DateTimeOffset? EndTimeUtc { get; init; }

    /// <summary>
    /// The exit code returned from the tool invocation.
    /// </summary>
    [JsonPropertyName("exitCode")]
    public int? ExitCode { get; init; }

    /// <summary>
    /// Specifies whether the tool's execution completed successfully.
    /// </summary>
    [JsonPropertyName("executionSuccessful")]
    public required bool ExecutionSuccessful { get; init; }

    /// <summary>
    /// The reason for the process exit.
    /// </summary>
    [JsonPropertyName("exitCodeDescription")]
    public string? ExitCodeDescription { get; init; }

    /// <summary>
    /// The name of the exit signal.
    /// </summary>
    [JsonPropertyName("exitSignalName")]
    public string? ExitSignalName { get; init; }

    /// <summary>
    /// The numeric value of the exit signal.
    /// </summary>
    [JsonPropertyName("exitSignalNumber")]
    public int? ExitSignalNumber { get; init; }

    /// <summary>
    /// The process id for the analysis tool invocation.
    /// </summary>
    [JsonPropertyName("processId")]
    public int? ProcessId { get; init; }

    /// <summary>
    /// The name of the operating system target of the invocation.
    /// </summary>
    [JsonPropertyName("operatingSystem")]
    public string? OperatingSystem { get; init; }

    /// <summary>
    /// The name of the invoking user.
    /// </summary>
    [JsonPropertyName("account")]
    public string? Account { get; init; }

    /// <summary>
    /// The id of the account used to invoke the analysis tool.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string? AccountId { get; init; }

    /// <summary>
    /// A machine-readable specification for the environment.
    /// </summary>
    [JsonPropertyName("machine")]
    public string? Machine { get; init; }

    /// <summary>
    /// The name of the container.
    /// </summary>
    [JsonPropertyName("workingDirectory")]
    public ArtifactLocation? WorkingDirectory { get; init; }

    /// <summary>
    /// The environment variables associated with the analysis tool process.
    /// </summary>
    [JsonPropertyName("environmentVariables")]
    public IReadOnlyDictionary<string, string>? EnvironmentVariables { get; init; }

    /// <summary>
    /// A description of the runtime environment.
    /// </summary>
    [JsonPropertyName("environmentDescription")]
    public string? EnvironmentDescription { get; init; }

    /// <summary>
    /// The standard input stream of the process.
    /// </summary>
    [JsonPropertyName("stdin")]
    public ArtifactLocation? Stdin { get; init; }

    /// <summary>
    /// The standard output stream of the process.
    /// </summary>
    [JsonPropertyName("stdout")]
    public ArtifactLocation? Stdout { get; init; }

    /// <summary>
    /// The standard error stream of the process.
    /// </summary>
    [JsonPropertyName("stderr")]
    public ArtifactLocation? Stderr { get; init; }

    /// <summary>
    /// The location of the tool's primary log file.
    /// </summary>
    [JsonPropertyName("toolExecutionNotifications")]
    public IReadOnlyList<Notification>? ToolExecutionNotifications { get; init; }

    /// <summary>
    /// A list of runtime conditions detected by the tool during the analysis.
    /// </summary>
    [JsonPropertyName("toolConfigurationNotifications")]
    public IReadOnlyList<Notification>? ToolConfigurationNotifications { get; init; }

    /// <summary>
    /// A list of runtime conditions detected by the tool during the analysis.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
