using System.Text.Json.Serialization;

namespace RS.Fritz.Manager.API;

public readonly record struct DeviceMeshNode(
    [property: JsonPropertyName("uid")] string Uid,
    [property: JsonPropertyName("device_friendly_name")] string? DeviceFriendlyName,
    [property: JsonPropertyName("device_name")] string? DeviceName,
    [property: JsonPropertyName("device_vendor_class_id")] string? DeviceVendorClassId,
    [property: JsonPropertyName("device_model")] string? DeviceModel,
    [property: JsonPropertyName("device_manufacturer")] string? DeviceManufacturer,
    [property: JsonPropertyName("device_firmware_version")] string? DeviceFirmwareVersion,
    [property: JsonPropertyName("device_mac_address")] string DeviceMacAddress,
    [property: JsonPropertyName("device_id")] DeviceMeshNodeDeviceId? DeviceId,
    [property: JsonPropertyName("device_capabilities")] string[]? DeviceCapabilities,
    [property: JsonPropertyName("enabled_device_capabilities")] string[]? EnabledDeviceCapabilities,
    [property: JsonPropertyName("is_meshed")] bool? IsMeshed,
    [property: JsonPropertyName("mesh_role")] string? MeshRole,
    [property: JsonPropertyName("meshd_version")] string? MeshdVersion,
    [property: JsonPropertyName("metrics")] DeviceMeshNodeMetrics? DeviceMeshNodeMetrics,
    [property: JsonPropertyName("node_interfaces")] DeviceMeshNodeInterface[]? NodeInterfaces);