using System.Net;

namespace RS.Fritz.Manager.API;

internal sealed class FritzDeviceInfoService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential? networkCredential = null)
    : FritzServiceClient<IFritzDeviceInfoService>(endpointConfiguration, remoteAddress, networkCredential), IFritzDeviceInfoService
{
    public const string ControlUrl = "/upnp/control/deviceinfo";

    public Task<DeviceInfoGetSecurityPortResponse> GetSecurityPortAsync(DeviceInfoGetSecurityPortRequest deviceInfoGetSecurityPortRequest)
        => Channel.GetSecurityPortAsync(deviceInfoGetSecurityPortRequest);

    public Task<DeviceInfoGetInfoResponse> GetInfoAsync(DeviceInfoGetInfoRequest deviceInfoGetInfoRequest)
        => Channel.GetInfoAsync(deviceInfoGetInfoRequest);

    public Task<DeviceInfoGetDeviceLogResponse> GetDeviceLogAsync(DeviceInfoGetDeviceLogRequest deviceInfoGetDeviceLogRequest)
        => Channel.GetDeviceLogAsync(deviceInfoGetDeviceLogRequest);

    public Task<DeviceInfoSetProvisioningCodeResponse> SetProvisioningCodeAsync(DeviceInfoSetProvisioningCodeRequest setProvisioningCodeRequest)
        => Channel.SetProvisioningCodeAsync(setProvisioningCodeRequest);
}