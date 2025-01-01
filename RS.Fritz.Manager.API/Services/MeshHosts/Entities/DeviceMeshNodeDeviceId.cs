using System.Text.Json.Serialization;

namespace RS.Fritz.Manager.API;

public readonly record struct DeviceMeshNodeDeviceId(
    [property: JsonPropertyName("subtype")] string Subtype,
    [property: JsonPropertyName("value")] string Value);