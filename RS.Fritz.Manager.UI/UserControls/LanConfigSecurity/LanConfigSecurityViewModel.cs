namespace RS.Fritz.Manager.UI;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

internal sealed class LanConfigSecurityViewModel : FritzServiceViewModel
{
    private LanConfigSecurityGetAnonymousLoginResponse? lanConfigSecurityGetAnonymousLoginResponse;
    private LanConfigSecurityGetCurrentUserResponse? lanConfigSecurityGetCurrentUserResponse;
    private LanConfigSecurityGetInfoResponse? lanConfigSecurityGetInfoResponse;
    private LanConfigSecurityGetUserListResponse? lanConfigSecurityGetUserListResponse;

    public LanConfigSecurityViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, LanConfigSecuritySetConfigPasswordViewModel lanConfigSecuritySetConfigPasswordViewModel)
        : base(deviceLoginInfo, logger)
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

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken = default)
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
        LanConfigSecurityGetAnonymousLoginResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.LanConfigSecurityGetAnonymousLoginAsync();
    }

    private async Task GetLanConfigSecurityGetCurrentUserAsync()
    {
        LanConfigSecurityGetCurrentUserResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.LanConfigSecurityGetCurrentUserAsync();
    }

    private async Task GetLanConfigSecurityGetInfoAsync()
    {
        LanConfigSecurityGetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.LanConfigSecurityGetInfoAsync();
    }

    private async Task GetLanConfigSecurityGetUserListAsync()
    {
        LanConfigSecurityGetUserListResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.LanConfigSecurityGetUserListAsync();
    }
}