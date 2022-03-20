namespace RS.Fritz.Manager.API;

using System.Text.Json.Serialization;

public readonly record struct DeviceMeshChannel(
    [property: JsonPropertyName("channel")] int ChannelNumber);