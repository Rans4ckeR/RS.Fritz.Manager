using System.Text.Json.Serialization;

namespace RS.Fritz.Manager.API;

public readonly record struct DeviceMeshNodeInterfaceCurrentChannelInfo(
    [property: JsonPropertyName("primary_freq")] int? PrimaryFreq,
    [property: JsonPropertyName("primary_center")] int? PrimaryCenter,
    [property: JsonPropertyName("channel_width")] string? ChannelWidth,
    [property: JsonPropertyName("puncturing_map")] int? PuncturingMap,
    [property: JsonPropertyName("secondary_center")] int? SecondaryCenter,
    [property: JsonPropertyName("max_power")] int? MaxPower);