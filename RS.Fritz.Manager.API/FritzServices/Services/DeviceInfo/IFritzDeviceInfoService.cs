namespace RS.Fritz.Manager.API;

using System.ServiceModel;
using System.Threading.Tasks;

[ServiceContract(Namespace = "urn:dslforum-org:service:DeviceInfo:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzDeviceInfoService
{
    [OperationContract(Action = "urn:dslforum-org:service:DeviceInfo:1#GetSecurityPort")]
    public Task<DeviceInfoGetSecurityPortResponse> GetSecurityPortAsync(DeviceInfoGetSecurityPortRequest deviceInfoGetSecurityPortRequest);

    [OperationContract(Action = "urn:dslforum-org:service:DeviceInfo:1#GetInfo")]
    public Task<DeviceInfoGetInfoResponse> GetInfoAsync(DeviceInfoGetInfoRequest deviceInfoGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:DeviceInfo:1#GetDeviceLog")]
    public Task<DeviceInfoGetDeviceLogResponse> GetDeviceLogAsync(DeviceInfoGetDeviceLogRequest deviceInfoGetDeviceLogRequest);

    [OperationContract(Action = "urn:dslforum-org:service:DeviceInfo:1#SetProvisioningCode")]
    public Task<DeviceInfoSetProvisioningCodeResponse> SetProvisioningCodeAsync(DeviceInfoSetProvisioningCodeRequest setProvisioningCodeRequest);
}