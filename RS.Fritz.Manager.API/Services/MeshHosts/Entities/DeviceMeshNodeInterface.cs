﻿using System.Text.Json.Serialization;

namespace RS.Fritz.Manager.API;

public readonly record struct DeviceMeshNodeInterface(
    [property: JsonPropertyName("uid")] string Uid,
    [property: JsonPropertyName("name")] string? Name,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("mac_address")] string MacAddress,
    [property: JsonPropertyName("node_uid")] string? NodeUid,
    [property: JsonPropertyName("blocking_state")] string? BlockingState,
    [property: JsonPropertyName("node_links")] DeviceMeshNodeInterfaceNodeLink[]? NodeLinks,
    [property: JsonPropertyName("link_detected")] bool? LinkDetected,
    [property: JsonPropertyName("cur_data_rate")] int? CurrentDataRate,
    [property: JsonPropertyName("cur_availability_rx")] int? CurrentReceiveAvailability,
    [property: JsonPropertyName("cur_availability_tx")] int? CurrentSendAvailability,
    [property: JsonPropertyName("lldp_active")] bool? LldpActive,
    [property: JsonPropertyName("mld_mac_address")] string? MldMacAddress,
    [property: JsonPropertyName("link_id")] int? LinkId,
    [property: JsonPropertyName("ul_ttlm")] string? UplinkTtlm,
    [property: JsonPropertyName("dl_ttlm")] string? DownlinkTtlm,
    [property: JsonPropertyName("ssid")] string? Ssid,
    [property: JsonPropertyName("opmode")] string? Opmode,
    [property: JsonPropertyName("security")] string? Security,
    [property: JsonPropertyName("supported_streams_tx")][property: JsonConverter(typeof(DeviceMeshStreamConfigurationArrayJsonConverter))] DeviceMeshStreamConfiguration[]? SupportedStreamsTx,
    [property: JsonPropertyName("supported_streams_rx")][property: JsonConverter(typeof(DeviceMeshStreamConfigurationArrayJsonConverter))] DeviceMeshStreamConfiguration[]? SupportedStreamsRx,
    [property: JsonPropertyName("current_channel")] int? CurrentChannel,
    [property: JsonPropertyName("current_channel_info")] DeviceMeshNodeInterfaceCurrentChannelInfo? CurrentChannelInfo,
    [property: JsonPropertyName("radio_id")] int[]? RadioId,
    [property: JsonPropertyName("channel_utilization")] int? ChannelUtilization,
    [property: JsonPropertyName("anpi")] int? Anpi,
    [property: JsonPropertyName("steering_enabled")] bool? SteeringEnabled,
    [property: JsonPropertyName("11k_friendly")] bool? Is11KFriendly,
    [property: JsonPropertyName("11v_friendly")] bool? Is11VFriendly,
    [property: JsonPropertyName("legacy_friendly")] bool? LegacyFriendly,
    [property: JsonPropertyName("rrm_compliant")] bool? RrmCompliant,
    [property: JsonPropertyName("mlo_modes")] string[]? MloModes,
    [property: JsonPropertyName("phymodes")] string[]? Phymodes,
    [property: JsonPropertyName("client_position")] string? ClientPosition,
    [property: JsonPropertyName("channel_list")] DeviceMeshNodeInterfaceChannel[]? Channels);