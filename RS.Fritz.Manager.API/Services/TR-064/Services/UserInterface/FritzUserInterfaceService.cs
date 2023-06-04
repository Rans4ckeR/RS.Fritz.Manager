namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzUserInterfaceService : FritzServiceClient<IFritzUserInterfaceService>, IFritzUserInterfaceService
{
    public const string ControlUrl = "/upnp/control/userif";

    public FritzUserInterfaceService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

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