namespace RS.Fritz.Manager.UI;

internal sealed class LanConfigSecurityViewModel : FritzServiceViewModel
{
    private KeyValuePair<LanConfigSecurityGetAnonymousLoginResponse?, UPnPFault?>? lanConfigSecurityGetAnonymousLoginResponse;
    private KeyValuePair<LanConfigSecurityGetCurrentUserResponse?, UPnPFault?>? lanConfigSecurityGetCurrentUserResponse;
    private KeyValuePair<LanConfigSecurityGetInfoResponse?, UPnPFault?>? lanConfigSecurityGetInfoResponse;
    private KeyValuePair<LanConfigSecurityGetUserListResponse?, UPnPFault?>? lanConfigSecurityGetUserListResponse;

    public LanConfigSecurityViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, LanConfigSecuritySetConfigPasswordViewModel lanConfigSecuritySetConfigPasswordViewModel)
        : base(deviceLoginInfo, logger, "LANConfigSecurity")
    {
        LanConfigSecuritySetConfigPasswordViewModel = lanConfigSecuritySetConfigPasswordViewModel;
    }

    public LanConfigSecuritySetConfigPasswordViewModel LanConfigSecuritySetConfigPasswordViewModel { get; }

    public KeyValuePair<LanConfigSecurityGetAnonymousLoginResponse?, UPnPFault?>? LanConfigSecurityGetAnonymousLoginResponse
    {
        get => lanConfigSecurityGetAnonymousLoginResponse;
        private set => _ = SetProperty(ref lanConfigSecurityGetAnonymousLoginResponse, value);
    }

    public KeyValuePair<LanConfigSecurityGetCurrentUserResponse?, UPnPFault?>? LanConfigSecurityGetCurrentUserResponse
    {
        get => lanConfigSecurityGetCurrentUserResponse;
        private set => _ = SetProperty(ref lanConfigSecurityGetCurrentUserResponse, value);
    }

    public KeyValuePair<LanConfigSecurityGetInfoResponse?, UPnPFault?>? LanConfigSecurityGetInfoResponse
    {
        get => lanConfigSecurityGetInfoResponse;
        private set => _ = SetProperty(ref lanConfigSecurityGetInfoResponse, value);
    }

    public KeyValuePair<LanConfigSecurityGetUserListResponse?, UPnPFault?>? LanConfigSecurityGetUserListResponse
    {
        get => lanConfigSecurityGetUserListResponse;
        private set => _ = SetProperty(ref lanConfigSecurityGetUserListResponse, value);
    }

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        return API.TaskExtensions.WhenAllSafe(new[]
            {
                GetLanConfigSecurityGetAnonymousLoginAsync(),
                GetLanConfigSecurityGetCurrentUserAsync(),
                GetLanConfigSecurityGetInfoAsync(),
                GetLanConfigSecurityGetUserListAsync()
            });
    }

    private async Task GetLanConfigSecurityGetAnonymousLoginAsync()
        => LanConfigSecurityGetAnonymousLoginResponse = await ExecuteApiAsync(q => q.LanConfigSecurityGetAnonymousLoginAsync());

    private async Task GetLanConfigSecurityGetCurrentUserAsync()
        => LanConfigSecurityGetCurrentUserResponse = await ExecuteApiAsync(q => q.LanConfigSecurityGetCurrentUserAsync());

    private async Task GetLanConfigSecurityGetInfoAsync()
        => LanConfigSecurityGetInfoResponse = await ExecuteApiAsync(q => q.LanConfigSecurityGetInfoAsync());

    private async Task GetLanConfigSecurityGetUserListAsync()
        => LanConfigSecurityGetUserListResponse = await ExecuteApiAsync(q => q.LanConfigSecurityGetUserListAsync());
}