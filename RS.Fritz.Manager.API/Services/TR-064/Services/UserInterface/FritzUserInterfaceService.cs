using System.Net;

namespace RS.Fritz.Manager.API;

internal sealed class FritzUserInterfaceService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
    : FritzServiceClient<IFritzUserInterfaceService>(endpointConfiguration, remoteAddress, networkCredential), IFritzUserInterfaceService
{
    public const string ControlUrl = "/upnp/control/userif";

    public Task<UserInterfaceGetInfoResponse> GetInfoAsync(UserInterfaceGetInfoRequest userInterfaceGetInfoRequest)
        => Channel.GetInfoAsync(userInterfaceGetInfoRequest);

    public Task<UserInterfaceCheckUpdateResponse> CheckUpdateAsync(UserInterfaceCheckUpdateRequest userInterfaceCheckUpdateRequest)
        => Channel.CheckUpdateAsync(userInterfaceCheckUpdateRequest);

    public Task<UserInterfaceDoPrepareCgiResponse> DoPrepareCgiAsync(UserInterfaceDoPrepareCgiRequest userInterfaceDoPrepareCgiRequest)
        => Channel.DoPrepareCgiAsync(userInterfaceDoPrepareCgiRequest);

    public Task<UserInterfaceDoUpdateResponse> DoUpdateAsync(UserInterfaceDoUpdateRequest userInterfaceDoUpdateRequest)
        => Channel.DoUpdateAsync(userInterfaceDoUpdateRequest);

    public Task<UserInterfaceDoManualUpdateResponse> DoManualUpdateAsync(UserInterfaceDoManualUpdateRequest userInterfaceDoManualUpdateRequest)
        => Channel.DoManualUpdateAsync(userInterfaceDoManualUpdateRequest);

    public Task<UserInterfaceGetInternationalConfigResponse> GetInternationalConfigAsync(UserInterfaceGetInternationalConfigRequest userInterfaceGetInternationalConfigRequest)
        => Channel.GetInternationalConfigAsync(userInterfaceGetInternationalConfigRequest);

    public Task<UserInterfaceSetInternationalConfigResponse> SetInternationalConfigAsync(UserInterfaceSetInternationalConfigRequest userInterfaceSetInternationalConfigRequest)
        => Channel.SetInternationalConfigAsync(userInterfaceSetInternationalConfigRequest);

    public Task<UserInterfaceAvmGetInfoResponse> AvmGetInfoAsync(UserInterfaceAvmGetInfoRequest userInterfaceAvmGetInfoRequest)
        => Channel.AvmGetInfoAsync(userInterfaceAvmGetInfoRequest);

    public Task<UserInterfaceSetConfigResponse> SetConfigAsync(UserInterfaceSetConfigRequest userInterfaceSetConfigRequest)
        => Channel.SetConfigAsync(userInterfaceSetConfigRequest);
}