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
        : base(deviceLoginInfo, logger, "LANHostConfigManagement")
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
        LanHostConfigManagementGetInfoResponse = await ExecuteApiAsync(q => q.LanHostConfigManagementGetInfoAsync());
    }

    private async Task LanHostConfigManagementGetSubnetMaskAsync()
    {
        LanHostConfigManagementGetSubnetMaskResponse = await ExecuteApiAsync(q => q.LanHostConfigManagementGetSubnetMaskAsync());
    }

    private async Task LanHostConfigManagementGetIpRoutersListAsync()
    {
        LanHostConfigManagementGetIpRoutersListResponse = await ExecuteApiAsync(q => q.LanHostConfigManagementGetIpRoutersListAsync());
    }

    private async Task LanHostConfigManagementGetAddressRangeAsync()
    {
        LanHostConfigManagementGetAddressRangeResponse = await ExecuteApiAsync(q => q.LanHostConfigManagementGetAddressRangeAsync());
    }

    private async Task LanHostConfigManagementGetIpInterfaceNumberOfEntriesAsync()
    {
        LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse = await ExecuteApiAsync(q => q.LanHostConfigManagementGetIpInterfaceNumberOfEntriesAsync());
    }

    private async Task LanHostConfigManagementGetDnsServersAsync()
    {
        LanHostConfigManagementGetDnsServersResponse = await ExecuteApiAsync(q => q.LanHostConfigManagementGetDnsServersAsync());
    }
}