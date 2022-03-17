namespace RS.Fritz.Manager.UI;

using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

internal sealed class WanIpConnectionViewModel : FritzServiceViewModel, IRecipient<PropertyChangedMessage<WanAccessType?>>
{
    private WanIpConnectionGetInfoResponse? wanIpConnectionGetInfoResponse;
    private WanIpConnectionGetConnectionTypeInfoResponse? wanIpConnectionGetConnectionTypeInfoResponse;
    private WanIpConnectionGetStatusInfoResponse? wanIpConnectionGetStatusInfoResponse;
    private WanIpConnectionGetNatRsipStatusResponse? wanIpConnectionGetNatRsipStatusResponse;
    private WanIpConnectionGetDnsServersResponse? wanIpConnectionGetDnsServersResponse;
    private WanIpConnectionGetPortMappingNumberOfEntriesResponse? wanIpConnectionGetPortMappingNumberOfEntriesResponse;
    private WanIpConnectionGetExternalIpAddressResponse? wanIpConnectionGetExternalIpAddressResponse;

    public WanIpConnectionViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
    }

    public WanIpConnectionGetInfoResponse? WanIpConnectionGetInfoResponse
    {
        get => wanIpConnectionGetInfoResponse;
        private set { _ = SetProperty(ref wanIpConnectionGetInfoResponse, value); }
    }

    public WanIpConnectionGetConnectionTypeInfoResponse? WanIpConnectionGetConnectionTypeInfoResponse
    {
        get => wanIpConnectionGetConnectionTypeInfoResponse;
        private set { _ = SetProperty(ref wanIpConnectionGetConnectionTypeInfoResponse, value); }
    }

    public WanIpConnectionGetStatusInfoResponse? WanIpConnectionGetStatusInfoResponse
    {
        get => wanIpConnectionGetStatusInfoResponse;
        private set { _ = SetProperty(ref wanIpConnectionGetStatusInfoResponse, value); }
    }

    public WanIpConnectionGetNatRsipStatusResponse? WanIpConnectionGetNatRsipStatusResponse
    {
        get => wanIpConnectionGetNatRsipStatusResponse;
        private set { _ = SetProperty(ref wanIpConnectionGetNatRsipStatusResponse, value); }
    }

    public WanIpConnectionGetDnsServersResponse? WanIpConnectionGetDnsServersResponse
    {
        get => wanIpConnectionGetDnsServersResponse;
        private set { _ = SetProperty(ref wanIpConnectionGetDnsServersResponse, value); }
    }

    public WanIpConnectionGetPortMappingNumberOfEntriesResponse? WanIpConnectionGetPortMappingNumberOfEntriesResponse
    {
        get => wanIpConnectionGetPortMappingNumberOfEntriesResponse;
        private set { _ = SetProperty(ref wanIpConnectionGetPortMappingNumberOfEntriesResponse, value); }
    }

    public WanIpConnectionGetExternalIpAddressResponse? WanIpConnectionGetExternalIpAddressResponse
    {
        get => wanIpConnectionGetExternalIpAddressResponse;
        private set { _ = SetProperty(ref wanIpConnectionGetExternalIpAddressResponse, value); }
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
                GetWanIpConnectionGetInfoAsync(),
                GetWanIpConnectionGetConnectionTypeInfoAsync(),
                GetWanIpConnectionGetStatusInfoAsync(),
                GetWanIpConnectionGetNatRsipStatusAsync(),
                GetWanIpConnectionGetDnsServersAsync(),
                GetWanIpConnectionGetPortMappingNumberOfEntriesAsync(),
                GetWanIpConnectionGetExternalIpAddressAsync()
          });
    }

    protected override bool GetCanExecuteDefaultCommand()
    {
        return base.GetCanExecuteDefaultCommand() && DeviceLoginInfo.InternetGatewayDevice!.WanAccessType is WanAccessType.Ethernet;
    }

    private async Task GetWanIpConnectionGetInfoAsync()
    {
        WanIpConnectionGetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanIpConnectionGetInfoAsync();
    }

    private async Task GetWanIpConnectionGetConnectionTypeInfoAsync()
    {
        WanIpConnectionGetConnectionTypeInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanIpConnectionGetConnectionTypeInfoAsync();
    }

    private async Task GetWanIpConnectionGetStatusInfoAsync()
    {
        WanIpConnectionGetStatusInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanIpConnectionGetStatusInfoAsync();
    }

    private async Task GetWanIpConnectionGetNatRsipStatusAsync()
    {
        WanIpConnectionGetNatRsipStatusResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanIpConnectionGetNatRsipStatusAsync();
    }

    private async Task GetWanIpConnectionGetDnsServersAsync()
    {
        WanIpConnectionGetDnsServersResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanIpConnectionGetDnsServersAsync();
    }

    private async Task GetWanIpConnectionGetPortMappingNumberOfEntriesAsync()
    {
        WanIpConnectionGetPortMappingNumberOfEntriesResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanIpConnectionGetPortMappingNumberOfEntriesAsync();
    }

    private async Task GetWanIpConnectionGetExternalIpAddressAsync()
    {
        WanIpConnectionGetExternalIpAddressResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanIpConnectionGetExternalIpAddressAsync();
    }
}