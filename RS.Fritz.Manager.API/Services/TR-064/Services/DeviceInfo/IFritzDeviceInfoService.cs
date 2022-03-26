namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:DeviceInfo:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzDeviceInfoService
{
    [OperationContract(Action = "urn:dslforum-org:service:DeviceInfo:1#GetSecurityPort")]
    [FaultContract(typeof(FritzFaultContract), Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
    [XmlSerializerFormat(SupportFaults = true)]
    public Task<DeviceInfoGetSecurityPortResponse> GetSecurityPortAsync(DeviceInfoGetSecurityPortRequest deviceInfoGetSecurityPortRequest);

    [OperationContract(Action = "urn:dslforum-org:service:DeviceInfo:1#GetInfo")]
    [FaultContract(typeof(FritzFaultContract), Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
    [XmlSerializerFormat(SupportFaults = true)]
    public Task<DeviceInfoGetInfoResponse> GetInfoAsync(DeviceInfoGetInfoRequest deviceInfoGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:DeviceInfo:1#GetDeviceLog")]
    [FaultContract(typeof(FritzFaultContract), Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
    [XmlSerializerFormat(SupportFaults = true)]
    public Task<DeviceInfoGetDeviceLogResponse> GetDeviceLogAsync(DeviceInfoGetDeviceLogRequest deviceInfoGetDeviceLogRequest);

    [OperationContract(Action = "urn:dslforum-org:service:DeviceInfo:1#SetProvisioningCode")]
    [FaultContract(typeof(FritzFaultContract), Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
    [XmlSerializerFormat(SupportFaults = true)]
    public Task<DeviceInfoSetProvisioningCodeResponse> SetProvisioningCodeAsync(DeviceInfoSetProvisioningCodeRequest setProvisioningCodeRequest);
}