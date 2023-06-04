namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzDeviceInfoService : FritzServiceClient<IFritzDeviceInfoService>, IFritzDeviceInfoService
{
    public const string ControlUrl = "/upnp/control/deviceinfo";

    public FritzDeviceInfoService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential? networkCredential = null)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<DeviceInfoGetSecurityPortResponse> GetSecurityPortAsync(DeviceInfoGetSecurityPortRequest deviceInfoGetSecurityPortRequest)
        => Channel.GetSecurityPortAsync(deviceInfoGetSecurityPortRequest);

    public Task<DeviceInfoGetInfoResponse> GetInfoAsync(DeviceInfoGetInfoRequest deviceInfoGetInfoRequest)
        => Channel.GetInfoAsync(deviceInfoGetInfoRequest);

    public Task<DeviceInfoGetDeviceLogResponse> GetDeviceLogAsync(DeviceInfoGetDeviceLogRequest deviceInfoGetDeviceLogRequest)
        => Channel.GetDeviceLogAsync(deviceInfoGetDeviceLogRequest);

    public Task<DeviceInfoSetProvisioningCodeResponse> SetProvisioningCodeAsync(DeviceInfoSetProvisioningCodeRequest setProvisioningCodeRequest)
        => Channel.SetProvisioningCodeAsync(setProvisioningCodeRequest);
}