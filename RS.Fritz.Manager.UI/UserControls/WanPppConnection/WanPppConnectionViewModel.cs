namespace RS.Fritz.Manager.UI;

using System.Collections.ObjectModel;

internal sealed class WanPppConnectionViewModel : WanAccessTypeAwareFritzServiceViewModel
{
    private KeyValuePair<WanPppConnectionGetInfoResponse?, UPnPFault?>? wanPppConnectionGetInfoResponse;
    private KeyValuePair<WanConnectionGetConnectionTypeInfoResponse?, UPnPFault?>? wanConnectionGetConnectionTypeInfoResponse;
    private KeyValuePair<WanConnectionGetStatusInfoResponse?, UPnPFault?>? wanConnectionGetStatusInfoResponse;
    private KeyValuePair<WanPppConnectionGetLinkLayerMaxBitRatesResponse?, UPnPFault?>? wanPppConnectionGetLinkLayerMaxBitRatesResponse;
    private KeyValuePair<WanPppConnectionGetUserNameResponse?, UPnPFault?>? wanPppConnectionGetUserNameResponse;
    private KeyValuePair<WanConnectionGetNatRsipStatusResponse?, UPnPFault?>? wanConnectionGetNatRsipStatusResponse;
    private KeyValuePair<WanConnectionGetDnsServersResponse?, UPnPFault?>? wanConnectionGetDnsServersResponse;
    private KeyValuePair<WanConnectionGetPortMappingNumberOfEntriesResponse?, UPnPFault?>? wanConnectionGetPortMappingNumberOfEntriesResponse;
    private KeyValuePair<WanConnectionGetExternalIpAddressResponse?, UPnPFault?>? wanConnectionGetExternalIpAddressResponse;
    private KeyValuePair<WanPppConnectionGetAutoDisconnectTimeSpanResponse?, UPnPFault?>? wanPppConnectionGetAutoDisconnectTimeSpanResponse;
    private ObservableCollection<WanConnectionGetGenericPortMappingEntryResponse>? wanConnectionGetGenericPortMappingEntryResponses;

    public WanPppConnectionViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, WanPppConnectionGetGenericPortMappingEntryViewModel wanPppConnectionGetGenericPortMappingEntryViewModel)
        : base(deviceLoginInfo, logger, WanAccessType.Dsl, "WANPPPConnection")
    {
        WanPppConnectionGetGenericPortMappingEntryViewModel = wanPppConnectionGetGenericPortMappingEntryViewModel;
    }

    public WanPppConnectionGetGenericPortMappingEntryViewModel WanPppConnectionGetGenericPortMappingEntryViewModel { get; }

    public KeyValuePair<WanPppConnectionGetInfoResponse?, UPnPFault?>? WanPppConnectionGetInfoResponse
    {
        get => wanPppConnectionGetInfoResponse;
        private set { _ = SetProperty(ref wanPppConnectionGetInfoResponse, value); }
    }

    public KeyValuePair<WanConnectionGetConnectionTypeInfoResponse?, UPnPFault?>? WanConnectionGetConnectionTypeInfoResponse
    {
        get => wanConnectionGetConnectionTypeInfoResponse;
        private set { _ = SetProperty(ref wanConnectionGetConnectionTypeInfoResponse, value); }
    }

    public KeyValuePair<WanConnectionGetStatusInfoResponse?, UPnPFault?>? WanConnectionGetStatusInfoResponse
    {
        get => wanConnectionGetStatusInfoResponse;
        private set { _ = SetProperty(ref wanConnectionGetStatusInfoResponse, value); }
    }

    public KeyValuePair<WanPppConnectionGetLinkLayerMaxBitRatesResponse?, UPnPFault?>? WanPppConnectionGetLinkLayerMaxBitRatesResponse
    {
        get => wanPppConnectionGetLinkLayerMaxBitRatesResponse;
        private set { _ = SetProperty(ref wanPppConnectionGetLinkLayerMaxBitRatesResponse, value); }
    }

    public KeyValuePair<WanPppConnectionGetUserNameResponse?, UPnPFault?>? WanPppConnectionGetUserNameResponse
    {
        get => wanPppConnectionGetUserNameResponse;
        private set { _ = SetProperty(ref wanPppConnectionGetUserNameResponse, value); }
    }

    public KeyValuePair<WanConnectionGetNatRsipStatusResponse?, UPnPFault?>? WanConnectionGetNatRsipStatusResponse
    {
        get => wanConnectionGetNatRsipStatusResponse;
        private set { _ = SetProperty(ref wanConnectionGetNatRsipStatusResponse, value); }
    }

    public KeyValuePair<WanConnectionGetDnsServersResponse?, UPnPFault?>? WanConnectionGetDnsServersResponse
    {
        get => wanConnectionGetDnsServersResponse;
        private set { _ = SetProperty(ref wanConnectionGetDnsServersResponse, value); }
    }

    public KeyValuePair<WanConnectionGetPortMappingNumberOfEntriesResponse?, UPnPFault?>? WanConnectionGetPortMappingNumberOfEntriesResponse
    {
        get => wanConnectionGetPortMappingNumberOfEntriesResponse;
        private set
        {
            if (SetProperty(ref wanConnectionGetPortMappingNumberOfEntriesResponse, value))
                WanPppConnectionGetGenericPortMappingEntryViewModel.PortMappingNumberOfEntries = WanConnectionGetPortMappingNumberOfEntriesResponse?.Key!.Value.PortMappingNumberOfEntries;
        }
    }

    public KeyValuePair<WanConnectionGetExternalIpAddressResponse?, UPnPFault?>? WanConnectionGetExternalIpAddressResponse
    {
        get => wanConnectionGetExternalIpAddressResponse;
        private set { _ = SetProperty(ref wanConnectionGetExternalIpAddressResponse, value); }
    }

    public KeyValuePair<WanPppConnectionGetAutoDisconnectTimeSpanResponse?, UPnPFault?>? WanPppConnectionGetAutoDisconnectTimeSpanResponse
    {
        get => wanPppConnectionGetAutoDisconnectTimeSpanResponse;
        private set { _ = SetProperty(ref wanPppConnectionGetAutoDisconnectTimeSpanResponse, value); }
    }

    public ObservableCollection<WanConnectionGetGenericPortMappingEntryResponse>? WanConnectionGetGenericPortMappingEntryResponses
    {
        get => wanConnectionGetGenericPortMappingEntryResponses;
        private set { _ = SetProperty(ref wanConnectionGetGenericPortMappingEntryResponses, value); }
    }

    protected override Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        return API.TaskExtensions.WhenAllSafe(new[]
          {
                GetWanPppConnectionGetInfoAsync(),
                GetWanPppConnectionGetConnectionTypeInfoAsync(),
                GetWanPppConnectionGetStatusInfoAsync(),
                GetWanPppConnectionGetLinkLayerMaxBitRatesAsync(),
                GetWanPppConnectionGetUserNameAsync(),
                GetWanPppConnectionGetNatRsipStatusAsync(),
                GetWanPppConnectionGetDnsServersAsync(),
                GetWanPppConnectionGetPortMappingNumberOfEntriesAsync(),
                GetWanPppConnectionGetExternalIpAddressAsync(),
                GetWanPppConnectionGetAutoDisconnectTimeSpanAsync()
          });
    }

    private async Task GetWanPppConnectionGetInfoAsync()
    {
        WanPppConnectionGetInfoResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetInfoAsync());
    }

    private async Task GetWanPppConnectionGetConnectionTypeInfoAsync()
    {
        WanConnectionGetConnectionTypeInfoResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetConnectionTypeInfoAsync());
    }

    private async Task GetWanPppConnectionGetStatusInfoAsync()
    {
        WanConnectionGetStatusInfoResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetStatusInfoAsync());
    }

    private async Task GetWanPppConnectionGetLinkLayerMaxBitRatesAsync()
    {
        WanPppConnectionGetLinkLayerMaxBitRatesResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetLinkLayerMaxBitRatesAsync());
    }

    private async Task GetWanPppConnectionGetUserNameAsync()
    {
        WanPppConnectionGetUserNameResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetUserNameAsync());
    }

    private async Task GetWanPppConnectionGetNatRsipStatusAsync()
    {
        WanConnectionGetNatRsipStatusResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetNatRsipStatusAsync());
    }

    private async Task GetWanPppConnectionGetDnsServersAsync()
    {
        WanConnectionGetDnsServersResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetDnsServersAsync());
    }

    private async Task GetWanPppConnectionGetPortMappingNumberOfEntriesAsync()
    {
        WanConnectionGetPortMappingNumberOfEntriesResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetPortMappingNumberOfEntriesAsync());

        ushort numberOfEntries = WanConnectionGetPortMappingNumberOfEntriesResponse!.Value.Key!.Value.PortMappingNumberOfEntries;
        var tasks = new List<Task<KeyValuePair<WanConnectionGetGenericPortMappingEntryResponse?, UPnPFault?>>>();

        for (ushort i = 0; i < numberOfEntries; i++)
        {
            ushort capturedIndex = i;

            tasks.Add(ExecuteApiAsync(q => q.WanPppConnectionGetGenericPortMappingEntryAsync(new WanConnectionGetGenericPortMappingEntryRequest(capturedIndex))));
        }

        KeyValuePair<WanConnectionGetGenericPortMappingEntryResponse?, UPnPFault?>[] responses = await API.TaskExtensions.WhenAllSafe(tasks);

        WanConnectionGetGenericPortMappingEntryResponses = new ObservableCollection<WanConnectionGetGenericPortMappingEntryResponse>(responses.Select(q => q.Key!.Value));
    }

    private async Task GetWanPppConnectionGetExternalIpAddressAsync()
    {
        WanConnectionGetExternalIpAddressResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetExternalIpAddressAsync());
    }

    private async Task GetWanPppConnectionGetAutoDisconnectTimeSpanAsync()
    {
        WanPppConnectionGetAutoDisconnectTimeSpanResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetAutoDisconnectTimeSpanAsync());
    }
}