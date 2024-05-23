namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = $"{UPnPConstants.AvmServiceNamespace}:DeviceInfo:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzDeviceInfoService : IFritzService
{
    static string IFritzService.ControlUrl => "/upnp/control/deviceinfo";

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:DeviceInfo:1#GetSecurityPort")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<DeviceInfoGetSecurityPortResponse> GetSecurityPortAsync(DeviceInfoGetSecurityPortRequest deviceInfoGetSecurityPortRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:DeviceInfo:1#GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<DeviceInfoGetInfoResponse> GetInfoAsync(DeviceInfoGetInfoRequest deviceInfoGetInfoRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:DeviceInfo:1#GetDeviceLog")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<DeviceInfoGetDeviceLogResponse> GetDeviceLogAsync(DeviceInfoGetDeviceLogRequest deviceInfoGetDeviceLogRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:DeviceInfo:1#SetProvisioningCode")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<DeviceInfoSetProvisioningCodeResponse> SetProvisioningCodeAsync(DeviceInfoSetProvisioningCodeRequest setProvisioningCodeRequest);
}