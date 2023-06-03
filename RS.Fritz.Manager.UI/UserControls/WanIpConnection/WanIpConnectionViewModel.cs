namespace RS.Fritz.Manager.UI;

using System.Collections.ObjectModel;

internal sealed class WanIpConnectionViewModel : WanAccessTypeAwareFritzServiceViewModel
{
    private KeyValuePair<WanIpConnectionGetInfoResponse?, UPnPFault?>? wanIpConnectionGetInfoResponse;
    private KeyValuePair<WanConnectionGetConnectionTypeInfoResponse?, UPnPFault?>? wanConnectionGetConnectionTypeInfoResponse;
    private KeyValuePair<WanConnectionGetStatusInfoResponse?, UPnPFault?>? wanConnectionGetStatusInfoResponse;
    private KeyValuePair<WanConnectionGetNatRsipStatusResponse?, UPnPFault?>? wanConnectionGetNatRsipStatusResponse;
    private KeyValuePair<WanConnectionGetDnsServersResponse?, UPnPFault?>? wanConnectionGetDnsServersResponse;
    private KeyValuePair<WanConnectionGetPortMappingNumberOfEntriesResponse?, UPnPFault?>? wanConnectionGetPortMappingNumberOfEntriesResponse;
    private KeyValuePair<WanConnectionGetExternalIpAddressResponse?, UPnPFault?>? wanConnectionGetExternalIpAddressResponse;
    private ObservableCollection<WanConnectionGetGenericPortMappingEntryResponse>? wanConnectionGetGenericPortMappingEntryResponses;

    public WanIpConnectionViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, WanIpConnectionGetGenericPortMappingEntryViewModel wanIpConnectionGetGenericPortMappingEntryViewModel)
        : base(deviceLoginInfo, logger, WanAccessType.Ethernet, "WANIPConnection")
    {
        WanIpConnectionGetGenericPortMappingEntryViewModel = wanIpConnectionGetGenericPortMappingEntryViewModel;
    }

    public WanIpConnectionGetGenericPortMappingEntryViewModel WanIpConnectionGetGenericPortMappingEntryViewModel { get; }

    public KeyValuePair<WanIpConnectionGetInfoResponse?, UPnPFault?>? WanIpConnectionGetInfoResponse
    {
        get => wanIpConnectionGetInfoResponse;
        private set { _ = SetProperty(ref wanIpConnectionGetInfoResponse, value); }
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
                WanIpConnectionGetGenericPortMappingEntryViewModel.PortMappingNumberOfEntries = WanConnectionGetPortMappingNumberOfEntriesResponse?.Key!.Value.PortMappingNumberOfEntries;
        }
    }

    public KeyValuePair<WanConnectionGetExternalIpAddressResponse?, UPnPFault?>? WanConnectionGetExternalIpAddressResponse
    {
        get => wanConnectionGetExternalIpAddressResponse;
        private set { _ = SetProperty(ref wanConnectionGetExternalIpAddressResponse, value); }
    }

    public ObservableCollection<WanConnectionGetGenericPortMappingEntryResponse>? WanConnectionGetGenericPortMappingEntryResponses
    {
        get => wanConnectionGetGenericPortMappingEntryResponses;
        private set { _ = SetProperty(ref wanConnectionGetGenericPortMappingEntryResponses, value); }
    }

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        return API.TaskExtensions.WhenAllSafe(new[]
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

        ushort numberOfEntries = WanConnectionGetPortMappingNumberOfEntriesResponse!.Value.Key!.Value.PortMappingNumberOfEntries;
        var tasks = new List<Task<KeyValuePair<WanConnectionGetGenericPortMappingEntryResponse?, UPnPFault?>>>();

        for (ushort i = 0; i < numberOfEntries; i++)
        {
            ushort capturedIndex = i;

            tasks.Add(ExecuteApiAsync(q => q.WanIpConnectionGetGenericPortMappingEntryAsync(new(capturedIndex))));
        }

        KeyValuePair<WanConnectionGetGenericPortMappingEntryResponse?, UPnPFault?>[] responses = await API.TaskExtensions.WhenAllSafe(tasks);

        WanConnectionGetGenericPortMappingEntryResponses = new(responses.Select(q => q.Key!.Value));
    }

    private async Task GetWanIpConnectionGetExternalIpAddressAsync()
    {
        WanConnectionGetExternalIpAddressResponse = await ExecuteApiAsync(q => q.WanIpConnectionGetExternalIpAddressAsync());
    }
}