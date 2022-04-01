namespace RS.Fritz.Manager.UI;

internal sealed class WlanConfigurationViewModel : FritzServiceViewModel
{
    private readonly IWlanDeviceService wlanDeviceService;

    private WlanDeviceInfo? wlanDeviceInfo;
    private WlanConfigurationGetInfoResponse?[]? wlanConfigurationGetInfoResponses;
    private WlanConfigurationGetBasBeaconSecurityPropertiesResponse?[]? wlanConfigurationGetBasBeaconSecurityPropertiesResponses;
    private WlanConfigurationGetBssIdResponse?[]? wlanConfigurationGetBssIdResponses;
    private WlanConfigurationGetSsIdResponse?[]? wlanConfigurationGetSsIdResponses;
    private WlanConfigurationGetBeaconTypeResponse?[]? wlanConfigurationGetBeaconTypeResponses;
    private WlanConfigurationGetChannelInfoResponse?[]? wlanConfigurationGetChannelInfoResponses;
    private WlanConfigurationGetBeaconAdvertisementResponse?[]? wlanConfigurationGetBeaconAdvertisementResponses;
    private WlanConfigurationGetTotalAssociationsResponse?[]? wlanConfigurationGetTotalAssociationsResponses;
    private WlanConfigurationGetIpTvOptimizedResponse?[]? wlanConfigurationGetIpTvOptimizedResponses;
    private WlanConfigurationGetStatisticsResponse?[]? wlanConfigurationGetStatisticsResponses;
    private WlanConfigurationGetPacketStatisticsResponse?[]? wlanConfigurationGetPacketStatisticsResponses;
    private WlanConfigurationGetNightControlResponse?[]? wlanConfigurationGetNightControlResponses;
    private WlanConfigurationGetWlanHybridModeResponse?[]? wlanConfigurationGetWlanHybridModeResponses;
    private WlanConfigurationGetWlanExtInfoResponse?[]? wlanConfigurationGetWlanExtInfoResponses;
    private WlanConfigurationGetWpsInfoResponse?[]? wlanConfigurationGetWpsInfoResponses;
    private WlanConfigurationGetWlanConnectionInfoResponse?[]? wlanConfigurationGetWlanConnectionInfoResponses;

    public WlanConfigurationViewModel(DeviceLoginInfo deviceLoginInfo, IWlanDeviceService wlanDeviceService, ILogger logger)
        : base(deviceLoginInfo, logger, "WLANConfiguration")
    {
        this.wlanDeviceService = wlanDeviceService;
    }

    public WlanDeviceInfo? WlanDeviceInfo
    {
        get => wlanDeviceInfo;
        private set { _ = SetProperty(ref wlanDeviceInfo, value); }
    }

    public WlanConfigurationGetInfoResponse?[]? WlanConfigurationGetInfoResponses
    {
        get => wlanConfigurationGetInfoResponses;
        private set { _ = SetProperty(ref wlanConfigurationGetInfoResponses, value); }
    }

    public WlanConfigurationGetBasBeaconSecurityPropertiesResponse?[]? WlanConfigurationGetBasBeaconSecurityPropertiesResponses
    {
        get => wlanConfigurationGetBasBeaconSecurityPropertiesResponses;
        private set { _ = SetProperty(ref wlanConfigurationGetBasBeaconSecurityPropertiesResponses, value); }
    }

    public WlanConfigurationGetBssIdResponse?[]? WlanConfigurationGetBssIdResponses
    {
        get => wlanConfigurationGetBssIdResponses;
        private set { _ = SetProperty(ref wlanConfigurationGetBssIdResponses, value); }
    }

    public WlanConfigurationGetSsIdResponse?[]? WlanConfigurationGetSsIdResponses
    {
        get => wlanConfigurationGetSsIdResponses;
        private set { _ = SetProperty(ref wlanConfigurationGetSsIdResponses, value); }
    }

    public WlanConfigurationGetBeaconTypeResponse?[]? WlanConfigurationGetBeaconTypeResponses
    {
        get => wlanConfigurationGetBeaconTypeResponses;
        private set { _ = SetProperty(ref wlanConfigurationGetBeaconTypeResponses, value); }
    }

    public WlanConfigurationGetChannelInfoResponse?[]? WlanConfigurationGetChannelInfoResponses
    {
        get => wlanConfigurationGetChannelInfoResponses;
        private set { _ = SetProperty(ref wlanConfigurationGetChannelInfoResponses, value); }
    }

    public WlanConfigurationGetBeaconAdvertisementResponse?[]? WlanConfigurationGetBeaconAdvertisementResponses
    {
        get => wlanConfigurationGetBeaconAdvertisementResponses;
        private set { _ = SetProperty(ref wlanConfigurationGetBeaconAdvertisementResponses, value); }
    }

    public WlanConfigurationGetTotalAssociationsResponse?[]? WlanConfigurationGetTotalAssociationsResponses
    {
        get => wlanConfigurationGetTotalAssociationsResponses;
        private set { _ = SetProperty(ref wlanConfigurationGetTotalAssociationsResponses, value); }
    }

    public WlanConfigurationGetIpTvOptimizedResponse?[]? WlanConfigurationGetIpTvOptimizedResponses
    {
        get => wlanConfigurationGetIpTvOptimizedResponses;
        private set { _ = SetProperty(ref wlanConfigurationGetIpTvOptimizedResponses, value); }
    }

    public WlanConfigurationGetStatisticsResponse?[]? WlanConfigurationGetStatisticsResponses
    {
        get => wlanConfigurationGetStatisticsResponses;
        private set { _ = SetProperty(ref wlanConfigurationGetStatisticsResponses, value); }
    }

    public WlanConfigurationGetPacketStatisticsResponse?[]? WlanConfigurationGetPacketStatisticsResponses
    {
        get => wlanConfigurationGetPacketStatisticsResponses;
        private set { _ = SetProperty(ref wlanConfigurationGetPacketStatisticsResponses, value); }
    }

    public WlanConfigurationGetNightControlResponse?[]? WlanConfigurationGetNightControlResponses
    {
        get => wlanConfigurationGetNightControlResponses;
        private set { _ = SetProperty(ref wlanConfigurationGetNightControlResponses, value); }
    }

    public WlanConfigurationGetWlanHybridModeResponse?[]? WlanConfigurationGetWlanHybridModeResponses
    {
        get => wlanConfigurationGetWlanHybridModeResponses;
        private set { _ = SetProperty(ref wlanConfigurationGetWlanHybridModeResponses, value); }
    }

    public WlanConfigurationGetWlanExtInfoResponse?[]? WlanConfigurationGetWlanExtInfoResponses
    {
        get => wlanConfigurationGetWlanExtInfoResponses;
        private set { _ = SetProperty(ref wlanConfigurationGetWlanExtInfoResponses, value); }
    }

    public WlanConfigurationGetWpsInfoResponse?[]? WlanConfigurationGetWpsInfoResponses
    {
        get => wlanConfigurationGetWpsInfoResponses;
        private set { _ = SetProperty(ref wlanConfigurationGetWpsInfoResponses, value); }
    }

    public WlanConfigurationGetWlanConnectionInfoResponse?[]? WlanConfigurationGetWlanConnectionInfoResponses
    {
        get => wlanConfigurationGetWlanConnectionInfoResponses;
        private set { _ = SetProperty(ref wlanConfigurationGetWlanConnectionInfoResponses, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        await API.TaskExtensions.WhenAllSafe(new[]
          {
                GetWlanConfigurationGetHostListPathAsync(cancellationToken),
                GetWlanConfigurationGetInfoAsync(),
                GetWlanConfigurationGetBasBeaconSecurityPropertiesAsync(),
                GetWlanConfigurationGetBssIdAsync(),
                GetWlanConfigurationGetSsIdAsync(),
                GetWlanConfigurationGetBeaconTypeAsync(),
                GetWlanConfigurationGetChannelInfoAsync(),
                GetWlanConfigurationGetBeaconAdvertisementAsync(),
                GetWlanConfigurationGetTotalAssociationsAsync(),
                GetWlanConfigurationGetIpTvOptimizedAsync(),
                GetWlanConfigurationGetStatisticsAsync(),
                GetWlanConfigurationGetPacketStatisticsAsync(),
                GetWlanConfigurationGetNightControlAsync(),
                GetWlanConfigurationGetWlanHybridModeAsync(),
                GetWlanConfigurationGetWlanExtInfoAsync(),
                GetWlanConfigurationGetWpsInfoAsync(),
                GetWlanConfigurationGetWlanConnectionInfoAsync()
          });
    }

    private async Task GetWlanConfigurationGetHostListPathAsync(CancellationToken cancellationToken)
    {
        WlanDeviceInfo = await wlanDeviceService.GetWlanDevicesAsync(ApiDevice, cancellationToken);
    }

    private async Task GetWlanConfigurationGetInfoAsync()
    {
        WlanConfigurationGetInfoResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetInfoAsync(i));
    }

    private async Task GetWlanConfigurationGetBasBeaconSecurityPropertiesAsync()
    {
        WlanConfigurationGetBasBeaconSecurityPropertiesResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetBasBeaconSecurityPropertiesAsync(i));
    }

    private async Task GetWlanConfigurationGetBssIdAsync()
    {
        WlanConfigurationGetBssIdResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetBssIdAsync(i));
    }

    private async Task GetWlanConfigurationGetSsIdAsync()
    {
        WlanConfigurationGetSsIdResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetSsIdAsync(i));
    }

    private async Task GetWlanConfigurationGetBeaconTypeAsync()
    {
        WlanConfigurationGetBeaconTypeResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetBeaconTypeAsync(i));
    }

    private async Task GetWlanConfigurationGetChannelInfoAsync()
    {
        WlanConfigurationGetChannelInfoResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetChannelInfoAsync(i));
    }

    private async Task GetWlanConfigurationGetBeaconAdvertisementAsync()
    {
        WlanConfigurationGetBeaconAdvertisementResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetBeaconAdvertisementAsync(i));
    }

    private async Task GetWlanConfigurationGetTotalAssociationsAsync()
    {
        WlanConfigurationGetTotalAssociationsResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetTotalAssociationsAsync(i));
    }

    private async Task GetWlanConfigurationGetIpTvOptimizedAsync()
    {
        WlanConfigurationGetIpTvOptimizedResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetIpTvOptimizedAsync(i));
    }

    private async Task GetWlanConfigurationGetStatisticsAsync()
    {
        WlanConfigurationGetStatisticsResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetStatisticsAsync(i));
    }

    private async Task GetWlanConfigurationGetPacketStatisticsAsync()
    {
        WlanConfigurationGetPacketStatisticsResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetPacketStatisticsAsync(i));
    }

    private async Task GetWlanConfigurationGetNightControlAsync()
    {
        WlanConfigurationGetNightControlResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetNightControlAsync(i));
    }

    private async Task GetWlanConfigurationGetWlanHybridModeAsync()
    {
        WlanConfigurationGetWlanHybridModeResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetWlanHybridModeAsync(i));
    }

    private async Task GetWlanConfigurationGetWlanExtInfoAsync()
    {
        WlanConfigurationGetWlanExtInfoResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetWlanExtInfoAsync(i));
    }

    private async Task GetWlanConfigurationGetWpsInfoAsync()
    {
        WlanConfigurationGetWpsInfoResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetWpsInfoAsync(i));
    }

    private async Task GetWlanConfigurationGetWlanConnectionInfoAsync()
    {
        WlanConfigurationGetWlanConnectionInfoResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetWlanConnectionInfoAsync(i));
    }

    private async Task<T?[]> ExecuteApiWlanConfigurationAsync<T>(Func<InternetGatewayDevice, int, Task<T>> operation)
        where T : struct
    {
        var responses = new T?[4];

        for (int i = 0; i < 4; i++)
        {
            if (HasWlanConfigurationService(i + 1))
                responses[i] = await ExecuteApiAsync(operation, i + 1);
        }

        return responses;
    }

    private bool HasWlanConfigurationService(int interfaceNumber)
    {
        return ApiDevice.Services.Any(r => FormattableString.Invariant($"urn:dslforum-org:service:WLANConfiguration:{interfaceNumber}").Equals(r.ServiceType, StringComparison.OrdinalIgnoreCase));
    }
}