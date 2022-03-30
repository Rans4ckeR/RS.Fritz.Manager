namespace RS.Fritz.Manager.UI;

internal sealed class WanIpConnectionViewModel : WanAccessTypeAwareFritzServiceViewModel
{
    private WanIpConnectionGetInfoResponse? wanIpConnectionGetInfoResponse;
    private WanConnectionGetConnectionTypeInfoResponse? wanConnectionGetConnectionTypeInfoResponse;
    private WanConnectionGetStatusInfoResponse? wanConnectionGetStatusInfoResponse;
    private WanConnectionGetNatRsipStatusResponse? wanConnectionGetNatRsipStatusResponse;
    private WanConnectionGetDnsServersResponse? wanConnectionGetDnsServersResponse;
    private WanConnectionGetPortMappingNumberOfEntriesResponse? wanConnectionGetPortMappingNumberOfEntriesResponse;
    private WanConnectionGetExternalIpAddressResponse? wanConnectionGetExternalIpAddressResponse;

    public WanIpConnectionViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, WanIpConnectionGetGenericPortMappingEntryViewModel wanIpConnectionGetGenericPortMappingEntryViewModel)
        : base(deviceLoginInfo, logger, WanAccessType.Ethernet, "WANIPConnection")
    {
        WanIpConnectionGetGenericPortMappingEntryViewModel = wanIpConnectionGetGenericPortMappingEntryViewModel;
    }

    public WanIpConnectionGetGenericPortMappingEntryViewModel WanIpConnectionGetGenericPortMappingEntryViewModel { get; }

    public WanIpConnectionGetInfoResponse? WanIpConnectionGetInfoResponse
    {
        get => wanIpConnectionGetInfoResponse;
        private set { _ = SetProperty(ref wanIpConnectionGetInfoResponse, value); }
    }

    public WanConnectionGetConnectionTypeInfoResponse? WanConnectionGetConnectionTypeInfoResponse
    {
        get => wanConnectionGetConnectionTypeInfoResponse;
        private set { _ = SetProperty(ref wanConnectionGetConnectionTypeInfoResponse, value); }
    }

    public WanConnectionGetStatusInfoResponse? WanConnectionGetStatusInfoResponse
    {
        get => wanConnectionGetStatusInfoResponse;
        private set { _ = SetProperty(ref wanConnectionGetStatusInfoResponse, value); }
    }

    public WanConnectionGetNatRsipStatusResponse? WanConnectionGetNatRsipStatusResponse
    {
        get => wanConnectionGetNatRsipStatusResponse;
        private set { _ = SetProperty(ref wanConnectionGetNatRsipStatusResponse, value); }
    }

    public WanConnectionGetDnsServersResponse? WanConnectionGetDnsServersResponse
    {
        get => wanConnectionGetDnsServersResponse;
        private set { _ = SetProperty(ref wanConnectionGetDnsServersResponse, value); }
    }

    public WanConnectionGetPortMappingNumberOfEntriesResponse? WanConnectionGetPortMappingNumberOfEntriesResponse
    {
        get => wanConnectionGetPortMappingNumberOfEntriesResponse;
        private set
        {
            if (SetProperty(ref wanConnectionGetPortMappingNumberOfEntriesResponse, value))
                WanIpConnectionGetGenericPortMappingEntryViewModel.PortMappingNumberOfEntries = WanConnectionGetPortMappingNumberOfEntriesResponse?.PortMappingNumberOfEntries;
        }
    }

    public WanConnectionGetExternalIpAddressResponse? WanConnectionGetExternalIpAddressResponse
    {
        get => wanConnectionGetExternalIpAddressResponse;
        private set { _ = SetProperty(ref wanConnectionGetExternalIpAddressResponse, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        await API.TaskExtensions.WhenAllSafe(new[]
          {
                GetWanIpConnectionGetInfoAsync(),
                GetWanIpConnectionGetConnectionTypeInfoAsync(),
                GetWanIpConnectionGetStatusInfoAsync(),
                GetWanIpConnectionGetNatRsipStatusAsync(),
                GetWanIpConnectionGetDnsServersAsync(),
                GetWanIpConnectionGetPortMappingNumberOfEntriesAsync(),
                GetWanIpConnectionGetExternalIpAddressAsync()
          });
    }

    private async Task GetWanIpConnectionGetInfoAsync()
    {
        WanIpConnectionGetInfoResponse = await ExecuteApiAsync(q => q.WanIpConnectionGetInfoAsync());
    }

    private async Task GetWanIpConnectionGetConnectionTypeInfoAsync()
    {
        WanConnectionGetConnectionTypeInfoResponse = await ExecuteApiAsync(q => q.WanIpConnectionGetConnectionTypeInfoAsync());
    }

    private async Task GetWanIpConnectionGetStatusInfoAsync()
    {
        WanConnectionGetStatusInfoResponse = await ExecuteApiAsync(q => q.WanIpConnectionGetStatusInfoAsync());
    }

    private async Task GetWanIpConnectionGetNatRsipStatusAsync()
    {
        WanConnectionGetNatRsipStatusResponse = await ExecuteApiAsync(q => q.WanIpConnectionGetNatRsipStatusAsync());
    }

    private async Task GetWanIpConnectionGetDnsServersAsync()
    {
        WanConnectionGetDnsServersResponse = await ExecuteApiAsync(q => q.WanIpConnectionGetDnsServersAsync());
    }

    private async Task GetWanIpConnectionGetPortMappingNumberOfEntriesAsync()
    {
        WanConnectionGetPortMappingNumberOfEntriesResponse = await ExecuteApiAsync(q => q.WanIpConnectionGetPortMappingNumberOfEntriesAsync());
    }

    private async Task GetWanIpConnectionGetExternalIpAddressAsync()
    {
        WanConnectionGetExternalIpAddressResponse = await ExecuteApiAsync(q => q.WanIpConnectionGetExternalIpAddressAsync());
    }
}