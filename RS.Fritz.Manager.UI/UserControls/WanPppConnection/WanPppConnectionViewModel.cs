namespace RS.Fritz.Manager.UI;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

internal sealed class WanPppConnectionViewModel : WanAccessTypeAwareFritzServiceViewModel
{
    private WanPppConnectionGetInfoResponse? wanPppConnectionGetInfoResponse;
    private WanConnectionGetConnectionTypeInfoResponse? wanConnectionGetConnectionTypeInfoResponse;
    private WanConnectionGetStatusInfoResponse? wanConnectionGetStatusInfoResponse;
    private WanPppConnectionGetLinkLayerMaxBitRatesResponse? wanPppConnectionGetLinkLayerMaxBitRatesResponse;
    private WanPppConnectionGetUserNameResponse? wanPppConnectionGetUserNameResponse;
    private WanConnectionGetNatRsipStatusResponse? wanConnectionGetNatRsipStatusResponse;
    private WanConnectionGetDnsServersResponse? wanConnectionGetDnsServersResponse;
    private WanConnectionGetPortMappingNumberOfEntriesResponse? wanConnectionGetPortMappingNumberOfEntriesResponse;
    private WanConnectionGetExternalIpAddressResponse? wanConnectionGetExternalIpAddressResponse;
    private WanPppConnectionGetAutoDisconnectTimeSpanResponse? wanPppConnectionGetAutoDisconnectTimeSpanResponse;

    public WanPppConnectionViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, WanPppConnectionGetGenericPortMappingEntryViewModel wanPppConnectionGetGenericPortMappingEntryViewModel)
        : base(deviceLoginInfo, logger, WanAccessType.Dsl)
    {
        WanPppConnectionGetGenericPortMappingEntryViewModel = wanPppConnectionGetGenericPortMappingEntryViewModel;
    }

    public WanPppConnectionGetGenericPortMappingEntryViewModel WanPppConnectionGetGenericPortMappingEntryViewModel { get; }

    public WanPppConnectionGetInfoResponse? WanPppConnectionGetInfoResponse
    {
        get => wanPppConnectionGetInfoResponse;
        private set { _ = SetProperty(ref wanPppConnectionGetInfoResponse, value); }
    }

    public WanConnectionGetConnectionTypeInfoResponse? WanConnectionGetConnectionTypeInfoResponse
    {
        get => wanConnectionGetConnectionTypeInfoResponse;
        private set { _ = SetProperty(ref wanConnectionGetConnectionTypeInfoResponse, value); }
    }

    public WanConnectionGetStatusInfoResponse? WanConnectionGetStatusInfoResponse
    {
        get => wanConnectionGetStatusInfoResponse;
        private set { _ = SetProperty(ref wanConnectionGetStatusInfoResponse, value); }
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

    public WanConnectionGetNatRsipStatusResponse? WanConnectionGetNatRsipStatusResponse
    {
        get => wanConnectionGetNatRsipStatusResponse;
        private set { _ = SetProperty(ref wanConnectionGetNatRsipStatusResponse, value); }
    }

    public WanConnectionGetDnsServersResponse? WanConnectionGetDnsServersResponse
    {
        get => wanConnectionGetDnsServersResponse;
        private set { _ = SetProperty(ref wanConnectionGetDnsServersResponse, value); }
    }

    public WanConnectionGetPortMappingNumberOfEntriesResponse? WanConnectionGetPortMappingNumberOfEntriesResponse
    {
        get => wanConnectionGetPortMappingNumberOfEntriesResponse;
        private set
        {
            if (SetProperty(ref wanConnectionGetPortMappingNumberOfEntriesResponse, value))
                WanPppConnectionGetGenericPortMappingEntryViewModel.PortMappingNumberOfEntries = WanConnectionGetPortMappingNumberOfEntriesResponse?.PortMappingNumberOfEntries;
        }
    }

    public WanConnectionGetExternalIpAddressResponse? WanConnectionGetExternalIpAddressResponse
    {
        get => wanConnectionGetExternalIpAddressResponse;
        private set { _ = SetProperty(ref wanConnectionGetExternalIpAddressResponse, value); }
    }

    public WanPppConnectionGetAutoDisconnectTimeSpanResponse? WanPppConnectionGetAutoDisconnectTimeSpanResponse
    {
        get => wanPppConnectionGetAutoDisconnectTimeSpanResponse;
        private set { _ = SetProperty(ref wanPppConnectionGetAutoDisconnectTimeSpanResponse, value); }
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

    private async Task GetWanPppConnectionGetInfoAsync()
    {
        WanPppConnectionGetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanPppConnectionGetInfoAsync();
    }

    private async Task GetWanPppConnectionGetConnectionTypeInfoAsync()
    {
        WanConnectionGetConnectionTypeInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanPppConnectionGetConnectionTypeInfoAsync();
    }

    private async Task GetWanPppConnectionGetStatusInfoAsync()
    {
        WanConnectionGetStatusInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanPppConnectionGetStatusInfoAsync();
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
        WanConnectionGetNatRsipStatusResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanPppConnectionGetNatRsipStatusAsync();
    }

    private async Task GetWanPppConnectionGetDnsServersAsync()
    {
        WanConnectionGetDnsServersResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanPppConnectionGetDnsServersAsync();
    }

    private async Task GetWanPppConnectionGetPortMappingNumberOfEntriesAsync()
    {
        WanConnectionGetPortMappingNumberOfEntriesResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanPppConnectionGetPortMappingNumberOfEntriesAsync();
    }

    private async Task GetWanPppConnectionGetExternalIpAddressAsync()
    {
        WanConnectionGetExternalIpAddressResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanPppConnectionGetExternalIpAddressAsync();
    }

    private async Task GetWanPppConnectionGetAutoDisconnectTimeSpanAsync()
    {
        WanPppConnectionGetAutoDisconnectTimeSpanResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanPppConnectionGetAutoDisconnectTimeSpanAsync();
    }
}