using System.Text.Json.Serialization;

namespace RS.Fritz.Manager.API;

public readonly record struct DeviceMeshNode(
    [property: JsonPropertyName("uid")] string Uid,
    [property: JsonPropertyName("device_name")] string? DeviceName,
    [property: JsonPropertyName("device_model")] string? DeviceModel,
    [property: JsonPropertyName("device_manufacturer")] string? DeviceManufacturer,
    [property: JsonPropertyName("device_firmware_version")] string? DeviceFirmwareVersion,
    [property: JsonPropertyName("device_mac_address")] string DeviceMacAddress,
    [property: JsonPropertyName("is_meshed")] bool? IsMeshed,
    [property: JsonPropertyName("mesh_role")] string? MeshRole,
    [property: JsonPropertyName("meshd_version")] string? MeshdVersion,
    [property: JsonPropertyName("node_interfaces")] DeviceMeshNodeInterface[]? NodeInterfaces);