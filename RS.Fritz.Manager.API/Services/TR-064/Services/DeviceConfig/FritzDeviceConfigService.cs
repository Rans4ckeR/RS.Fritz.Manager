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
        => Channel.GetPersistentDataAsync(deviceConfigGetPersistentDataRequest);

    public Task<DeviceConfigGenerateUuIdResponse> GenerateUuIdAsync(DeviceConfigGenerateUuIdRequest deviceConfigGenerateUuIdRequest)
        => Channel.GenerateUuIdAsync(deviceConfigGenerateUuIdRequest);

    public Task<DeviceConfigCreateUrlSidResponse> CreateUrlSidAsync(DeviceConfigCreateUrlSidRequest deviceConfigCreateUrlSidRequest)
        => Channel.CreateUrlSidAsync(deviceConfigCreateUrlSidRequest);

    public Task<DeviceConfigGetSupportDataInfoResponse> GetSupportDataInfoAsync(DeviceConfigGetSupportDataInfoRequest deviceConfigGetSupportDataInfoRequest)
        => Channel.GetSupportDataInfoAsync(deviceConfigGetSupportDataInfoRequest);
}