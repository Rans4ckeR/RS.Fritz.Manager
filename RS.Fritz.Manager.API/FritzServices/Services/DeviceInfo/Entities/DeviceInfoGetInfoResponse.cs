namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetInfoResponse")]
public readonly record struct DeviceInfoGetInfoResponse(
    [property: MessageBodyMember(Name = "NewManufacturerName")] string ManufacturerName,
    [property: MessageBodyMember(Name = "NewManufacturerOUI")] string ManufacturerOUI,
    [property: MessageBodyMember(Name = "NewModelName")] string ModelName,
    [property: MessageBodyMember(Name = "NewDescription")] string Description,
    [property: MessageBodyMember(Name = "NewProductClass")] string ProductClass,
    [property: MessageBodyMember(Name = "NewSerialNumber")] string SerialNumber,
    [property: MessageBodyMember(Name = "NewSoftwareVersion")] string SoftwareVersion,
    [property: MessageBodyMember(Name = "NewHardwareVersion")] string HardwareVersion,
    [property: MessageBodyMember(Name = "NewSpecVersion")] string SpecVersion,
    [property: MessageBodyMember(Name = "NewProvisioningCode")] string ProvisioningCode,
    [property: MessageBodyMember(Name = "NewUpTime")] uint Uptime,
    [property: MessageBodyMember(Name = "NewDeviceLog")] string DeviceLog);