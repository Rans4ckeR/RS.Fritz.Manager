namespace RS.Fritz.Manager.UI;

internal sealed class WlanConfigurationViewModel : FritzServiceViewModel
{
    private WlanConfigurationGetInfoResponse? wlanConfiguration1GetInfoResponse;
    private WlanConfigurationGetInfoResponse? wlanConfiguration2GetInfoResponse;
    private WlanConfigurationGetInfoResponse? wlanConfiguration3GetInfoResponse;
    private WlanConfigurationGetInfoResponse? wlanConfiguration4GetInfoResponse;

    public WlanConfigurationViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "WLANConfiguration")
    {
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

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        await API.TaskExtensions.WhenAllSafe(new[]
          {
                GetWlanConfiguration1GetInfoAsync(),
                GetWlanConfiguration2GetInfoAsync(),
                GetWlanConfiguration3GetInfoAsync(),
                GetWlanConfiguration4GetInfoAsync()
          });
    }

    private async Task GetWlanConfiguration1GetInfoAsync()
    {
        if (DeviceLoginInfo.InternetGatewayDevice!.UPnPDescription!.Value.Device.GetServices().Any(r => r.ServiceType is "urn:dslforum-org:service:WLANConfiguration:1"))
            WlanConfiguration1GetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WlanConfiguration1GetInfoAsync();
    }

    private async Task GetWlanConfiguration2GetInfoAsync()
    {
        if (DeviceLoginInfo.InternetGatewayDevice!.UPnPDescription!.Value.Device.GetServices().Any(r => r.ServiceType is "urn:dslforum-org:service:WLANConfiguration:2"))
            WlanConfiguration2GetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WlanConfiguration2GetInfoAsync();
    }

    private async Task GetWlanConfiguration3GetInfoAsync()
    {
        if (DeviceLoginInfo.InternetGatewayDevice!.UPnPDescription!.Value.Device.GetServices().Any(r => r.ServiceType is "urn:dslforum-org:service:WLANConfiguration:3"))
            WlanConfiguration3GetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WlanConfiguration3GetInfoAsync();
    }

    private async Task GetWlanConfiguration4GetInfoAsync()
    {
        if (DeviceLoginInfo.InternetGatewayDevice!.UPnPDescription!.Value.Device.GetServices().Any(r => r.ServiceType is "urn:dslforum-org:service:WLANConfiguration:4"))
            WlanConfiguration4GetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WlanConfiguration4GetInfoAsync();
    }
}