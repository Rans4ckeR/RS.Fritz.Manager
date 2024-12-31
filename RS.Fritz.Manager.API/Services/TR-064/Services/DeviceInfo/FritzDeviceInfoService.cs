using System.Net;
using Microsoft.Extensions.Logging;

namespace RS.Fritz.Manager.API;

internal sealed class FritzDeviceInfoService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential? networkCredential, ILoggerFactory loggerFactory)
    : FritzServiceClient<IFritzDeviceInfoService>(endpointConfiguration, remoteAddress, networkCredential, loggerFactory), IFritzDeviceInfoService
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