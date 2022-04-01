namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:DeviceInfo:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzDeviceInfoService
{
    [OperationContract(Action = "urn:dslforum-org:service:DeviceInfo:1#GetSecurityPort")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<DeviceInfoGetSecurityPortResponse> GetSecurityPortAsync(DeviceInfoGetSecurityPortRequest deviceInfoGetSecurityPortRequest);

    [OperationContract(Action = "urn:dslforum-org:service:DeviceInfo:1#GetInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<DeviceInfoGetInfoResponse> GetInfoAsync(DeviceInfoGetInfoRequest deviceInfoGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:DeviceInfo:1#GetDeviceLog")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<DeviceInfoGetDeviceLogResponse> GetDeviceLogAsync(DeviceInfoGetDeviceLogRequest deviceInfoGetDeviceLogRequest);

    [OperationContract(Action = "urn:dslforum-org:service:DeviceInfo:1#SetProvisioningCode")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<DeviceInfoSetProvisioningCodeResponse> SetProvisioningCodeAsync(DeviceInfoSetProvisioningCodeRequest setProvisioningCodeRequest);
}