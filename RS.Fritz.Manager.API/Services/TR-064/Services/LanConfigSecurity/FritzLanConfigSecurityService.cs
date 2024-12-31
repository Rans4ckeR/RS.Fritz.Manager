using System.Net;
using Microsoft.Extensions.Logging;

namespace RS.Fritz.Manager.API;

internal sealed class FritzLanConfigSecurityService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential? networkCredential, ILoggerFactory loggerFactory)
    : FritzServiceClient<IFritzLanConfigSecurityService>(endpointConfiguration, remoteAddress, networkCredential, loggerFactory), IFritzLanConfigSecurityService
{
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