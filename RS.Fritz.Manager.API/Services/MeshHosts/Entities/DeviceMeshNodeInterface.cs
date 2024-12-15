using System.Text.Json.Serialization;

namespace RS.Fritz.Manager.API;

public readonly record struct DeviceMeshNodeInterface(
    [property: JsonPropertyName("uid")] string Uid,
    [property: JsonPropertyName("name")] string? Name,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("mac_address")] string MacAddress,
    [property: JsonPropertyName("blocking_state")] string? BlockingState,
    [property: JsonPropertyName("node_links")] DeviceMeshNodeLink[]? NodeLinks,
    [property: JsonPropertyName("ssid")] string? Ssid,
    [property: JsonPropertyName("opmode")] string? Opmode,
    [property: JsonPropertyName("security")] string? Security,
    [property: JsonPropertyName("supported_streams_tx")][property: JsonConverter(typeof(DeviceMeshStreamConfigurationArrayJsonConverter))] DeviceMeshStreamConfiguration[]? SupportedStreamsTx,
    [property: JsonPropertyName("supported_streams_rx")][property: JsonConverter(typeof(DeviceMeshStreamConfigurationArrayJsonConverter))] DeviceMeshStreamConfiguration[]? SupportedStreamsRx,
    [property: JsonPropertyName("current_channel")] int? CurrentChannel,
    [property: JsonPropertyName("phymodes")] string[]? Phymodes,
    [property: JsonPropertyName("channel_utilization")] int? ChannelUtilization,
    [property: JsonPropertyName("anpi")] int? Anpi,
    [property: JsonPropertyName("steering_enabled")] bool? SteeringEnabled,
    [property: JsonPropertyName("_11k_friendly")] bool? Is11KFriendly,
    [property: JsonPropertyName("_11v_friendly")] bool? Is11VFriendly,
    [property: JsonPropertyName("legacy_friendly")] bool? LegacyFriendly,
    [property: JsonPropertyName("rrm_compliant")] bool? RrmCompliant,
    [property: JsonPropertyName("client_position")] string? ClientPosition,
    [property: JsonPropertyName("channel_list")] DeviceMeshChannel[]? Channels);