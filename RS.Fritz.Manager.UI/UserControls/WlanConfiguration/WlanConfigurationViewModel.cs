namespace RS.Fritz.Manager.UI;

using System.Windows;

internal sealed class WlanConfigurationViewModel(DeviceLoginInfo deviceLoginInfo, IWlanDeviceService wlanDeviceService, ILogger logger)
    : FritzServiceViewModel(deviceLoginInfo, logger, "WLANConfiguration")
{
    private WlanDeviceInfo? wlanDeviceInfo;
    private KeyValuePair<WlanConfigurationGetInfoResponse?, UPnPFault?>?[]? wlanConfigurationGetInfoResponses;
    private KeyValuePair<WlanConfigurationGetBasBeaconSecurityPropertiesResponse?, UPnPFault?>?[]? wlanConfigurationGetBasBeaconSecurityPropertiesResponses;
    private KeyValuePair<WlanConfigurationGetBssIdResponse?, UPnPFault?>?[]? wlanConfigurationGetBssIdResponses;
    private KeyValuePair<WlanConfigurationGetSsIdResponse?, UPnPFault?>?[]? wlanConfigurationGetSsIdResponses;
    private KeyValuePair<WlanConfigurationGetBeaconTypeResponse?, UPnPFault?>?[]? wlanConfigurationGetBeaconTypeResponses;
    private KeyValuePair<WlanConfigurationGetChannelInfoResponse?, UPnPFault?>?[]? wlanConfigurationGetChannelInfoResponses;
    private KeyValuePair<WlanConfigurationGetBeaconAdvertisementResponse?, UPnPFault?>?[]? wlanConfigurationGetBeaconAdvertisementResponses;
    private KeyValuePair<WlanConfigurationGetTotalAssociationsResponse?, UPnPFault?>?[]? wlanConfigurationGetTotalAssociationsResponses;
    private KeyValuePair<WlanConfigurationGetIpTvOptimizedResponse?, UPnPFault?>?[]? wlanConfigurationGetIpTvOptimizedResponses;
    private KeyValuePair<WlanConfigurationGetStatisticsResponse?, UPnPFault?>?[]? wlanConfigurationGetStatisticsResponses;
    private KeyValuePair<WlanConfigurationGetPacketStatisticsResponse?, UPnPFault?>?[]? wlanConfigurationGetPacketStatisticsResponses;
    private KeyValuePair<WlanConfigurationGetNightControlResponse?, UPnPFault?>?[]? wlanConfigurationGetNightControlResponses;
    private KeyValuePair<WlanConfigurationGetWlanHybridModeResponse?, UPnPFault?>?[]? wlanConfigurationGetWlanHybridModeResponses;
    private KeyValuePair<WlanConfigurationGetWlanExtInfoResponse?, UPnPFault?>?[]? wlanConfigurationGetWlanExtInfoResponses;
    private KeyValuePair<WlanConfigurationGetWpsInfoResponse?, UPnPFault?>?[]? wlanConfigurationGetWpsInfoResponses;
    private KeyValuePair<WlanConfigurationGetWlanConnectionInfoResponse?, UPnPFault?>?[]? wlanConfigurationGetWlanConnectionInfoResponses;
    private Visibility? interface2Visibility;
    private Visibility? interface3Visibility;
    private Visibility? interface4Visibility;

    public WlanDeviceInfo? WlanDeviceInfo
    {
        get => wlanDeviceInfo;
        private set => _ = SetProperty(ref wlanDeviceInfo, value);
    }

    public KeyValuePair<WlanConfigurationGetInfoResponse?, UPnPFault?>?[]? WlanConfigurationGetInfoResponses
    {
        get => wlanConfigurationGetInfoResponses;
        private set => _ = SetProperty(ref wlanConfigurationGetInfoResponses, value);
    }

    public KeyValuePair<WlanConfigurationGetBasBeaconSecurityPropertiesResponse?, UPnPFault?>?[]? WlanConfigurationGetBasBeaconSecurityPropertiesResponses
    {
        get => wlanConfigurationGetBasBeaconSecurityPropertiesResponses;
        private set => _ = SetProperty(ref wlanConfigurationGetBasBeaconSecurityPropertiesResponses, value);
    }

    public KeyValuePair<WlanConfigurationGetBssIdResponse?, UPnPFault?>?[]? WlanConfigurationGetBssIdResponses
    {
        get => wlanConfigurationGetBssIdResponses;
        private set => _ = SetProperty(ref wlanConfigurationGetBssIdResponses, value);
    }

    public KeyValuePair<WlanConfigurationGetSsIdResponse?, UPnPFault?>?[]? WlanConfigurationGetSsIdResponses
    {
        get => wlanConfigurationGetSsIdResponses;
        private set => _ = SetProperty(ref wlanConfigurationGetSsIdResponses, value);
    }

    public KeyValuePair<WlanConfigurationGetBeaconTypeResponse?, UPnPFault?>?[]? WlanConfigurationGetBeaconTypeResponses
    {
        get => wlanConfigurationGetBeaconTypeResponses;
        private set => _ = SetProperty(ref wlanConfigurationGetBeaconTypeResponses, value);
    }

    public KeyValuePair<WlanConfigurationGetChannelInfoResponse?, UPnPFault?>?[]? WlanConfigurationGetChannelInfoResponses
    {
        get => wlanConfigurationGetChannelInfoResponses;
        private set => _ = SetProperty(ref wlanConfigurationGetChannelInfoResponses, value);
    }

    public KeyValuePair<WlanConfigurationGetBeaconAdvertisementResponse?, UPnPFault?>?[]? WlanConfigurationGetBeaconAdvertisementResponses
    {
        get => wlanConfigurationGetBeaconAdvertisementResponses;
        private set => _ = SetProperty(ref wlanConfigurationGetBeaconAdvertisementResponses, value);
    }

    public KeyValuePair<WlanConfigurationGetTotalAssociationsResponse?, UPnPFault?>?[]? WlanConfigurationGetTotalAssociationsResponses
    {
        get => wlanConfigurationGetTotalAssociationsResponses;
        private set => _ = SetProperty(ref wlanConfigurationGetTotalAssociationsResponses, value);
    }

    public KeyValuePair<WlanConfigurationGetIpTvOptimizedResponse?, UPnPFault?>?[]? WlanConfigurationGetIpTvOptimizedResponses
    {
        get => wlanConfigurationGetIpTvOptimizedResponses;
        private set => _ = SetProperty(ref wlanConfigurationGetIpTvOptimizedResponses, value);
    }

    public KeyValuePair<WlanConfigurationGetStatisticsResponse?, UPnPFault?>?[]? WlanConfigurationGetStatisticsResponses
    {
        get => wlanConfigurationGetStatisticsResponses;
        private set => _ = SetProperty(ref wlanConfigurationGetStatisticsResponses, value);
    }

    public KeyValuePair<WlanConfigurationGetPacketStatisticsResponse?, UPnPFault?>?[]? WlanConfigurationGetPacketStatisticsResponses
    {
        get => wlanConfigurationGetPacketStatisticsResponses;
        private set => _ = SetProperty(ref wlanConfigurationGetPacketStatisticsResponses, value);
    }

    public KeyValuePair<WlanConfigurationGetNightControlResponse?, UPnPFault?>?[]? WlanConfigurationGetNightControlResponses
    {
        get => wlanConfigurationGetNightControlResponses;
        private set => _ = SetProperty(ref wlanConfigurationGetNightControlResponses, value);
    }

    public KeyValuePair<WlanConfigurationGetWlanHybridModeResponse?, UPnPFault?>?[]? WlanConfigurationGetWlanHybridModeResponses
    {
        get => wlanConfigurationGetWlanHybridModeResponses;
        private set => _ = SetProperty(ref wlanConfigurationGetWlanHybridModeResponses, value);
    }

    public KeyValuePair<WlanConfigurationGetWlanExtInfoResponse?, UPnPFault?>?[]? WlanConfigurationGetWlanExtInfoResponses
    {
        get => wlanConfigurationGetWlanExtInfoResponses;
        private set => _ = SetProperty(ref wlanConfigurationGetWlanExtInfoResponses, value);
    }

    public KeyValuePair<WlanConfigurationGetWpsInfoResponse?, UPnPFault?>?[]? WlanConfigurationGetWpsInfoResponses
    {
        get => wlanConfigurationGetWpsInfoResponses;
        private set => _ = SetProperty(ref wlanConfigurationGetWpsInfoResponses, value);
    }

    public KeyValuePair<WlanConfigurationGetWlanConnectionInfoResponse?, UPnPFault?>?[]? WlanConfigurationGetWlanConnectionInfoResponses
    {
        get => wlanConfigurationGetWlanConnectionInfoResponses;
        private set => _ = SetProperty(ref wlanConfigurationGetWlanConnectionInfoResponses, value);
    }

    public Visibility Interface2Visibility => interface2Visibility ??= HasWlanConfigurationService(2) ? Visibility.Visible : Visibility.Hidden;

    public Visibility Interface3Visibility => interface3Visibility ??= HasWlanConfigurationService(3) ? Visibility.Visible : Visibility.Hidden;

    public Visibility Interface4Visibility => interface4Visibility ??= HasWlanConfigurationService(4) ? Visibility.Visible : Visibility.Hidden;

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        return API.TaskExtensions.WhenAllSafe(
            new[]
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
            },
            true);
    }

    private async Task GetWlanConfigurationGetHostListPathAsync(CancellationToken cancellationToken)
        => WlanDeviceInfo = await wlanDeviceService.GetWlanDevicesAsync(ApiDevice, cancellationToken).ConfigureAwait(true);

    private async Task GetWlanConfigurationGetInfoAsync()
        => WlanConfigurationGetInfoResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetInfoAsync(i)).ConfigureAwait(true);

    private async Task GetWlanConfigurationGetBasBeaconSecurityPropertiesAsync()
        => WlanConfigurationGetBasBeaconSecurityPropertiesResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetBasBeaconSecurityPropertiesAsync(i)).ConfigureAwait(true);

    private async Task GetWlanConfigurationGetBssIdAsync()
        => WlanConfigurationGetBssIdResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetBssIdAsync(i)).ConfigureAwait(true);

    private async Task GetWlanConfigurationGetSsIdAsync()
        => WlanConfigurationGetSsIdResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetSsIdAsync(i)).ConfigureAwait(true);

    private async Task GetWlanConfigurationGetBeaconTypeAsync()
        => WlanConfigurationGetBeaconTypeResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetBeaconTypeAsync(i)).ConfigureAwait(true);

    private async Task GetWlanConfigurationGetChannelInfoAsync()
        => WlanConfigurationGetChannelInfoResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetChannelInfoAsync(i)).ConfigureAwait(true);

    private async Task GetWlanConfigurationGetBeaconAdvertisementAsync()
        => WlanConfigurationGetBeaconAdvertisementResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetBeaconAdvertisementAsync(i)).ConfigureAwait(true);

    private async Task GetWlanConfigurationGetTotalAssociationsAsync()
        => WlanConfigurationGetTotalAssociationsResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetTotalAssociationsAsync(i)).ConfigureAwait(true);

    private async Task GetWlanConfigurationGetIpTvOptimizedAsync()
        => WlanConfigurationGetIpTvOptimizedResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetIpTvOptimizedAsync(i)).ConfigureAwait(true);

    private async Task GetWlanConfigurationGetStatisticsAsync()
        => WlanConfigurationGetStatisticsResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetStatisticsAsync(i)).ConfigureAwait(true);

    private async Task GetWlanConfigurationGetPacketStatisticsAsync()
        => WlanConfigurationGetPacketStatisticsResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetPacketStatisticsAsync(i)).ConfigureAwait(true);

    private async Task GetWlanConfigurationGetNightControlAsync()
        => WlanConfigurationGetNightControlResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetNightControlAsync(i)).ConfigureAwait(true);

    private async Task GetWlanConfigurationGetWlanHybridModeAsync()
        => WlanConfigurationGetWlanHybridModeResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetWlanHybridModeAsync(i)).ConfigureAwait(true);

    private async Task GetWlanConfigurationGetWlanExtInfoAsync()
        => WlanConfigurationGetWlanExtInfoResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetWlanExtInfoAsync(i)).ConfigureAwait(true);

    private async Task GetWlanConfigurationGetWpsInfoAsync()
        => WlanConfigurationGetWpsInfoResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetWpsInfoAsync(i)).ConfigureAwait(true);

    private async Task GetWlanConfigurationGetWlanConnectionInfoAsync()
        => WlanConfigurationGetWlanConnectionInfoResponses = await ExecuteApiWlanConfigurationAsync((q, i) => q.WlanConfigurationGetWlanConnectionInfoAsync(i), new Dictionary<ushort, string> { { 714, "Current device is not directly connected to any of the access points." } }).ConfigureAwait(true);

    private async ValueTask<KeyValuePair<T?, UPnPFault?>?[]> ExecuteApiWlanConfigurationAsync<T>(Func<InternetGatewayDevice, int, Task<T>> operation, IDictionary<ushort, string>? errorReasons = null)
        where T : struct
    {
        var responses = new KeyValuePair<T?, UPnPFault?>?[4];

        for (int i = 0; i < 4; i++)
        {
            if (HasWlanConfigurationService(i + 1))
                responses[i] = await ExecuteApiAsync(operation, i + 1, errorReasons).ConfigureAwait(true);
        }

        return responses;
    }

    private bool HasWlanConfigurationService(int interfaceNumber)
        => ApiDevice.Services.Any(r => FormattableString.Invariant($"urn:dslforum-org:service:WLANConfiguration:{interfaceNumber}").Equals(r.ServiceType, StringComparison.OrdinalIgnoreCase));
}