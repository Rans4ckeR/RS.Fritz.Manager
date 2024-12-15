using System.Net;

namespace RS.Fritz.Manager.API;

internal sealed class FritzLanConfigSecurityService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential? networkCredential = null)
    : FritzServiceClient<IFritzLanConfigSecurityService>(endpointConfiguration, remoteAddress, networkCredential), IFritzLanConfigSecurityService
{
    public const string ControlUrl = "/upnp/control/lanconfigsecurity";

    public Task<LanConfigSecurityGetAnonymousLoginResponse> GetAnonymousLoginAsync(LanConfigSecurityGetAnonymousLoginRequest lanConfigSecurityGetAnonymousLoginRequest)
        => Channel.GetAnonymousLoginAsync(lanConfigSecurityGetAnonymousLoginRequest);

    public Task<LanConfigSecurityGetCurrentUserResponse> GetCurrentUserAsync(LanConfigSecurityGetCurrentUserRequest lanConfigSecurityGetCurrentUserRequest)
        => Channel.GetCurrentUserAsync(lanConfigSecurityGetCurrentUserRequest);

    public Task<LanConfigSecurityGetInfoResponse> GetInfoAsync(LanConfigSecurityGetInfoRequest lanConfigSecurityGetInfoRequest)
        => Channel.GetInfoAsync(lanConfigSecurityGetInfoRequest);

    public Task<LanConfigSecurityGetUserListResponse> GetUserListAsync(LanConfigSecurityGetUserListRequest lanConfigSecurityGetUserListRequest)
        => Channel.GetUserListAsync(lanConfigSecurityGetUserListRequest);

    public Task<LanConfigSecuritySetConfigPasswordResponse> SetConfigPasswordAsync(LanConfigSecuritySetConfigPasswordRequest lanConfigSecuritySetConfigPasswordRequest)
        => Channel.SetConfigPasswordAsync(lanConfigSecuritySetConfigPasswordRequest);
}