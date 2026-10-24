# SarifKit object model

Types live in `SarifKit.Models`. JSON names match SARIF 2.1.0. Properties are init-only. A null reference-type property is omitted on write.

## Log and run

- `SarifLog`: `schema` (`$schema`), `version`, `runs`, `inlineExternalProperties`, `properties`.
- `SarifRun`: `tool`, `invocations`, `conversion`, `language`, `versionControlProvenance`, `originalUriBaseIds`, `artifacts`, `logicalLocations`, `graphs`, `results`, `automationDetails`, `runAggregations`, `baselineGuid`, `redactionTokens`, `defaultEncoding`, `defaultSourceLanguage`, `newlineSequences`, `columnKind`, `externalPropertyFileReferences`, `threadFlowLocations`, `taxonomies`, `addresses`, `translations`, `policies`, `webRequests`, `webResponses`, `specialLocations`, `properties`.

`columnKind` is `utf16CodeUnits` or `unicodeCodePoints`. When it is absent, SARIF consumers treat columns as UTF-16 code units.

## Tool and rules

- `Tool`: `driver`, `extensions`.
- `ToolComponent`: `name`, plus identity and version fields, `rules`, `notifications`, `taxa`, `contents`, `supportedTaxonomies`.
- `ReportingDescriptor`: `id`, descriptions, `defaultConfiguration`, `help`, `helpUri`, `relationships`.
- `ReportingConfiguration`: `enabled`, `level`, `rank`, `parameters`.
- `MultiformatMessageString`: `text` and optional `markdown`.
- `Invocation`: `executionSuccessful`, `commandLine`, `arguments`, `startTimeUtc`, `endTimeUtc`, `exitCode`, `toolExecutionNotifications`, `ruleConfigurationOverrides`, `notificationConfigurationOverrides`.

A result's `ruleId` is the descriptor `id`. `ruleIndex` is the index of that descriptor in `tool.driver.rules`. Set both when the rule list is present.

## Result

- `Result`: `ruleId`, `ruleIndex`, `rule`, `kind`, `level`, `message`, `locations`, `relatedLocations`, fingerprints, `codeFlows`, `stacks`, `graphs`, `graphTraversals`, `fixes`, `suppressions`, `baselineState`, `rank`, `taxa`, `webRequest`, `webResponse`, `provenance`, `properties`.
- `kind`: `notApplicable`, `pass`, `fail`, `open`, `review`, `informational`.
- `level`: `none`, `note`, `warning`, `error`.
- `baselineState`: `new`, `unchanged`, `updated`, `absent`.
- `Suppression`: required `kind` (`inSource`, `external`), optional `status` (`accepted`, `underReview`, `rejected`), `justification`, `location`.

## Location

- `Location`: `id`, `physicalLocation`, `logicalLocations`, `message`, `annotations`, `relationships`.
- `PhysicalLocation`: `artifactLocation`, `region`, `contextRegion`, `address`.
- `ArtifactLocation`: `uri`, `uriBaseId`, `index`. Resolve `uriBaseId` through `SarifRun.OriginalUriBaseIds`. Resolve `index` through `SarifRun.Artifacts`.
- `Region`: `startLine`, `startColumn`, `endLine`, `endColumn`, `charOffset`, `charLength`, `byteOffset`, `byteLength`, `snippet`. Lines and columns are 1-based. Offsets are 0-based.
- `LogicalLocation`: `name`, `index`, `fullyQualifiedName`, `kind`, `decoratedName`, `parentIndex`.

## Flows, graphs, and fixes

- `CodeFlow` contains `threadFlows`. Each `ThreadFlow` contains `locations` of `ThreadFlowLocation`.
- `Stack` contains `frames` of `StackFrame`.
- `Graph` contains `nodes` and `edges`. `Node` and `Edge` require `id`. `Edge` also requires `sourceNodeId` and `targetNodeId`.
- `GraphTraversal` walks a graph through `EdgeTraversal` (`edgeId`).
- `Fix` contains `artifactChanges`. Each `ArtifactChange` names an `artifactLocation` and a list of `replacements`. Each `Replacement` requires `deletedRegion` and may include `insertedContent`.
