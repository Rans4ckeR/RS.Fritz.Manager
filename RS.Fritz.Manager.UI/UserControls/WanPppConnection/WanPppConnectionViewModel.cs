namespace RS.Fritz.Manager.UI;

using System.Threading;
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
    private WanPppConnectionGetDnsServersResponse? wanPppConnectionGetDnsServersResponse;
    private WanPppConnectionGetPortMappingNumberOfEntriesResponse? wanPppConnectionGetPortMappingNumberOfEntriesResponse;
    private WanPppConnectionGetExternalIpAddressResponse? wanPppConnectionGetExternalIpAddressResponse;
    private WanPppConnectionGetAutoDisconnectTimeSpanResponse? wanPppConnectionGetAutoDisconnectTimeSpanResponse;

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

    public WanPppConnectionGetDnsServersResponse? WanPppConnectionGetDnsServersResponse
    {
        get => wanPppConnectionGetDnsServersResponse;
        private set { _ = SetProperty(ref wanPppConnectionGetDnsServersResponse, value); }
    }

    public WanPppConnectionGetPortMappingNumberOfEntriesResponse? WanPppConnectionGetPortMappingNumberOfEntriesResponse
    {
        get => wanPppConnectionGetPortMappingNumberOfEntriesResponse;
        private set { _ = SetProperty(ref wanPppConnectionGetPortMappingNumberOfEntriesResponse, value); }
    }

    public WanPppConnectionGetExternalIpAddressResponse? WanPppConnectionGetExternalIpAddressResponse
    {
        get => wanPppConnectionGetExternalIpAddressResponse;
        private set { _ = SetProperty(ref wanPppConnectionGetExternalIpAddressResponse, value); }
    }

    public WanPppConnectionGetAutoDisconnectTimeSpanResponse? WanPppConnectionGetAutoDisconnectTimeSpanResponse
    {
        get => wanPppConnectionGetAutoDisconnectTimeSpanResponse;
        private set { _ = SetProperty(ref wanPppConnectionGetAutoDisconnectTimeSpanResponse, value); }
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

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken = default)
    {
        await API.TaskExtensions.WhenAllSafe(new[]
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

    private async Task GetWanPppConnectionGetUserNameAsync()
    {
        WanPppConnectionGetUserNameResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanPppConnectionGetUserNameAsync();
    }

    private async Task GetWanPppConnectionGetNatRsipStatusAsync()
    {
        WanPppConnectionGetNatRsipStatusResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanPppConnectionGetNatRsipStatusAsync();
    }

    private async Task GetWanPppConnectionGetDnsServersAsync()
    {
        WanPppConnectionGetDnsServersResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanPppConnectionGetDnsServersAsync();
    }

    private async Task GetWanPppConnectionGetPortMappingNumberOfEntriesAsync()
    {
        WanPppConnectionGetPortMappingNumberOfEntriesResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanPppConnectionGetPortMappingNumberOfEntriesAsync();
    }

    private async Task GetWanPppConnectionGetExternalIpAddressAsync()
    {
        WanPppConnectionGetExternalIpAddressResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanPppConnectionGetExternalIpAddressAsync();
    }

    private async Task GetWanPppConnectionGetAutoDisconnectTimeSpanAsync()
    {
        WanPppConnectionGetAutoDisconnectTimeSpanResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanPppConnectionGetAutoDisconnectTimeSpanAsync();
    }
}