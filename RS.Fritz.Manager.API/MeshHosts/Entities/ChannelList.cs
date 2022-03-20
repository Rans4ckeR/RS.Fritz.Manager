namespace RS.Fritz.Manager.API;

using System.Text.Json.Serialization;

public readonly record struct ChannelList(
    [property: JsonPropertyName("channel")] int Channel);