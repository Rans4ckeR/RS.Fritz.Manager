namespace RS.Fritz.Manager.UI;

internal sealed class LanHostConfigManagementViewModel : FritzServiceViewModel
{
    private LanHostConfigManagementGetInfoResponse? lanHostConfigManagementGetInfoResponse;

    public LanHostConfigManagementViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
    }

    public LanHostConfigManagementGetInfoResponse? LanHostConfigManagementGetInfoResponse
    {
        get => lanHostConfigManagementGetInfoResponse;
        private set { _ = SetProperty(ref lanHostConfigManagementGetInfoResponse, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        await API.TaskExtensions.WhenAllSafe(new[]
            {
                GetLanHostConfigManagementGetInfoAsync()
            });
    }

    private async Task GetLanHostConfigManagementGetInfoAsync()
    {
        LanHostConfigManagementGetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.LanHostConfigManagementGetInfoAsync();
    }
}