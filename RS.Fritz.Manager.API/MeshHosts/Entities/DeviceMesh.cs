namespace RS.Fritz.Manager.API;

using System.Text.Json.Serialization;

// https://avm.de/fileadmin/user_upload/Global/Service/Schnittstellen/mesh_topology/mesh_topology_schema_v1.9.json
public readonly record struct DeviceMesh(
    [property: JsonPropertyName("schema_version")] string SchemaVersion,
    [property: JsonPropertyName("nodes")] Node[] Nodes);

public readonly record struct Node(
    [property: JsonPropertyName("uid")] string Uid,
    [property: JsonPropertyName("device_name")] string DeviceName,
    [property: JsonPropertyName("device_model")] string DeviceModel,
    [property: JsonPropertyName("device_manufacturer")] string DeviceManufacturer,
    [property: JsonPropertyName("device_firmware_version")] string DeviceFirmwareVersion,
    [property: JsonPropertyName("device_mac_address")] string DeviceMacAddress,
    [property: JsonPropertyName("is_meshed")] bool IsMeshed,
    [property: JsonPropertyName("mesh_role")] string MeshRole,
    [property: JsonPropertyName("meshd_version")] string MeshdVersion,
    [property: JsonPropertyName("node_interfaces")] NodeInterfaces[] NodeInterfaces);

public readonly record struct NodeInterfaces(
    [property: JsonPropertyName("uid")] string Uid,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("mac_address")] string MacAddress,
    [property: JsonPropertyName("blocking_state")] string BlockingState,
    [property: JsonPropertyName("node_links")] NodeLinks[] NodeLinks,
    [property: JsonPropertyName("ssid")] string Ssid,
    [property: JsonPropertyName("opmode")] string Opmode,
    [property: JsonPropertyName("security")] string Security,
    [property: JsonPropertyName("supported_streams_tx")] object[][] SupportedStreamsTx,
    [property: JsonPropertyName("supported_streams_rx")] object[][] SupportedStreamsRx,
    [property: JsonPropertyName("current_channel")] int CurrentChannel,
    [property: JsonPropertyName("phymodes")] string[] Phymodes,
    [property: JsonPropertyName("channel_utilization")] int ChannelUtilization,
    [property: JsonPropertyName("anpi")] int Anpi,
    [property: JsonPropertyName("steering_enabled")] bool SteeringEnabled,
    [property: JsonPropertyName("_11k_friendly")] bool Is11kFriendly,
    [property: JsonPropertyName("_11v_friendly")] bool Is11vFriendly,
    [property: JsonPropertyName("legacy_friendly")] bool LegacyFriendly,
    [property: JsonPropertyName("rrm_compliant")] bool RrmCompliant,
    [property: JsonPropertyName("channel_list")] ChannelList[] ChannelList);

public readonly record struct NodeLinks(
    [property: JsonPropertyName("uid")] string Uid,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("state")] string State,
    [property: JsonPropertyName("last_connected")] int LastConnected,
    [property: JsonPropertyName("node_1_uid")] string Node1Uid,
    [property: JsonPropertyName("node_2_uid")] string Node2Uid,
    [property: JsonPropertyName("node_interface_1_uid")] string NodeInterface1Uid,
    [property: JsonPropertyName("node_interface_2_uid")] string NodeInterface2Uid,
    [property: JsonPropertyName("max_data_rate_rx")] int MaxDataRateRx,
    [property: JsonPropertyName("max_data_rate_tx")] int MaxDataRateTx,
    [property: JsonPropertyName("cur_data_rate_rx")] int CurDataRateRx,
    [property: JsonPropertyName("cur_data_rate_tx")] int CurDataRateTx,
    [property: JsonPropertyName("cur_availability_rx")] int CurAvailabilityRx,
    [property: JsonPropertyName("cur_availability_tx")] int CurAvailabilityTx,
    [property: JsonPropertyName("rx_rsni")] int RxRsni,
    [property: JsonPropertyName("tx_rsni")] int TxRsni,
    [property: JsonPropertyName("rx_rcpi")] int RxRcpi,
    [property: JsonPropertyName("tx_rcpi")] int TxRcpi);

public readonly record struct ChannelList(
    [property: JsonPropertyName("channel")] int Channel);