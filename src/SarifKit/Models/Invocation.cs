using System.Text.Json;
using System.Text.Json.Serialization;

namespace SarifKit.Models;

/// <summary>
/// The runtime environment of the analysis tool run.
/// </summary>
public sealed class Invocation
{
    /// <summary>
    /// The command line used to invoke the tool.
    /// </summary>
    [JsonPropertyName("commandLine")]
    public string? CommandLine { get; init; }

    /// <summary>
    /// An array of strings, containing in order the command line arguments passed to the tool from the operating system.
    /// </summary>
    [JsonPropertyName("arguments")]
    public IReadOnlyList<string>? Arguments { get; init; }

    /// <summary>
    /// The locations of any response files specified on the tool's command line.
    /// </summary>
    [JsonPropertyName("responseFiles")]
    public IReadOnlyList<ArtifactLocation>? ResponseFiles { get; init; }

    /// <summary>
    /// The time at which the invocation started.
    /// </summary>
    [JsonPropertyName("startTimeUtc")]
    public DateTimeOffset? StartTimeUtc { get; init; }

    /// <summary>
    /// The time at which the invocation ended.
    /// </summary>
    [JsonPropertyName("endTimeUtc")]
    public DateTimeOffset? EndTimeUtc { get; init; }

    /// <summary>
    /// The process exit code.
    /// </summary>
    [JsonPropertyName("exitCode")]
    public int? ExitCode { get; init; }

    /// <summary>
    /// An array of configurationOverride objects that describe rules related runtime overrides.
    /// </summary>
    [JsonPropertyName("ruleConfigurationOverrides")]
    public IReadOnlyList<ConfigurationOverride>? RuleConfigurationOverrides { get; init; }

    /// <summary>
    /// An array of configurationOverride objects that describe notifications related runtime overrides.
    /// </summary>
    [JsonPropertyName("notificationConfigurationOverrides")]
    public IReadOnlyList<ConfigurationOverride>? NotificationConfigurationOverrides { get; init; }

    /// <summary>
    /// A list of runtime conditions detected by the tool during the analysis.
    /// </summary>
    [JsonPropertyName("toolExecutionNotifications")]
    public IReadOnlyList<Notification>? ToolExecutionNotifications { get; init; }

    /// <summary>
    /// A list of conditions detected by the tool that are relevant to the tool's configuration.
    /// </summary>
    [JsonPropertyName("toolConfigurationNotifications")]
    public IReadOnlyList<Notification>? ToolConfigurationNotifications { get; init; }

    /// <summary>
    /// The reason for the process exit.
    /// </summary>
    [JsonPropertyName("exitCodeDescription")]
    public string? ExitCodeDescription { get; init; }

    /// <summary>
    /// The name of the signal that caused the process to exit.
    /// </summary>
    [JsonPropertyName("exitSignalName")]
    public string? ExitSignalName { get; init; }

    /// <summary>
    /// The numeric value of the signal that caused the process to exit.
    /// </summary>
    [JsonPropertyName("exitSignalNumber")]
    public int? ExitSignalNumber { get; init; }

    /// <summary>
    /// The reason given by the operating system that the process failed to start.
    /// </summary>
    [JsonPropertyName("processStartFailureMessage")]
    public string? ProcessStartFailureMessage { get; init; }

    /// <summary>
    /// Specifies whether the tool's execution completed successfully.
    /// </summary>
    [JsonPropertyName("executionSuccessful")]
    public required bool ExecutionSuccessful { get; init; }

    /// <summary>
    /// The machine on which the invocation occurred.
    /// </summary>
    [JsonPropertyName("machine")]
    public string? Machine { get; init; }

    /// <summary>
    /// The account under which the invocation occurred.
    /// </summary>
    [JsonPropertyName("account")]
    public string? Account { get; init; }

    /// <summary>
    /// The id of the process in which the invocation occurred.
    /// </summary>
    [JsonPropertyName("processId")]
    public int? ProcessId { get; init; }

    /// <summary>
    /// An absolute URI specifying the location of the executable that was invoked.
    /// </summary>
    [JsonPropertyName("executableLocation")]
    public ArtifactLocation? ExecutableLocation { get; init; }

    /// <summary>
    /// The working directory for the invocation.
    /// </summary>
    [JsonPropertyName("workingDirectory")]
    public ArtifactLocation? WorkingDirectory { get; init; }

    /// <summary>
    /// The environment variables associated with the analysis tool process, expressed as key/value pairs.
    /// </summary>
    [JsonPropertyName("environmentVariables")]
    public IReadOnlyDictionary<string, string>? EnvironmentVariables { get; init; }

    /// <summary>
    /// A file containing the standard input stream to the process that was invoked.
    /// </summary>
    [JsonPropertyName("stdin")]
    public ArtifactLocation? Stdin { get; init; }

    /// <summary>
    /// A file containing the standard output stream from the process that was invoked.
    /// </summary>
    [JsonPropertyName("stdout")]
    public ArtifactLocation? Stdout { get; init; }

    /// <summary>
    /// A file containing the standard error stream from the process that was invoked.
    /// </summary>
    [JsonPropertyName("stderr")]
    public ArtifactLocation? Stderr { get; init; }

    /// <summary>
    /// A file containing the interleaved standard output and standard error stream from the process that was invoked.
    /// </summary>
    [JsonPropertyName("stdoutStderr")]
    public ArtifactLocation? StdoutStderr { get; init; }

    /// <summary>
    /// Key/value pairs that provide additional information about the invocation.
    /// </summary>
    [JsonPropertyName("properties")]
    public IReadOnlyDictionary<string, JsonElement>? Properties { get; init; }
}
