namespace RS.Fritz.Manager.UI;

internal sealed class LanHostConfigManagementViewModel : FritzServiceViewModel
{
    private LanHostConfigManagementGetInfoResponse? lanHostConfigManagementGetInfoResponse;
    private LanHostConfigManagementGetSubnetMaskResponse? lanHostConfigManagementGetSubnetMaskResponse;
    private LanHostConfigManagementGetIpRoutersListResponse? lanHostConfigManagementGetIpRoutersListResponse;
    private LanHostConfigManagementGetAddressRangeResponse? lanHostConfigManagementGetAddressRangeResponse;
    private LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse? lanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse;
    private LanHostConfigManagementGetDnsServersResponse? lanHostConfigManagementGetDnsServersResponse;

    public LanHostConfigManagementViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
    }

    public LanHostConfigManagementGetInfoResponse? LanHostConfigManagementGetInfoResponse
    {
        get => lanHostConfigManagementGetInfoResponse;
        private set { _ = SetProperty(ref lanHostConfigManagementGetInfoResponse, value); }
    }

    public LanHostConfigManagementGetSubnetMaskResponse? LanHostConfigManagementGetSubnetMaskResponse
    {
        get => lanHostConfigManagementGetSubnetMaskResponse;
        private set { _ = SetProperty(ref lanHostConfigManagementGetSubnetMaskResponse, value); }
    }

    public LanHostConfigManagementGetIpRoutersListResponse? LanHostConfigManagementGetIpRoutersListResponse
    {
        get => lanHostConfigManagementGetIpRoutersListResponse;
        private set { _ = SetProperty(ref lanHostConfigManagementGetIpRoutersListResponse, value); }
    }

    public LanHostConfigManagementGetAddressRangeResponse? LanHostConfigManagementGetAddressRangeResponse
    {
        get => lanHostConfigManagementGetAddressRangeResponse;
        private set { _ = SetProperty(ref lanHostConfigManagementGetAddressRangeResponse, value); }
    }

    public LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse? LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse
    {
        get => lanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse;
        private set { _ = SetProperty(ref lanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse, value); }
    }

    public LanHostConfigManagementGetDnsServersResponse? LanHostConfigManagementGetDnsServersResponse
    {
        get => lanHostConfigManagementGetDnsServersResponse;
        private set { _ = SetProperty(ref lanHostConfigManagementGetDnsServersResponse, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        await API.TaskExtensions.WhenAllSafe(new[]
            {
                GetLanHostConfigManagementGetInfoAsync(),
                LanHostConfigManagementGetSubnetMaskAsync(),
                LanHostConfigManagementGetIpRoutersListAsync(),
                LanHostConfigManagementGetAddressRangeAsync(),
                LanHostConfigManagementGetIpInterfaceNumberOfEntriesAsync(),
                LanHostConfigManagementGetDnsServersAsync()
            });
    }

    private async Task GetLanHostConfigManagementGetInfoAsync()
    {
        LanHostConfigManagementGetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.LanHostConfigManagementGetInfoAsync();
    }

    private async Task LanHostConfigManagementGetSubnetMaskAsync()
    {
        LanHostConfigManagementGetSubnetMaskResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.LanHostConfigManagementGetSubnetMaskAsync();
    }

    private async Task LanHostConfigManagementGetIpRoutersListAsync()
    {
        LanHostConfigManagementGetIpRoutersListResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.LanHostConfigManagementGetIpRoutersListAsync();
    }

    private async Task LanHostConfigManagementGetAddressRangeAsync()
    {
        LanHostConfigManagementGetAddressRangeResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.LanHostConfigManagementGetAddressRangeAsync();
    }

    private async Task LanHostConfigManagementGetIpInterfaceNumberOfEntriesAsync()
    {
        LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.LanHostConfigManagementGetIpInterfaceNumberOfEntriesAsync();
    }

    private async Task LanHostConfigManagementGetDnsServersAsync()
    {
        LanHostConfigManagementGetDnsServersResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.LanHostConfigManagementGetDnsServersAsync();
    }
}