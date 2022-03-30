namespace RS.Fritz.Manager.UI;

internal sealed class LanConfigSecurityViewModel : FritzServiceViewModel
{
    private LanConfigSecurityGetAnonymousLoginResponse? lanConfigSecurityGetAnonymousLoginResponse;
    private LanConfigSecurityGetCurrentUserResponse? lanConfigSecurityGetCurrentUserResponse;
    private LanConfigSecurityGetInfoResponse? lanConfigSecurityGetInfoResponse;
    private LanConfigSecurityGetUserListResponse? lanConfigSecurityGetUserListResponse;

    public LanConfigSecurityViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, LanConfigSecuritySetConfigPasswordViewModel lanConfigSecuritySetConfigPasswordViewModel)
        : base(deviceLoginInfo, logger, "LANConfigSecurity")
    {
        LanConfigSecuritySetConfigPasswordViewModel = lanConfigSecuritySetConfigPasswordViewModel;
    }

    public LanConfigSecuritySetConfigPasswordViewModel LanConfigSecuritySetConfigPasswordViewModel { get; }

    public LanConfigSecurityGetAnonymousLoginResponse? LanConfigSecurityGetAnonymousLoginResponse
    {
        get => lanConfigSecurityGetAnonymousLoginResponse;
        private set { _ = SetProperty(ref lanConfigSecurityGetAnonymousLoginResponse, value); }
    }

    public LanConfigSecurityGetCurrentUserResponse? LanConfigSecurityGetCurrentUserResponse
    {
        get => lanConfigSecurityGetCurrentUserResponse;
        private set { _ = SetProperty(ref lanConfigSecurityGetCurrentUserResponse, value); }
    }

    public LanConfigSecurityGetInfoResponse? LanConfigSecurityGetInfoResponse
    {
        get => lanConfigSecurityGetInfoResponse;
        private set { _ = SetProperty(ref lanConfigSecurityGetInfoResponse, value); }
    }

    public LanConfigSecurityGetUserListResponse? LanConfigSecurityGetUserListResponse
    {
        get => lanConfigSecurityGetUserListResponse;
        private set { _ = SetProperty(ref lanConfigSecurityGetUserListResponse, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        await API.TaskExtensions.WhenAllSafe(new[]
            {
                GetLanConfigSecurityGetAnonymousLoginAsync(),
                GetLanConfigSecurityGetCurrentUserAsync(),
                GetLanConfigSecurityGetInfoAsync(),
                GetLanConfigSecurityGetUserListAsync()
            });
    }

    private async Task GetLanConfigSecurityGetAnonymousLoginAsync()
    {
        LanConfigSecurityGetAnonymousLoginResponse = await ExecuteApiAsync(q => q.LanConfigSecurityGetAnonymousLoginAsync());
    }

    private async Task GetLanConfigSecurityGetCurrentUserAsync()
    {
        LanConfigSecurityGetCurrentUserResponse = await ExecuteApiAsync(q => q.LanConfigSecurityGetCurrentUserAsync());
    }

    private async Task GetLanConfigSecurityGetInfoAsync()
    {
        LanConfigSecurityGetInfoResponse = await ExecuteApiAsync(q => q.LanConfigSecurityGetInfoAsync());
    }

    private async Task GetLanConfigSecurityGetUserListAsync()
    {
        LanConfigSecurityGetUserListResponse = await ExecuteApiAsync(q => q.LanConfigSecurityGetUserListAsync());
    }
}