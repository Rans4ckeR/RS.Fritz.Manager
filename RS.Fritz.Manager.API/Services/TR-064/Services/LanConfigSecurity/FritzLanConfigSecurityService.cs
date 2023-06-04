namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzLanConfigSecurityService : FritzServiceClient<IFritzLanConfigSecurityService>, IFritzLanConfigSecurityService
{
    public const string ControlUrl = "/upnp/control/lanconfigsecurity";

    public FritzLanConfigSecurityService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential? networkCredential = null)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

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