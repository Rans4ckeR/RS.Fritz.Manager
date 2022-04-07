namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzDeviceConfigService : FritzServiceClient<IFritzDeviceConfigService>, IFritzDeviceConfigService
{
    public const string ControlUrl = "/upnp/control/deviceconfig";

    public FritzDeviceConfigService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<DeviceConfigGetPersistentDataResponse> GetPersistentDataAsync(DeviceConfigGetPersistentDataRequest deviceConfigGetPersistentDataRequest)
    {
        return Channel.GetPersistentDataAsync(deviceConfigGetPersistentDataRequest);
    }
}