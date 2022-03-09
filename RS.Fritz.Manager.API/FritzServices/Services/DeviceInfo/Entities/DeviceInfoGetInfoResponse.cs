namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetInfoResponse")]
public sealed record DeviceInfoGetInfoResponse
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessageBodyMember(Name = "NewManufacturerName")]
    public string ManufacturerName { get; set; }

    [MessageBodyMember(Name = "NewManufacturerOUI")]
    public string ManufacturerOUI { get; set; }

    [MessageBodyMember(Name = "NewModelName")]
    public string ModelName { get; set; }

    [MessageBodyMember(Name = "NewDescription")]
    public string Description { get; set; }

    [MessageBodyMember(Name = "NewProductClass")]
    public string ProductClass { get; set; }

    [MessageBodyMember(Name = "NewSerialNumber")]
    public string SerialNumber { get; set; }

    [MessageBodyMember(Name = "NewSoftwareVersion")]
    public string SoftwareVersion { get; set; }

    [MessageBodyMember(Name = "NewHardwareVersion")]
    public string HardwareVersion { get; set; }

    [MessageBodyMember(Name = "NewSpecVersion")]
    public string SpecVersion { get; set; }

    [MessageBodyMember(Name = "NewProvisioningCode")]
    public string ProvisioningCode { get; set; }

    [MessageBodyMember(Name = "NewUpTime")]
    public uint UpTime { get; set; }

    [MessageBodyMember(Name = "NewDeviceLog")]
    public string DeviceLog { get; set; }
}