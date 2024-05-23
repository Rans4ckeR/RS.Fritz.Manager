namespace RS.Fritz.Manager.API;

using System.ServiceModel.Channels;

internal sealed class FritzDeviceInfoService(Binding binding, EndpointAddress remoteAddress)
    : ClientBase<IFritzDeviceInfoService>(binding, remoteAddress), IFritzDeviceInfoService
{
    public Task<DeviceInfoGetSecurityPortResponse> GetSecurityPortAsync(DeviceInfoGetSecurityPortRequest deviceInfoGetSecurityPortRequest)
        => Channel.GetSecurityPortAsync(deviceInfoGetSecurityPortRequest);

    public Task<DeviceInfoGetInfoResponse> GetInfoAsync(DeviceInfoGetInfoRequest deviceInfoGetInfoRequest)
        => Channel.GetInfoAsync(deviceInfoGetInfoRequest);

    public Task<DeviceInfoGetDeviceLogResponse> GetDeviceLogAsync(DeviceInfoGetDeviceLogRequest deviceInfoGetDeviceLogRequest)
        => Channel.GetDeviceLogAsync(deviceInfoGetDeviceLogRequest);

    public Task<DeviceInfoSetProvisioningCodeResponse> SetProvisioningCodeAsync(DeviceInfoSetProvisioningCodeRequest setProvisioningCodeRequest)
        => Channel.SetProvisioningCodeAsync(setProvisioningCodeRequest);
}