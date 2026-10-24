using System.Text.Json;
using System.Text.Json.Serialization;
using SarifKit.Models;

namespace SarifKit.Serialization;

/// <summary>
/// Source-generated serialization context for SARIF 2.1.0 types.
/// </summary>
[JsonSourceGenerationOptions(
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    WriteIndented = true)]
[JsonSerializable(typeof(SarifLog))]
[JsonSerializable(typeof(SarifRun))]
[JsonSerializable(typeof(Tool))]
[JsonSerializable(typeof(ToolComponent))]
[JsonSerializable(typeof(Result))]
[JsonSerializable(typeof(ResultKind))]
[JsonSerializable(typeof(FailureLevel))]
[JsonSerializable(typeof(BaselineState))]
[JsonSerializable(typeof(Importance))]
[JsonSerializable(typeof(ColumnKind))]
[JsonSerializable(typeof(Message))]
[JsonSerializable(typeof(Location))]
[JsonSerializable(typeof(PhysicalLocation))]
[JsonSerializable(typeof(ArtifactLocation))]
[JsonSerializable(typeof(Region))]
[JsonSerializable(typeof(LogicalLocation))]
[JsonSerializable(typeof(MultiformatMessageString))]
[JsonSerializable(typeof(ReportingDescriptor))]
[JsonSerializable(typeof(ReportingConfiguration))]
[JsonSerializable(typeof(ReportingDescriptorReference))]
[JsonSerializable(typeof(ReportingDescriptorRelationship))]
[JsonSerializable(typeof(ToolComponentReference))]
[JsonSerializable(typeof(LocationRelationship))]
[JsonSerializable(typeof(Invocation))]
[JsonSerializable(typeof(Notification))]
[JsonSerializable(typeof(ExceptionData))]
[JsonSerializable(typeof(Artifact))]
[JsonSerializable(typeof(ArtifactContent))]
[JsonSerializable(typeof(Fix))]
[JsonSerializable(typeof(ArtifactChange))]
[JsonSerializable(typeof(Replacement))]
[JsonSerializable(typeof(Stack))]
[JsonSerializable(typeof(StackFrame))]
[JsonSerializable(typeof(CodeFlow))]
[JsonSerializable(typeof(ThreadFlow))]
[JsonSerializable(typeof(ThreadFlowLocation))]
[JsonSerializable(typeof(Address))]
[JsonSerializable(typeof(WebRequest))]
[JsonSerializable(typeof(WebResponse))]
[JsonSerializable(typeof(SpecialLocations))]
[JsonSerializable(typeof(Graph))]
[JsonSerializable(typeof(Node))]
[JsonSerializable(typeof(Edge))]
[JsonSerializable(typeof(GraphTraversal))]
[JsonSerializable(typeof(EdgeTraversal))]
[JsonSerializable(typeof(ExternalProperties))]
[JsonSerializable(typeof(ExternalPropertyFileReferences))]
[JsonSerializable(typeof(ExternalPropertyFileReference))]
[JsonSerializable(typeof(ResultProvenance))]
[JsonSerializable(typeof(Suppression))]
[JsonSerializable(typeof(RunAutomationDetails))]
[JsonSerializable(typeof(AutomationDetails))]
[JsonSerializable(typeof(VersionControlDetails))]
[JsonSerializable(typeof(TranslationMetadata))]
[JsonSerializable(typeof(JsonElement))]
[JsonSerializable(typeof(IReadOnlyDictionary<string, JsonElement>))]
[JsonSerializable(typeof(IReadOnlyDictionary<string, string>))]
[JsonSerializable(typeof(IReadOnlyDictionary<string, MultiformatMessageString>))]
internal sealed partial class SarifJsonContext : JsonSerializerContext
{
}
