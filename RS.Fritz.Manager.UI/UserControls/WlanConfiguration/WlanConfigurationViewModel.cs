namespace RS.Fritz.Manager.UI;

internal sealed class WlanConfigurationViewModel : FritzServiceViewModel
{
    private readonly IWlanDeviceService wlanDeviceService;

    private WlanConfigurationGetInfoResponse? wlanConfiguration1GetInfoResponse;
    private WlanConfigurationGetInfoResponse? wlanConfiguration2GetInfoResponse;
    private WlanConfigurationGetInfoResponse? wlanConfiguration3GetInfoResponse;
    private WlanConfigurationGetInfoResponse? wlanConfiguration4GetInfoResponse;
    private WlanDeviceInfo? wlanDeviceInfo;

    public WlanConfigurationViewModel(DeviceLoginInfo deviceLoginInfo, IWlanDeviceService wlanDeviceService, ILogger logger)
        : base(deviceLoginInfo, logger, "WLANConfiguration")
    {
        this.wlanDeviceService = wlanDeviceService;
    }

    public WlanConfigurationGetInfoResponse? WlanConfiguration1GetInfoResponse
    {
        get => wlanConfiguration1GetInfoResponse;
        private set { _ = SetProperty(ref wlanConfiguration1GetInfoResponse, value); }
    }

    public WlanConfigurationGetInfoResponse? WlanConfiguration2GetInfoResponse
    {
        get => wlanConfiguration2GetInfoResponse;
        private set { _ = SetProperty(ref wlanConfiguration2GetInfoResponse, value); }
    }

    public WlanConfigurationGetInfoResponse? WlanConfiguration3GetInfoResponse
    {
        get => wlanConfiguration3GetInfoResponse;
        private set { _ = SetProperty(ref wlanConfiguration3GetInfoResponse, value); }
    }

    public WlanConfigurationGetInfoResponse? WlanConfiguration4GetInfoResponse
    {
        get => wlanConfiguration4GetInfoResponse;
        private set { _ = SetProperty(ref wlanConfiguration4GetInfoResponse, value); }
    }

    public WlanDeviceInfo? WlanDeviceInfo
    {
        get => wlanDeviceInfo;
        private set { _ = SetProperty(ref wlanDeviceInfo, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        await API.TaskExtensions.WhenAllSafe(new[]
          {
                GetWlanConfiguration1GetInfoAsync(),
                GetWlanConfiguration2GetInfoAsync(),
                GetWlanConfiguration3GetInfoAsync(),
                GetWlanConfiguration4GetInfoAsync(),
                GetWlanConfigurationGetHostListPathAsync(cancellationToken)
          });
    }

    private async Task GetWlanConfiguration1GetInfoAsync()
    {
        if (ApiDevice.Services.Any(r => r.ServiceType is "urn:dslforum-org:service:WLANConfiguration:1"))
            WlanConfiguration1GetInfoResponse = await ExecuteApiAsync(q => q.WlanConfiguration1GetInfoAsync());
    }

    private async Task GetWlanConfiguration2GetInfoAsync()
    {
        if (ApiDevice.Services.Any(r => r.ServiceType is "urn:dslforum-org:service:WLANConfiguration:2"))
            WlanConfiguration2GetInfoResponse = await ExecuteApiAsync(q => q.WlanConfiguration2GetInfoAsync());
    }

    private async Task GetWlanConfiguration3GetInfoAsync()
    {
        if (ApiDevice.Services.Any(r => r.ServiceType is "urn:dslforum-org:service:WLANConfiguration:3"))
            WlanConfiguration3GetInfoResponse = await ExecuteApiAsync(q => q.WlanConfiguration3GetInfoAsync());
    }

    private async Task GetWlanConfiguration4GetInfoAsync()
    {
        if (ApiDevice.Services.Any(r => r.ServiceType is "urn:dslforum-org:service:WLANConfiguration:4"))
            WlanConfiguration4GetInfoResponse = await ExecuteApiAsync(q => q.WlanConfiguration4GetInfoAsync());
    }

    private async Task GetWlanConfigurationGetHostListPathAsync(CancellationToken cancellationToken)
    {
        WlanDeviceInfo = await wlanDeviceService.GetWlanDevicesAsync(ApiDevice, cancellationToken);
    }
}