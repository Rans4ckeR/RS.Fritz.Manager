namespace RS.Fritz.Manager.UI;

internal sealed class LanHostConfigManagementViewModel : FritzServiceViewModel
{
    private KeyValuePair<LanHostConfigManagementGetInfoResponse?, UPnPFault?>? lanHostConfigManagementGetInfoResponse;
    private KeyValuePair<LanHostConfigManagementGetSubnetMaskResponse?, UPnPFault?>? lanHostConfigManagementGetSubnetMaskResponse;
    private KeyValuePair<LanHostConfigManagementGetIpRoutersListResponse?, UPnPFault?>? lanHostConfigManagementGetIpRoutersListResponse;
    private KeyValuePair<LanHostConfigManagementGetAddressRangeResponse?, UPnPFault?>? lanHostConfigManagementGetAddressRangeResponse;
    private KeyValuePair<LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse?, UPnPFault?>? lanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse;
    private KeyValuePair<LanHostConfigManagementGetDnsServersResponse?, UPnPFault?>? lanHostConfigManagementGetDnsServersResponse;

    public LanHostConfigManagementViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "LANHostConfigManagement")
    {
    }

    public KeyValuePair<LanHostConfigManagementGetInfoResponse?, UPnPFault?>? LanHostConfigManagementGetInfoResponse
    {
        get => lanHostConfigManagementGetInfoResponse;
        private set => _ = SetProperty(ref lanHostConfigManagementGetInfoResponse, value);
    }

    public KeyValuePair<LanHostConfigManagementGetSubnetMaskResponse?, UPnPFault?>? LanHostConfigManagementGetSubnetMaskResponse
    {
        get => lanHostConfigManagementGetSubnetMaskResponse;
        private set => _ = SetProperty(ref lanHostConfigManagementGetSubnetMaskResponse, value);
    }

    public KeyValuePair<LanHostConfigManagementGetIpRoutersListResponse?, UPnPFault?>? LanHostConfigManagementGetIpRoutersListResponse
    {
        get => lanHostConfigManagementGetIpRoutersListResponse;
        private set => _ = SetProperty(ref lanHostConfigManagementGetIpRoutersListResponse, value);
    }

    public KeyValuePair<LanHostConfigManagementGetAddressRangeResponse?, UPnPFault?>? LanHostConfigManagementGetAddressRangeResponse
    {
        get => lanHostConfigManagementGetAddressRangeResponse;
        private set => _ = SetProperty(ref lanHostConfigManagementGetAddressRangeResponse, value);
    }

    public KeyValuePair<LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse?, UPnPFault?>? LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse
    {
        get => lanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse;
        private set => _ = SetProperty(ref lanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse, value);
    }

    public KeyValuePair<LanHostConfigManagementGetDnsServersResponse?, UPnPFault?>? LanHostConfigManagementGetDnsServersResponse
    {
        get => lanHostConfigManagementGetDnsServersResponse;
        private set => _ = SetProperty(ref lanHostConfigManagementGetDnsServersResponse, value);
    }

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        return API.TaskExtensions.WhenAllSafe(new[]
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
        => LanHostConfigManagementGetInfoResponse = await ExecuteApiAsync(q => q.LanHostConfigManagementGetInfoAsync());

    private async Task LanHostConfigManagementGetSubnetMaskAsync()
        => LanHostConfigManagementGetSubnetMaskResponse = await ExecuteApiAsync(q => q.LanHostConfigManagementGetSubnetMaskAsync());

    private async Task LanHostConfigManagementGetIpRoutersListAsync()
        => LanHostConfigManagementGetIpRoutersListResponse = await ExecuteApiAsync(q => q.LanHostConfigManagementGetIpRoutersListAsync());

    private async Task LanHostConfigManagementGetAddressRangeAsync()
        => LanHostConfigManagementGetAddressRangeResponse = await ExecuteApiAsync(q => q.LanHostConfigManagementGetAddressRangeAsync());

    private async Task LanHostConfigManagementGetIpInterfaceNumberOfEntriesAsync()
        => LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse = await ExecuteApiAsync(q => q.LanHostConfigManagementGetIpInterfaceNumberOfEntriesAsync());

    private async Task LanHostConfigManagementGetDnsServersAsync()
        => LanHostConfigManagementGetDnsServersResponse = await ExecuteApiAsync(q => q.LanHostConfigManagementGetDnsServersAsync());
}