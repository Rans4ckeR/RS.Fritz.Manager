namespace RS.Fritz.Manager.API;

using System.Text.Json.Serialization;

public readonly record struct DeviceMesh(
    [property: JsonPropertyName("schema_version")] string SchemaVersion,
    [property: JsonPropertyName("nodes")] Node[] Nodes);