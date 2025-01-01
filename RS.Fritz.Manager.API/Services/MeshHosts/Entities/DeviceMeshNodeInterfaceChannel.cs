using System.Text.Json.Serialization;

namespace RS.Fritz.Manager.API;

public readonly record struct DeviceMeshNodeInterfaceChannel(
    [property: JsonPropertyName("channel")] int Channel,
    [property: JsonPropertyName("frequency")] int Frequency);