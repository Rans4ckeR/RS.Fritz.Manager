using System.Text.Json.Serialization;

namespace RS.Fritz.Manager.API;

public readonly record struct DeviceMeshNodeMetricsWanCountersBytes(
    [property: JsonPropertyName("rx")] long Received,
    [property: JsonPropertyName("tx")] long Sent);