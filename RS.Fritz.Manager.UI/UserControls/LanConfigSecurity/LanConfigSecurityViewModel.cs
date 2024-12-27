namespace RS.Fritz.Manager.UI;

internal sealed class LanConfigSecurityViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, LanConfigSecuritySetConfigPasswordViewModel lanConfigSecuritySetConfigPasswordViewModel)
    : FritzServiceViewModel(deviceLoginInfo, logger, "LANConfigSecurity")
{
    public LanConfigSecuritySetConfigPasswordViewModel LanConfigSecuritySetConfigPasswordViewModel { get; } = lanConfigSecuritySetConfigPasswordViewModel;

    public KeyValuePair<LanConfigSecurityGetAnonymousLoginResponse?, UPnPFault?>? LanConfigSecurityGetAnonymousLoginResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<LanConfigSecurityGetCurrentUserResponse?, UPnPFault?>? LanConfigSecurityGetCurrentUserResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<LanConfigSecurityGetInfoResponse?, UPnPFault?>? LanConfigSecurityGetInfoResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<LanConfigSecurityGetUserListResponse?, UPnPFault?>? LanConfigSecurityGetUserListResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => API.TaskExtensions.WhenAllSafe(
            [
                GetLanConfigSecurityGetAnonymousLoginAsync(),
                GetLanConfigSecurityGetCurrentUserAsync(),
                GetLanConfigSecurityGetInfoAsync(),
                GetLanConfigSecurityGetUserListAsync()
            ],
            true);

    private async Task GetLanConfigSecurityGetAnonymousLoginAsync()
        => LanConfigSecurityGetAnonymousLoginResponse = await ExecuteApiAsync(static q => q.LanConfigSecurityGetAnonymousLoginAsync()).ConfigureAwait(true);

    private async Task GetLanConfigSecurityGetCurrentUserAsync()
        => LanConfigSecurityGetCurrentUserResponse = await ExecuteApiAsync(static q => q.LanConfigSecurityGetCurrentUserAsync()).ConfigureAwait(true);

    private async Task GetLanConfigSecurityGetInfoAsync()
        => LanConfigSecurityGetInfoResponse = await ExecuteApiAsync(static q => q.LanConfigSecurityGetInfoAsync()).ConfigureAwait(true);

    private async Task GetLanConfigSecurityGetUserListAsync()
        => LanConfigSecurityGetUserListResponse = await ExecuteApiAsync(static q => q.LanConfigSecurityGetUserListAsync()).ConfigureAwait(true);
}