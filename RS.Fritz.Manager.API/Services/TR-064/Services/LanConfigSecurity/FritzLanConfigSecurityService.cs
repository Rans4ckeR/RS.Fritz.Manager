namespace RS.Fritz.Manager.API;

using System.ServiceModel.Channels;

internal sealed class FritzLanConfigSecurityService(Binding binding, EndpointAddress remoteAddress)
    : ClientBase<IFritzLanConfigSecurityService>(binding, remoteAddress), IFritzLanConfigSecurityService
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