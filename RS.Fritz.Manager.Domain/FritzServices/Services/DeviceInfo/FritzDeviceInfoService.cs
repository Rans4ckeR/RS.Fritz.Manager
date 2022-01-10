namespace RS.Fritz.Manager.Domain
{
    using System.Net;
    using System.ServiceModel;
    using System.Threading.Tasks;

    public sealed class FritzDeviceInfoService : FritzServiceClient<IFritzDeviceInfoService>, IFritzDeviceInfoService
    {
        public const string ControlUrl = "/upnp/control/deviceinfo";

        public FritzDeviceInfoService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential? networkCredential = null)
            : base(endpointConfiguration, remoteAddress, networkCredential)
        {
        }

        public Task<DeviceInfoGetSecurityPortResponse> GetSecurityPortAsync(DeviceInfoGetSecurityPortRequest deviceInfoGetSecurityPortRequest)
        {
            return Channel.GetSecurityPortAsync(deviceInfoGetSecurityPortRequest);
        }

        public Task<DeviceInfoGetInfoResponse> GetInfoAsync(DeviceInfoGetInfoRequest deviceInfoGetInfoRequest)
        {
            return Channel.GetInfoAsync(deviceInfoGetInfoRequest);
        }

        public Task<DeviceInfoGetDeviceLogResponse> GetDeviceLogAsync(DeviceInfoGetDeviceLogRequest deviceInfoGetDeviceLogRequest)
        {
            return Channel.GetDeviceLogAsync(deviceInfoGetDeviceLogRequest);
        }

        public Task<DeviceInfoSetProvisioningCodeResponse> SetProvisioningCodeAsync(DeviceInfoSetProvisioningCodeRequest setProvisioningCodeRequest)
        {
            return Channel.SetProvisioningCodeAsync(setProvisioningCodeRequest);
        }
    }
}