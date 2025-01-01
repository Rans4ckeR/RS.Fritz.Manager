using System.Text.Json.Serialization;

namespace RS.Fritz.Manager.API;

public readonly record struct DeviceMeshNodeMetricsWanCounters(
    [property: JsonPropertyName("last_update")] long LastUpdate,
    [property: JsonPropertyName("bytes")] DeviceMeshNodeMetricsWanCountersBytes? Bytes);