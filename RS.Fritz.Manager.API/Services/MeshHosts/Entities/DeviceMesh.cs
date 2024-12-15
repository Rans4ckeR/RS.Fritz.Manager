using System.Text.Json.Serialization;

namespace RS.Fritz.Manager.API;

public readonly record struct DeviceMesh(
    [property: JsonPropertyName("schema_version")] string SchemaVersion,
    [property: JsonPropertyName("nodes")] DeviceMeshNode[] Nodes);