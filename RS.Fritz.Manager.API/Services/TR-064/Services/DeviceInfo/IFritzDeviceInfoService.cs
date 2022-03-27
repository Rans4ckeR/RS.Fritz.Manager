﻿namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:DeviceInfo:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzDeviceInfoService
{
    [OperationContract(Action = "urn:dslforum-org:service:DeviceInfo:1#GetSecurityPort")]
    [FaultContract(typeof(UPnPFault))]
    public Task<DeviceInfoGetSecurityPortResponse> GetSecurityPortAsync(DeviceInfoGetSecurityPortRequest deviceInfoGetSecurityPortRequest);

    [OperationContract(Action = "urn:dslforum-org:service:DeviceInfo:1#GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    public Task<DeviceInfoGetInfoResponse> GetInfoAsync(DeviceInfoGetInfoRequest deviceInfoGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:DeviceInfo:1#GetDeviceLog")]
    [FaultContract(typeof(UPnPFault))]
    public Task<DeviceInfoGetDeviceLogResponse> GetDeviceLogAsync(DeviceInfoGetDeviceLogRequest deviceInfoGetDeviceLogRequest);

    [OperationContract(Action = "urn:dslforum-org:service:DeviceInfo:1#SetProvisioningCode")]
    [FaultContract(typeof(UPnPFault))]
    public Task<DeviceInfoSetProvisioningCodeResponse> SetProvisioningCodeAsync(DeviceInfoSetProvisioningCodeRequest setProvisioningCodeRequest);
}