using System.Text.Json.Serialization;

namespace RS.Fritz.Manager.API;

public readonly record struct DeviceMeshChannel(
    [property: JsonPropertyName("channel")] int ChannelNumber);