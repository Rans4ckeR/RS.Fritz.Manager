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
    {
        return Channel.GetInfoAsync(userInterfaceGetInfoRequest);
    }

    public Task<UserInterfaceCheckUpdateResponse> CheckUpdateAsync(UserInterfaceCheckUpdateRequest userInterfaceCheckUpdateRequest)
    {
        return Channel.CheckUpdateAsync(userInterfaceCheckUpdateRequest);
    }

    public Task<UserInterfaceDoPrepareCgiResponse> DoPrepareCgiAsync(UserInterfaceDoPrepareCgiRequest userInterfaceDoPrepareCgiRequest)
    {
        return Channel.DoPrepareCgiAsync(userInterfaceDoPrepareCgiRequest);
    }

    public Task<UserInterfaceDoUpdateResponse> DoUpdateAsync(UserInterfaceDoUpdateRequest userInterfaceDoUpdateRequest)
    {
        return Channel.DoUpdateAsync(userInterfaceDoUpdateRequest);
    }

    public Task<UserInterfaceDoManualUpdateResponse> DoManualUpdateAsync(UserInterfaceDoManualUpdateRequest userInterfaceDoManualUpdateRequest)
    {
        return Channel.DoManualUpdateAsync(userInterfaceDoManualUpdateRequest);
    }

    public Task<UserInterfaceGetInternationalConfigResponse> GetInternationalConfigAsync(UserInterfaceGetInternationalConfigRequest userInterfaceGetInternationalConfigRequest)
    {
        return Channel.GetInternationalConfigAsync(userInterfaceGetInternationalConfigRequest);
    }

    public Task<UserInterfaceSetInternationalConfigResponse> SetInternationalConfigAsync(UserInterfaceSetInternationalConfigRequest userInterfaceSetInternationalConfigRequest)
    {
        return Channel.SetInternationalConfigAsync(userInterfaceSetInternationalConfigRequest);
    }

    public Task<UserInterfaceAvmGetInfoResponse> AvmGetInfoAsync(UserInterfaceAvmGetInfoRequest userInterfaceAvmGetInfoRequest)
    {
        return Channel.AvmGetInfoAsync(userInterfaceAvmGetInfoRequest);
    }

    public Task<UserInterfaceSetConfigResponse> SetConfigAsync(UserInterfaceSetConfigRequest userInterfaceSetConfigRequest)
    {
        return Channel.SetConfigAsync(userInterfaceSetConfigRequest);
    }
}