namespace RS.Fritz.Manager.UI;

internal sealed class LanHostConfigManagementViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : FritzServiceViewModel(deviceLoginInfo, logger, "LANHostConfigManagement")
{
    public KeyValuePair<LanHostConfigManagementGetInfoResponse?, UPnPFault?>? LanHostConfigManagementGetInfoResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<LanHostConfigManagementGetSubnetMaskResponse?, UPnPFault?>?
        LanHostConfigManagementGetSubnetMaskResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<LanHostConfigManagementGetIpRoutersListResponse?, UPnPFault?>?
        LanHostConfigManagementGetIpRoutersListResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<LanHostConfigManagementGetAddressRangeResponse?, UPnPFault?>?
        LanHostConfigManagementGetAddressRangeResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse?, UPnPFault?>?
        LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<LanHostConfigManagementGetDnsServersResponse?, UPnPFault?>?
        LanHostConfigManagementGetDnsServersResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => API.TaskExtensions.WhenAllSafe(
            [
                GetLanHostConfigManagementGetInfoAsync(),
                LanHostConfigManagementGetSubnetMaskAsync(),
                LanHostConfigManagementGetIpRoutersListAsync(),
                LanHostConfigManagementGetAddressRangeAsync(),
                LanHostConfigManagementGetIpInterfaceNumberOfEntriesAsync(),
                LanHostConfigManagementGetDnsServersAsync()
            ],
            true);

    private async Task GetLanHostConfigManagementGetInfoAsync()
        => LanHostConfigManagementGetInfoResponse = await ExecuteApiAsync(static q => q.LanHostConfigManagementGetInfoAsync()).ConfigureAwait(true);

    private async Task LanHostConfigManagementGetSubnetMaskAsync()
        => LanHostConfigManagementGetSubnetMaskResponse = await ExecuteApiAsync(static q => q.LanHostConfigManagementGetSubnetMaskAsync()).ConfigureAwait(true);

    private async Task LanHostConfigManagementGetIpRoutersListAsync()
        => LanHostConfigManagementGetIpRoutersListResponse = await ExecuteApiAsync(static q => q.LanHostConfigManagementGetIpRoutersListAsync()).ConfigureAwait(true);

    private async Task LanHostConfigManagementGetAddressRangeAsync()
        => LanHostConfigManagementGetAddressRangeResponse = await ExecuteApiAsync(static q => q.LanHostConfigManagementGetAddressRangeAsync()).ConfigureAwait(true);

    private async Task LanHostConfigManagementGetIpInterfaceNumberOfEntriesAsync()
        => LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse = await ExecuteApiAsync(static q => q.LanHostConfigManagementGetIpInterfaceNumberOfEntriesAsync()).ConfigureAwait(true);

    private async Task LanHostConfigManagementGetDnsServersAsync()
        => LanHostConfigManagementGetDnsServersResponse = await ExecuteApiAsync(static q => q.LanHostConfigManagementGetDnsServersAsync()).ConfigureAwait(true);
}