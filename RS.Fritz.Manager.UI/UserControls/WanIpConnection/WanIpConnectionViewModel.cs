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
        : base(deviceLoginInfo, logger, WanAccessType.Ethernet)
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

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken = default)
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
        WanIpConnectionGetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanIpConnectionGetInfoAsync();
    }

    private async Task GetWanIpConnectionGetConnectionTypeInfoAsync()
    {
        WanConnectionGetConnectionTypeInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanIpConnectionGetConnectionTypeInfoAsync();
    }

    private async Task GetWanIpConnectionGetStatusInfoAsync()
    {
        WanConnectionGetStatusInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanIpConnectionGetStatusInfoAsync();
    }

    private async Task GetWanIpConnectionGetNatRsipStatusAsync()
    {
        WanConnectionGetNatRsipStatusResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanIpConnectionGetNatRsipStatusAsync();
    }

    private async Task GetWanIpConnectionGetDnsServersAsync()
    {
        WanConnectionGetDnsServersResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanIpConnectionGetDnsServersAsync();
    }

    private async Task GetWanIpConnectionGetPortMappingNumberOfEntriesAsync()
    {
        WanConnectionGetPortMappingNumberOfEntriesResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanIpConnectionGetPortMappingNumberOfEntriesAsync();
    }

    private async Task GetWanIpConnectionGetExternalIpAddressAsync()
    {
        WanConnectionGetExternalIpAddressResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanIpConnectionGetExternalIpAddressAsync();
    }
}