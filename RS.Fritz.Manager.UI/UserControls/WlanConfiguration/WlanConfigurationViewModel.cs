using System.Windows;

namespace RS.Fritz.Manager.UI;

internal sealed class WlanConfigurationViewModel(DeviceLoginInfo deviceLoginInfo, IWlanDeviceService wlanDeviceService, ILogger logger)
    : FritzServiceViewModel(deviceLoginInfo, logger, "WLANConfiguration")
{
    private Visibility? interface2Visibility;
    private Visibility? interface3Visibility;
    private Visibility? interface4Visibility;

    public WlanDeviceInfo? WlanDeviceInfo
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WlanConfigurationGetInfoResponse?, UPnPFault?>?[]? WlanConfigurationGetInfoResponses
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WlanConfigurationGetBasBeaconSecurityPropertiesResponse?, UPnPFault?>?[]? WlanConfigurationGetBasBeaconSecurityPropertiesResponses
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WlanConfigurationGetBssIdResponse?, UPnPFault?>?[]? WlanConfigurationGetBssIdResponses
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WlanConfigurationGetSsIdResponse?, UPnPFault?>?[]? WlanConfigurationGetSsIdResponses
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WlanConfigurationGetBeaconTypeResponse?, UPnPFault?>?[]? WlanConfigurationGetBeaconTypeResponses
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WlanConfigurationGetChannelInfoResponse?, UPnPFault?>?[]? WlanConfigurationGetChannelInfoResponses
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WlanConfigurationGetBeaconAdvertisementResponse?, UPnPFault?>?[]? WlanConfigurationGetBeaconAdvertisementResponses
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WlanConfigurationGetTotalAssociationsResponse?, UPnPFault?>?[]? WlanConfigurationGetTotalAssociationsResponses
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WlanConfigurationGetIpTvOptimizedResponse?, UPnPFault?>?[]? WlanConfigurationGetIpTvOptimizedResponses
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WlanConfigurationGetStatisticsResponse?, UPnPFault?>?[]? WlanConfigurationGetStatisticsResponses
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WlanConfigurationGetPacketStatisticsResponse?, UPnPFault?>?[]? WlanConfigurationGetPacketStatisticsResponses
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WlanConfigurationGetNightControlResponse?, UPnPFault?>?[]? WlanConfigurationGetNightControlResponses
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WlanConfigurationGetWlanHybridModeResponse?, UPnPFault?>?[]? WlanConfigurationGetWlanHybridModeResponses
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WlanConfigurationGetWlanExtInfoResponse?, UPnPFault?>?[]? WlanConfigurationGetWlanExtInfoResponses
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WlanConfigurationGetWpsInfoResponse?, UPnPFault?>?[]? WlanConfigurationGetWpsInfoResponses
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WlanConfigurationGetWlanConnectionInfoResponse?, UPnPFault?>?[]? WlanConfigurationGetWlanConnectionInfoResponses
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public Visibility Interface2Visibility => interface2Visibility ??= HasWlanConfigurationService(2) ? Visibility.Visible : Visibility.Hidden;

    public Visibility Interface3Visibility => interface3Visibility ??= HasWlanConfigurationService(3) ? Visibility.Visible : Visibility.Hidden;

    public Visibility Interface4Visibility => interface4Visibility ??= HasWlanConfigurationService(4) ? Visibility.Visible : Visibility.Hidden;

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => API.TaskExtensions.WhenAllSafe(
            [
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
            ],
            true);

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
        => ApiDevice.Services.Any(r => FormattableString.Invariant($"{UPnPConstants.AvmServiceNamespace}:WLANConfiguration:{interfaceNumber}").Equals(r.ServiceType, StringComparison.OrdinalIgnoreCase));
}