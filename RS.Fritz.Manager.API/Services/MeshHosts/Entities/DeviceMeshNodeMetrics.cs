using System.Text.Json.Serialization;

namespace RS.Fritz.Manager.API;

public readonly record struct DeviceMeshNodeMetrics(
    [property: JsonPropertyName("wan_counters")] DeviceMeshNodeMetricsWanCounters? WanCounters);