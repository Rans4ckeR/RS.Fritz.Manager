namespace RS.Fritz.Manager.UI;

using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

internal sealed class WanPppConnectionViewModel : FritzServiceViewModel, IRecipient<PropertyChangedMessage<WanAccessType?>>
{
    private WanPppConnectionGetInfoResponse? wanPppConnectionGetInfoResponse;
    private WanPppConnectionGetConnectionTypeInfoResponse? wanPppConnectionGetConnectionTypeInfoResponse;
    private WanPppConnectionGetStatusInfoResponse? wanPppConnectionGetStatusInfoResponse;
    private WanPppConnectionGetLinkLayerMaxBitRatesResponse? wanPppConnectionGetLinkLayerMaxBitRatesResponse;
    private WanPppConnectionGetUserNameResponse? wanPppConnectionGetUserNameResponse;
    private WanPppConnectionGetNatRsipStatusResponse? wanPppConnectionGetNatRsipStatusResponse;

    public WanPppConnectionViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
    }

    public WanPppConnectionGetInfoResponse? WanPppConnectionGetInfoResponse
    {
        get => wanPppConnectionGetInfoResponse;
        private set { _ = SetProperty(ref wanPppConnectionGetInfoResponse, value); }
    }

    public WanPppConnectionGetConnectionTypeInfoResponse? WanPppConnectionGetConnectionTypeInfoResponse
    {
        get => wanPppConnectionGetConnectionTypeInfoResponse;
        private set { _ = SetProperty(ref wanPppConnectionGetConnectionTypeInfoResponse, value); }
    }

    public WanPppConnectionGetStatusInfoResponse? WanPppConnectionGetStatusInfoResponse
    {
        get => wanPppConnectionGetStatusInfoResponse;
        private set { _ = SetProperty(ref wanPppConnectionGetStatusInfoResponse, value); }
    }

    public WanPppConnectionGetLinkLayerMaxBitRatesResponse? WanPppConnectionGetLinkLayerMaxBitRatesResponse
    {
        get => wanPppConnectionGetLinkLayerMaxBitRatesResponse;
        private set { _ = SetProperty(ref wanPppConnectionGetLinkLayerMaxBitRatesResponse, value); }
    }

    public WanPppConnectionGetUserNameResponse? WanPppConnectionGetUserNameResponse
    {
        get => wanPppConnectionGetUserNameResponse;
        private set { _ = SetProperty(ref wanPppConnectionGetUserNameResponse, value); }
    }

    public WanPppConnectionGetNatRsipStatusResponse? WanPppConnectionGetNatRsipStatusResponse
    {
        get => wanPppConnectionGetNatRsipStatusResponse;
        private set { _ = SetProperty(ref wanPppConnectionGetNatRsipStatusResponse, value); }
    }

    public void Receive(PropertyChangedMessage<WanAccessType?> message)
    {
        if (message.Sender != DeviceLoginInfo.InternetGatewayDevice)
            return;

        switch (message.PropertyName)
        {
            case nameof(ObservableInternetGatewayDevice.WanAccessType):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }

    protected override async Task DoExecuteDefaultCommandAsync()
    {
        await API.TaskExtensions.WhenAllSafe(new[]
          {
                GetWanPppConnectionGetInfoAsync(),
                GetWanPppConnectionGetConnectionTypeInfoAsync(),
                GetWanPppConnectionGetStatusInfoAsync(),
                GetWanPppConnectionGetLinkLayerMaxBitRatesAsync(),
                GetWanPppConnectionGetUserNameResponseAsync(),
                GetWanPppConnectionGetNatRsipStatusResponseAsync()
          });
    }

    protected override bool GetCanExecuteDefaultCommand()
    {
        return base.GetCanExecuteDefaultCommand() && DeviceLoginInfo.InternetGatewayDevice!.WanAccessType == WanAccessType.Dsl;
    }

    private async Task GetWanPppConnectionGetInfoAsync()
    {
        WanPppConnectionGetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanPppConnectionGetInfoAsync();
    }

    private async Task GetWanPppConnectionGetConnectionTypeInfoAsync()
    {
        WanPppConnectionGetConnectionTypeInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanPppConnectionGetConnectionTypeInfoAsync();
    }

    private async Task GetWanPppConnectionGetStatusInfoAsync()
    {
        WanPppConnectionGetStatusInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanPppConnectionGetStatusInfoAsync();
    }

    private async Task GetWanPppConnectionGetLinkLayerMaxBitRatesAsync()
    {
        WanPppConnectionGetLinkLayerMaxBitRatesResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanPppConnectionGetLinkLayerMaxBitRatesAsync();
    }

    private async Task GetWanPppConnectionGetUserNameResponseAsync()
    {
        WanPppConnectionGetUserNameResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanPppConnectionGetUserNameAsync();
    }

    private async Task GetWanPppConnectionGetNatRsipStatusResponseAsync()
    {
        WanPppConnectionGetNatRsipStatusResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanPppConnectionGetNatRsipStatusAsync();
    }
}