namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzServiceOperationHandler(
    IClientFactory<IFritzHostsService> fritzHostsServiceClientFactory,
    IClientFactory<IFritzWanCommonInterfaceConfigService> fritzWanCommonInterfaceConfigServiceClientFactory,
    IClientFactory<IFritzDeviceInfoService> fritzDeviceInfoServiceClientFactory,
    IClientFactory<IFritzLanConfigSecurityService> fritzLanConfigSecurityServiceClientFactory,
    IClientFactory<IFritzLayer3ForwardingService> fritzLayer3ForwardingServiceClientFactory,
    IClientFactory<IFritzWanDslInterfaceConfigService> fritzWanDslInterfaceConfigServiceClientFactory,
    IClientFactory<IFritzWanPppConnectionService> fritzWanPppConnectionServiceClientFactory,
    IClientFactory<IFritzWanIpConnectionService> fritzWanIpConnectionServiceClientFactory,
    IClientFactory<IFritzWanEthernetLinkConfigService> fritzWanEthernetLinkConfigServiceClientFactory,
    IClientFactory<IFritzWanDslLinkConfigService> fritzWanDslLinkConfigServiceClientFactory,
    IClientFactory<IFritzAvmSpeedtestService> fritzAvmSpeedtestServiceClientFactory,
    IClientFactory<IFritzLanEthernetInterfaceConfigService> fritzLanEthernetInterfaceConfigServiceClientFactory,
    IClientFactory<IFritzLanHostConfigManagementService> fritzLanHostConfigManagementServiceClientFactory,
    IClientFactory<IFritzWlanConfiguration1Service> fritzWlanConfiguration1ServiceClientFactory,
    IClientFactory<IFritzWlanConfiguration2Service> fritzWlanConfiguration2ServiceClientFactory,
    IClientFactory<IFritzWlanConfiguration3Service> fritzWlanConfiguration3ServiceClientFactory,
    IClientFactory<IFritzWlanConfiguration4Service> fritzWlanConfiguration4ServiceClientFactory,
    IClientFactory<IFritzManagementServerService> fritzManagementServerServiceClientFactory,
    IClientFactory<IFritzTimeService> fritzTimeServiceClientFactory,
    IClientFactory<IFritzUserInterfaceService> fritzUserInterfaceServiceClientFactory,
    IClientFactory<IFritzDeviceConfigService> fritzDeviceConfigServiceClientFactory)
    : IFritzServiceOperationHandler
{
    public Task<HostsGetHostNumberOfEntriesResponse> HostsGetHostNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzHostsServiceClientFactory, (q, r, t) => new FritzHostsService(q, r, t!), FritzHostsService.ControlUrl), q => q.GetHostNumberOfEntriesAsync(default));

    public Task<HostsHostsCheckUpdateResponse> HostsHostsCheckUpdateAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzHostsServiceClientFactory, (q, r, t) => new FritzHostsService(q, r, t!), FritzHostsService.ControlUrl), q => q.HostsCheckUpdateAsync(default));

    public Task<HostsGetHostListPathResponse> HostsGetHostListPathAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzHostsServiceClientFactory, (q, r, t) => new FritzHostsService(q, r, t!), FritzHostsService.ControlUrl), q => q.GetHostListPathAsync(default));

    public Task<HostsGetGenericHostEntryResponse> HostsGetGenericHostEntryAsync(InternetGatewayDevice internetGatewayDevice, HostsGetGenericHostEntryRequest hostsGetGenericHostEntryRequest)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzHostsServiceClientFactory, (q, r, t) => new FritzHostsService(q, r, t!), FritzHostsService.ControlUrl), q => q.GetGenericHostEntryAsync(hostsGetGenericHostEntryRequest));

    public Task<HostsGetInfoResponse> HostsGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzHostsServiceClientFactory, (q, r, t) => new FritzHostsService(q, r, t!), FritzHostsService.ControlUrl), q => q.GetInfoAsync(default));

    public Task<HostsGetChangeCounterResponse> HostsGetChangeCounterAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzHostsServiceClientFactory, (q, r, t) => new FritzHostsService(q, r, t!), FritzHostsService.ControlUrl), q => q.GetChangeCounterAsync(default));

    public Task<HostsGetMeshListPathResponse> HostsGetMeshListPathAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzHostsServiceClientFactory, (q, r, t) => new FritzHostsService(q, r, t!), FritzHostsService.ControlUrl), q => q.GetMeshListPathAsync(default));

    public Task<HostsGetFriendlyNameResponse> HostsGetFriendlyNameAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzHostsServiceClientFactory, (q, r, t) => new FritzHostsService(q, r, t!), FritzHostsService.ControlUrl), q => q.GetFriendlyNameAsync(default));

    public Task<WanCommonInterfaceConfigGetCommonLinkPropertiesResponse> WanCommonInterfaceConfigGetCommonLinkPropertiesAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetCommonLinkPropertiesAsync(default));

    public Task<WanCommonInterfaceConfigGetTotalBytesReceivedResponse> WanCommonInterfaceConfigGetTotalBytesReceivedAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetTotalBytesReceivedAsync(default));

    public Task<WanCommonInterfaceConfigGetTotalBytesSentResponse> WanCommonInterfaceConfigGetTotalBytesSentAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetTotalBytesSentAsync(default));

    public Task<WanCommonInterfaceConfigGetTotalPacketsReceivedResponse> WanCommonInterfaceConfigGetTotalPacketsReceivedAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetTotalPacketsReceivedAsync(default));

    public Task<WanCommonInterfaceConfigGetTotalPacketsSentResponse> WanCommonInterfaceConfigGetTotalPacketsSentAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetTotalPacketsSentAsync(default));

    public Task<WanCommonInterfaceConfigGetOnlineMonitorResponse> WanCommonInterfaceConfigGetOnlineMonitorAsync(InternetGatewayDevice internetGatewayDevice, WanCommonInterfaceConfigGetOnlineMonitorRequest wanCommonInterfaceConfigGetOnlineMonitorRequest)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetOnlineMonitorAsync(wanCommonInterfaceConfigGetOnlineMonitorRequest));

    public Task<WanCommonInterfaceConfigSetWanAccessTypeResponse> WanCommonInterfaceConfigSetWanAccessTypeAsync(InternetGatewayDevice internetGatewayDevice, WanCommonInterfaceConfigSetWanAccessTypeRequest wanCommonInterfaceConfigSetWanAccessTypeRequest)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.SetWanAccessTypeAsync(wanCommonInterfaceConfigSetWanAccessTypeRequest));

    public Task<DeviceInfoGetInfoResponse> DeviceInfoGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzDeviceInfoServiceClientFactory, (q, r, t) => new FritzDeviceInfoService(q, r, t), FritzDeviceInfoService.ControlUrl), q => q.GetInfoAsync(default));

    public Task<DeviceInfoGetDeviceLogResponse> DeviceInfoGetDeviceLogAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzDeviceInfoServiceClientFactory, (q, r, t) => new FritzDeviceInfoService(q, r, t), FritzDeviceInfoService.ControlUrl), q => q.GetDeviceLogAsync(default));

    public Task<DeviceInfoGetSecurityPortResponse> DeviceInfoGetSecurityPortAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzDeviceInfoServiceClientFactory, (q, r, t) => new FritzDeviceInfoService(q, r, t), FritzDeviceInfoService.ControlUrl, false), q => q.GetSecurityPortAsync(default));

    public Task<DeviceInfoSetProvisioningCodeResponse> DeviceInfoSetProvisioningCodeAsync(InternetGatewayDevice internetGatewayDevice, DeviceInfoSetProvisioningCodeRequest deviceInfoSetProvisioningCodeRequest)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzDeviceInfoServiceClientFactory, (q, r, t) => new FritzDeviceInfoService(q, r, t), FritzDeviceInfoService.ControlUrl), q => q.SetProvisioningCodeAsync(deviceInfoSetProvisioningCodeRequest));

    public Task<LanConfigSecurityGetAnonymousLoginResponse> LanConfigSecurityGetAnonymousLoginAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanConfigSecurityServiceClientFactory, (q, r, t) => new FritzLanConfigSecurityService(q, r, t), FritzLanConfigSecurityService.ControlUrl, false), q => q.GetAnonymousLoginAsync(default));

    public Task<LanConfigSecurityGetCurrentUserResponse> LanConfigSecurityGetCurrentUserAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanConfigSecurityServiceClientFactory, (q, r, t) => new FritzLanConfigSecurityService(q, r, t), FritzLanConfigSecurityService.ControlUrl), q => q.GetCurrentUserAsync(default));

    public Task<LanConfigSecurityGetInfoResponse> LanConfigSecurityGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanConfigSecurityServiceClientFactory, (q, r, t) => new FritzLanConfigSecurityService(q, r, t), FritzLanConfigSecurityService.ControlUrl), q => q.GetInfoAsync(default));

    public Task<LanConfigSecurityGetUserListResponse> LanConfigSecurityGetUserListAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanConfigSecurityServiceClientFactory, (q, r, t) => new FritzLanConfigSecurityService(q, r, t), FritzLanConfigSecurityService.ControlUrl), q => q.GetUserListAsync(default));

    public Task<LanConfigSecuritySetConfigPasswordResponse> LanConfigSecuritySetConfigPasswordAsync(InternetGatewayDevice internetGatewayDevice, LanConfigSecuritySetConfigPasswordRequest lanConfigSecuritySetConfigPasswordRequest)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanConfigSecurityServiceClientFactory, (q, r, t) => new FritzLanConfigSecurityService(q, r, t), FritzLanConfigSecurityService.ControlUrl), q => q.SetConfigPasswordAsync(lanConfigSecuritySetConfigPasswordRequest));

    public Task<Layer3ForwardingGetDefaultConnectionServiceResponse> Layer3ForwardingGetDefaultConnectionServiceAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLayer3ForwardingServiceClientFactory, (q, r, t) => new FritzLayer3ForwardingService(q, r, t!), FritzLayer3ForwardingService.ControlUrl), q => q.GetDefaultConnectionServiceAsync(default));

    public Task<Layer3ForwardingGetForwardNumberOfEntriesResponse> Layer3ForwardingGetForwardNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLayer3ForwardingServiceClientFactory, (q, r, t) => new FritzLayer3ForwardingService(q, r, t!), FritzLayer3ForwardingService.ControlUrl), q => q.GetForwardNumberOfEntriesAsync(default));

    public Task<Layer3ForwardingGetGenericForwardingEntryResponse> Layer3ForwardingGetGenericForwardingEntryAsync(InternetGatewayDevice internetGatewayDevice, Layer3ForwardingGetGenericForwardingEntryRequest layer3ForwardingGetGenericForwardingEntryRequest)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLayer3ForwardingServiceClientFactory, (q, r, t) => new FritzLayer3ForwardingService(q, r, t!), FritzLayer3ForwardingService.ControlUrl), q => q.GetGenericForwardingEntryAsync(layer3ForwardingGetGenericForwardingEntryRequest));

    public Task<WanDslInterfaceConfigGetDslDiagnoseInfoResponse> WanDslInterfaceConfigGetDslDiagnoseInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanDslInterfaceConfigService(q, r, t!), FritzWanDslInterfaceConfigService.ControlUrl), q => q.GetDslDiagnoseInfoAsync(default));

    public Task<WanDslInterfaceConfigGetDslInfoResponse> WanDslInterfaceConfigGetDslInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanDslInterfaceConfigService(q, r, t!), FritzWanDslInterfaceConfigService.ControlUrl), q => q.GetDslInfoAsync(default));

    public Task<WanDslInterfaceConfigGetInfoResponse> WanDslInterfaceConfigGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanDslInterfaceConfigService(q, r, t!), FritzWanDslInterfaceConfigService.ControlUrl), q => q.GetInfoAsync(default));

    public Task<WanDslInterfaceConfigGetStatisticsTotalResponse> WanDslInterfaceConfigGetStatisticsTotalAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanDslInterfaceConfigService(q, r, t!), FritzWanDslInterfaceConfigService.ControlUrl), q => q.GetStatisticsTotalAsync(default));

    public Task<WanIpConnectionGetInfoResponse> WanIpConnectionGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetInfoAsync(default));

    public Task<WanConnectionGetConnectionTypeInfoResponse> WanIpConnectionGetConnectionTypeInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetConnectionTypeInfoAsync(default));

    public Task<WanConnectionGetStatusInfoResponse> WanIpConnectionGetStatusInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetStatusInfoAsync(default));

    public Task<WanConnectionGetNatRsipStatusResponse> WanIpConnectionGetNatRsipStatusAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetNatRsipStatusAsync(default));

    public Task<WanConnectionGetDnsServersResponse> WanIpConnectionGetDnsServersAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetDnsServersAsync(default));

    public Task<WanConnectionGetPortMappingNumberOfEntriesResponse> WanIpConnectionGetPortMappingNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetPortMappingNumberOfEntriesAsync(default));

    public Task<WanConnectionGetExternalIpAddressResponse> WanIpConnectionGetExternalIpAddressAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetExternalIpAddressAsync(default));

    public Task<WanConnectionGetGenericPortMappingEntryResponse> WanIpConnectionGetGenericPortMappingEntryAsync(InternetGatewayDevice internetGatewayDevice, WanConnectionGetGenericPortMappingEntryRequest wanConnectionGetGenericPortMappingEntryRequest)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetGenericPortMappingEntryAsync(wanConnectionGetGenericPortMappingEntryRequest));

    public Task<WanPppConnectionGetInfoResponse> WanPppConnectionGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetInfoAsync(default));

    public Task<WanConnectionGetConnectionTypeInfoResponse> WanPppConnectionGetConnectionTypeInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetConnectionTypeInfoAsync(default));

    public Task<WanConnectionGetStatusInfoResponse> WanPppConnectionGetStatusInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetStatusInfoAsync(default));

    public Task<WanPppConnectionGetLinkLayerMaxBitRatesResponse> WanPppConnectionGetLinkLayerMaxBitRatesAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetLinkLayerMaxBitRatesAsync(default));

    public Task<WanPppConnectionGetUserNameResponse> WanPppConnectionGetUserNameAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetUserNameAsync(default));

    public Task<WanConnectionGetNatRsipStatusResponse> WanPppConnectionGetNatRsipStatusAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetNatRsipStatusAsync(default));

    public Task<WanConnectionGetDnsServersResponse> WanPppConnectionGetDnsServersAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetDnsServersAsync(default));

    public Task<WanConnectionGetPortMappingNumberOfEntriesResponse> WanPppConnectionGetPortMappingNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetPortMappingNumberOfEntriesAsync(default));

    public Task<WanConnectionGetExternalIpAddressResponse> WanPppConnectionGetExternalIpAddressAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetExternalIpAddressAsync(default));

    public Task<WanPppConnectionGetAutoDisconnectTimeSpanResponse> WanPppConnectionGetAutoDisconnectTimeSpanAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetAutoDisconnectTimeSpanAsync(default));

    public Task<WanConnectionGetGenericPortMappingEntryResponse> WanPppConnectionGetGenericPortMappingEntryAsync(InternetGatewayDevice internetGatewayDevice, WanConnectionGetGenericPortMappingEntryRequest wanConnectionGetGenericPortMappingEntryRequest)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetGenericPortMappingEntryAsync(wanConnectionGetGenericPortMappingEntryRequest));

    public Task<WanEthernetLinkConfigGetEthernetLinkStatusResponse> WanEthernetLinkConfigGetEthernetLinkStatusAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanEthernetLinkConfigServiceClientFactory, (q, r, t) => new FritzWanEthernetLinkConfigService(q, r, t!), FritzWanEthernetLinkConfigService.ControlUrl), q => q.GetEthernetLinkStatusAsync(default));

    public Task<WanDslLinkConfigGetInfoResponse> WanDslLinkConfigGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslLinkConfigServiceClientFactory, (q, r, t) => new FritzWanDslLinkConfigService(q, r, t!), FritzWanDslLinkConfigService.ControlUrl), q => q.GetInfoAsync(default));

    public Task<WanDslLinkConfigGetDslLinkInfoResponse> WanDslLinkConfigGetDslLinkInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslLinkConfigServiceClientFactory, (q, r, t) => new FritzWanDslLinkConfigService(q, r, t!), FritzWanDslLinkConfigService.ControlUrl), q => q.GetDslLinkInfoAsync(default));

    public Task<WanDslLinkConfigGetDestinationAddressResponse> WanDslLinkConfigGetDestinationAddressAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslLinkConfigServiceClientFactory, (q, r, t) => new FritzWanDslLinkConfigService(q, r, t!), FritzWanDslLinkConfigService.ControlUrl), q => q.GetDestinationAddressAsync(default));

    public Task<WanDslLinkConfigGetAtmEncapsulationResponse> WanDslLinkConfigGetAtmEncapsulationAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslLinkConfigServiceClientFactory, (q, r, t) => new FritzWanDslLinkConfigService(q, r, t!), FritzWanDslLinkConfigService.ControlUrl), q => q.GetAtmEncapsulationAsync(default));

    public Task<WanDslLinkConfigGetAutoConfigResponse> WanDslLinkConfigGetAutoConfigAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslLinkConfigServiceClientFactory, (q, r, t) => new FritzWanDslLinkConfigService(q, r, t!), FritzWanDslLinkConfigService.ControlUrl), q => q.GetAutoConfigAsync(default));

    public Task<WanDslLinkConfigGetStatisticsResponse> WanDslLinkConfigGetStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslLinkConfigServiceClientFactory, (q, r, t) => new FritzWanDslLinkConfigService(q, r, t!), FritzWanDslLinkConfigService.ControlUrl), q => q.GetStatisticsAsync(default));

    public Task<AvmSpeedtestGetInfoResponse> AvmSpeedtestGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzAvmSpeedtestServiceClientFactory, (q, r, t) => new FritzAvmSpeedtestService(q, r, t!), FritzAvmSpeedtestService.ControlUrl), q => q.GetInfoAsync(default));

    public Task<AvmSpeedtestGetStatisticsResponse> AvmSpeedtestGetStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzAvmSpeedtestServiceClientFactory, (q, r, t) => new FritzAvmSpeedtestService(q, r, t!), FritzAvmSpeedtestService.ControlUrl), q => q.GetStatisticsAsync(default));

    public Task<LanEthernetInterfaceConfigGetInfoResponse> LanEthernetInterfaceConfigGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanEthernetInterfaceConfigServiceClientFactory, (q, r, t) => new FritzLanEthernetInterfaceConfigService(q, r, t!), FritzLanEthernetInterfaceConfigService.ControlUrl), q => q.GetInfoAsync(default));

    public Task<LanEthernetInterfaceConfigGetStatisticsResponse> LanEthernetInterfaceConfigGetStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanEthernetInterfaceConfigServiceClientFactory, (q, r, t) => new FritzLanEthernetInterfaceConfigService(q, r, t!), FritzLanEthernetInterfaceConfigService.ControlUrl), q => q.GetStatisticsAsync(default));

    public Task<LanHostConfigManagementGetInfoResponse> LanHostConfigManagementGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanHostConfigManagementServiceClientFactory, (q, r, t) => new FritzLanHostConfigManagementService(q, r, t!), FritzLanHostConfigManagementService.ControlUrl), q => q.GetInfoAsync(default));

    public Task<LanHostConfigManagementGetAddressRangeResponse> LanHostConfigManagementGetAddressRangeAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanHostConfigManagementServiceClientFactory, (q, r, t) => new FritzLanHostConfigManagementService(q, r, t!), FritzLanHostConfigManagementService.ControlUrl), q => q.GetAddressRangeAsync(default));

    public Task<LanHostConfigManagementGetDnsServersResponse> LanHostConfigManagementGetDnsServersAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanHostConfigManagementServiceClientFactory, (q, r, t) => new FritzLanHostConfigManagementService(q, r, t!), FritzLanHostConfigManagementService.ControlUrl), q => q.GetDnsServersAsync(default));

    public Task<LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse> LanHostConfigManagementGetIpInterfaceNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanHostConfigManagementServiceClientFactory, (q, r, t) => new FritzLanHostConfigManagementService(q, r, t!), FritzLanHostConfigManagementService.ControlUrl), q => q.GetIpInterfaceNumberOfEntriesAsync(default));

    public Task<LanHostConfigManagementGetIpRoutersListResponse> LanHostConfigManagementGetIpRoutersListAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanHostConfigManagementServiceClientFactory, (q, r, t) => new FritzLanHostConfigManagementService(q, r, t!), FritzLanHostConfigManagementService.ControlUrl), q => q.GetIpRoutersListAsync(default));

    public Task<LanHostConfigManagementGetSubnetMaskResponse> LanHostConfigManagementGetSubnetMaskAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanHostConfigManagementServiceClientFactory, (q, r, t) => new FritzLanHostConfigManagementService(q, r, t!), FritzLanHostConfigManagementService.ControlUrl), q => q.GetSubnetMaskAsync(default));

    public Task<WlanConfigurationGetInfoResponse> WlanConfiguration1GetInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetInfoAsync(default));

    public Task<WlanConfigurationGetInfoResponse> WlanConfiguration2GetInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetInfoAsync(default));

    public Task<WlanConfigurationGetInfoResponse> WlanConfiguration3GetInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetInfoAsync(default));

    public Task<WlanConfigurationGetInfoResponse> WlanConfiguration4GetInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetInfoAsync(default));

    public Task<WlanConfigurationGetWlanDeviceListPathResponse> WlanConfiguration1GetWlanDeviceListPathAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetWlanDeviceListPathAsync(default));

    public Task<WlanConfigurationGetWlanDeviceListPathResponse> WlanConfiguration2GetWlanDeviceListPathAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetWlanDeviceListPathAsync(default));

    public Task<WlanConfigurationGetWlanDeviceListPathResponse> WlanConfiguration3GetWlanDeviceListPathAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetWlanDeviceListPathAsync(default));

    public Task<WlanConfigurationGetWlanDeviceListPathResponse> WlanConfiguration4GetWlanDeviceListPathAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetWlanDeviceListPathAsync(default));

    public Task<WlanConfigurationGetBasBeaconSecurityPropertiesResponse> WlanConfiguration1GetBasBeaconSecurityPropertiesAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetBasBeaconSecurityPropertiesAsync(default));

    public Task<WlanConfigurationGetBasBeaconSecurityPropertiesResponse> WlanConfiguration2GetBasBeaconSecurityPropertiesAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetBasBeaconSecurityPropertiesAsync(default));

    public Task<WlanConfigurationGetBasBeaconSecurityPropertiesResponse> WlanConfiguration3GetBasBeaconSecurityPropertiesAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetBasBeaconSecurityPropertiesAsync(default));

    public Task<WlanConfigurationGetBasBeaconSecurityPropertiesResponse> WlanConfiguration4GetBasBeaconSecurityPropertiesAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetBasBeaconSecurityPropertiesAsync(default));

    public Task<WlanConfigurationGetBssIdResponse> WlanConfiguration1GetBssIdAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetBssIdAsync(default));

    public Task<WlanConfigurationGetBssIdResponse> WlanConfiguration2GetBssIdAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetBssIdAsync(default));

    public Task<WlanConfigurationGetBssIdResponse> WlanConfiguration3GetBssIdAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetBssIdAsync(default));

    public Task<WlanConfigurationGetBssIdResponse> WlanConfiguration4GetBssIdAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetBssIdAsync(default));

    public Task<WlanConfigurationGetSsIdResponse> WlanConfiguration1GetSsIdAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetSsIdAsync(default));

    public Task<WlanConfigurationGetSsIdResponse> WlanConfiguration2GetSsIdAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetSsIdAsync(default));

    public Task<WlanConfigurationGetSsIdResponse> WlanConfiguration3GetSsIdAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetSsIdAsync(default));

    public Task<WlanConfigurationGetSsIdResponse> WlanConfiguration4GetSsIdAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetSsIdAsync(default));

    public Task<WlanConfigurationGetBeaconTypeResponse> WlanConfiguration1GetBeaconTypeAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetBeaconTypeAsync(default));

    public Task<WlanConfigurationGetBeaconTypeResponse> WlanConfiguration2GetBeaconTypeAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetBeaconTypeAsync(default));

    public Task<WlanConfigurationGetBeaconTypeResponse> WlanConfiguration3GetBeaconTypeAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetBeaconTypeAsync(default));

    public Task<WlanConfigurationGetBeaconTypeResponse> WlanConfiguration4GetBeaconTypeAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetBeaconTypeAsync(default));

    public Task<WlanConfigurationGetChannelInfoResponse> WlanConfiguration1GetChannelInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetChannelInfoAsync(default));

    public Task<WlanConfigurationGetChannelInfoResponse> WlanConfiguration2GetChannelInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetChannelInfoAsync(default));

    public Task<WlanConfigurationGetChannelInfoResponse> WlanConfiguration3GetChannelInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetChannelInfoAsync(default));

    public Task<WlanConfigurationGetChannelInfoResponse> WlanConfiguration4GetChannelInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetChannelInfoAsync(default));

    public Task<WlanConfigurationGetBeaconAdvertisementResponse> WlanConfiguration1GetBeaconAdvertisementAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetBeaconAdvertisementAsync(default));

    public Task<WlanConfigurationGetBeaconAdvertisementResponse> WlanConfiguration2GetBeaconAdvertisementAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetBeaconAdvertisementAsync(default));

    public Task<WlanConfigurationGetBeaconAdvertisementResponse> WlanConfiguration3GetBeaconAdvertisementAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetBeaconAdvertisementAsync(default));

    public Task<WlanConfigurationGetBeaconAdvertisementResponse> WlanConfiguration4GetBeaconAdvertisementAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetBeaconAdvertisementAsync(default));

    public Task<WlanConfigurationGetTotalAssociationsResponse> WlanConfiguration1GetTotalAssociationsAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetTotalAssociationsAsync(default));

    public Task<WlanConfigurationGetTotalAssociationsResponse> WlanConfiguration2GetTotalAssociationsAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetTotalAssociationsAsync(default));

    public Task<WlanConfigurationGetTotalAssociationsResponse> WlanConfiguration3GetTotalAssociationsAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetTotalAssociationsAsync(default));

    public Task<WlanConfigurationGetTotalAssociationsResponse> WlanConfiguration4GetTotalAssociationsAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetTotalAssociationsAsync(default));

    public Task<WlanConfigurationGetIpTvOptimizedResponse> WlanConfiguration1GetIpTvOptimizedAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetIpTvOptimizedAsync(default));

    public Task<WlanConfigurationGetIpTvOptimizedResponse> WlanConfiguration2GetIpTvOptimizedAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetIpTvOptimizedAsync(default));

    public Task<WlanConfigurationGetIpTvOptimizedResponse> WlanConfiguration3GetIpTvOptimizedAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetIpTvOptimizedAsync(default));

    public Task<WlanConfigurationGetIpTvOptimizedResponse> WlanConfiguration4GetIpTvOptimizedAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetIpTvOptimizedAsync(default));

    public Task<WlanConfigurationGetStatisticsResponse> WlanConfiguration1GetStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetStatisticsAsync(default));

    public Task<WlanConfigurationGetStatisticsResponse> WlanConfiguration2GetStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetStatisticsAsync(default));

    public Task<WlanConfigurationGetStatisticsResponse> WlanConfiguration3GetStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetStatisticsAsync(default));

    public Task<WlanConfigurationGetStatisticsResponse> WlanConfiguration4GetStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetStatisticsAsync(default));

    public Task<WlanConfigurationGetPacketStatisticsResponse> WlanConfiguration1GetPacketStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetPacketStatisticsAsync(default));

    public Task<WlanConfigurationGetPacketStatisticsResponse> WlanConfiguration2GetPacketStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetPacketStatisticsAsync(default));

    public Task<WlanConfigurationGetPacketStatisticsResponse> WlanConfiguration3GetPacketStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetPacketStatisticsAsync(default));

    public Task<WlanConfigurationGetPacketStatisticsResponse> WlanConfiguration4GetPacketStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetPacketStatisticsAsync(default));

    public Task<WlanConfigurationGetNightControlResponse> WlanConfiguration1GetNightControlAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetNightControlAsync(default));

    public Task<WlanConfigurationGetNightControlResponse> WlanConfiguration2GetNightControlAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetNightControlAsync(default));

    public Task<WlanConfigurationGetNightControlResponse> WlanConfiguration3GetNightControlAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetNightControlAsync(default));

    public Task<WlanConfigurationGetNightControlResponse> WlanConfiguration4GetNightControlAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetNightControlAsync(default));

    public Task<WlanConfigurationGetWlanHybridModeResponse> WlanConfiguration1GetWlanHybridModeAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetWlanHybridModeAsync(default));

    public Task<WlanConfigurationGetWlanHybridModeResponse> WlanConfiguration2GetWlanHybridModeAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetWlanHybridModeAsync(default));

    public Task<WlanConfigurationGetWlanHybridModeResponse> WlanConfiguration3GetWlanHybridModeAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetWlanHybridModeAsync(default));

    public Task<WlanConfigurationGetWlanHybridModeResponse> WlanConfiguration4GetWlanHybridModeAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetWlanHybridModeAsync(default));

    public Task<WlanConfigurationGetWlanExtInfoResponse> WlanConfiguration1GetWlanExtInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetWlanExtInfoAsync(default));

    public Task<WlanConfigurationGetWlanExtInfoResponse> WlanConfiguration2GetWlanExtInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetWlanExtInfoAsync(default));

    public Task<WlanConfigurationGetWlanExtInfoResponse> WlanConfiguration3GetWlanExtInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetWlanExtInfoAsync(default));

    public Task<WlanConfigurationGetWlanExtInfoResponse> WlanConfiguration4GetWlanExtInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetWlanExtInfoAsync(default));

    public Task<WlanConfigurationGetWpsInfoResponse> WlanConfiguration1GetWpsInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetWpsInfoAsync(default));

    public Task<WlanConfigurationGetWpsInfoResponse> WlanConfiguration2GetWpsInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetWpsInfoAsync(default));

    public Task<WlanConfigurationGetWpsInfoResponse> WlanConfiguration3GetWpsInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetWpsInfoAsync(default));

    public Task<WlanConfigurationGetWpsInfoResponse> WlanConfiguration4GetWpsInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetWpsInfoAsync(default));

    public Task<WlanConfigurationGetWlanConnectionInfoResponse> WlanConfiguration1GetWlanConnectionInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetWlanConnectionInfoAsync(default));

    public Task<WlanConfigurationGetWlanConnectionInfoResponse> WlanConfiguration2GetWlanConnectionInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetWlanConnectionInfoAsync(default));

    public Task<WlanConfigurationGetWlanConnectionInfoResponse> WlanConfiguration3GetWlanConnectionInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetWlanConnectionInfoAsync(default));

    public Task<WlanConfigurationGetWlanConnectionInfoResponse> WlanConfiguration4GetWlanConnectionInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetWlanConnectionInfoAsync(default));

    public Task<ManagementServerGetInfoResponse> ManagementServerGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzManagementServerServiceClientFactory, (q, r, t) => new FritzManagementServerService(q, r, t!), FritzManagementServerService.ControlUrl), q => q.GetInfoAsync(default));

    public Task<ManagementServerGetTr069FirmwareDownloadEnabledResponse> ManagementServerGetTr069FirmwareDownloadEnabledAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzManagementServerServiceClientFactory, (q, r, t) => new FritzManagementServerService(q, r, t!), FritzManagementServerService.ControlUrl), q => q.GetTr069FirmwareDownloadEnabledAsync(default));

    public Task<ManagementServerSetManagementServerUrlResponse> ManagementServerSetManagementServerUrlAsync(InternetGatewayDevice internetGatewayDevice, ManagementServerSetManagementServerUrlRequest managementServerSetManagementServerUrlRequest)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzManagementServerServiceClientFactory, (q, r, t) => new FritzManagementServerService(q, r, t!), FritzManagementServerService.ControlUrl), q => q.SetManagementServerUrlAsync(managementServerSetManagementServerUrlRequest));

    public Task<ManagementServerSetManagementServerUsernameResponse> ManagementServerSetManagementServerUsernameAsync(InternetGatewayDevice internetGatewayDevice, ManagementServerSetManagementServerUsernameRequest managementServerSetManagementServerUsernameRequest)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzManagementServerServiceClientFactory, (q, r, t) => new FritzManagementServerService(q, r, t!), FritzManagementServerService.ControlUrl), q => q.SetManagementServerUsernameAsync(managementServerSetManagementServerUsernameRequest));

    public Task<ManagementServerSetManagementServerPasswordResponse> ManagementServerSetManagementServerPasswordAsync(InternetGatewayDevice internetGatewayDevice, ManagementServerSetManagementServerPasswordRequest managementServerSetManagementServerPasswordRequest)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzManagementServerServiceClientFactory, (q, r, t) => new FritzManagementServerService(q, r, t!), FritzManagementServerService.ControlUrl), q => q.SetManagementServerPasswordAsync(managementServerSetManagementServerPasswordRequest));

    public Task<ManagementServerSetPeriodicInformResponse> ManagementServerSetPeriodicInformAsync(InternetGatewayDevice internetGatewayDevice, ManagementServerSetPeriodicInformRequest managementServerSetPeriodicInformRequest)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzManagementServerServiceClientFactory, (q, r, t) => new FritzManagementServerService(q, r, t!), FritzManagementServerService.ControlUrl), q => q.SetPeriodicInformAsync(managementServerSetPeriodicInformRequest));

    public Task<ManagementServerSetConnectionRequestAuthenticationResponse> ManagementServerSetConnectionRequestAuthenticationAsync(InternetGatewayDevice internetGatewayDevice, ManagementServerSetConnectionRequestAuthenticationRequest managementServerSetConnectionRequestAuthenticationRequest)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzManagementServerServiceClientFactory, (q, r, t) => new FritzManagementServerService(q, r, t!), FritzManagementServerService.ControlUrl), q => q.SetConnectionRequestAuthenticationAsync(managementServerSetConnectionRequestAuthenticationRequest));

    public Task<ManagementServerSetUpgradeManagementResponse> ManagementServerSetUpgradeManagementAsync(InternetGatewayDevice internetGatewayDevice, ManagementServerSetUpgradeManagementRequest managementServerSetUpgradeManagementRequest)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzManagementServerServiceClientFactory, (q, r, t) => new FritzManagementServerService(q, r, t!), FritzManagementServerService.ControlUrl), q => q.SetUpgradeManagementAsync(managementServerSetUpgradeManagementRequest));

    public Task<ManagementServerSetTr069EnableResponse> ManagementServerSetTr069EnableAsync(InternetGatewayDevice internetGatewayDevice, ManagementServerSetTr069EnableRequest managementServerSetTr069EnableRequest)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzManagementServerServiceClientFactory, (q, r, t) => new FritzManagementServerService(q, r, t!), FritzManagementServerService.ControlUrl), q => q.SetTr069EnableAsync(managementServerSetTr069EnableRequest));

    public Task<ManagementServerSetTr069FirmwareDownloadEnabledResponse> ManagementServerSetTr069FirmwareDownloadEnabledAsync(InternetGatewayDevice internetGatewayDevice, ManagementServerSetTr069FirmwareDownloadEnabledRequest managementServerSetTr069FirmwareDownloadEnabledRequest)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzManagementServerServiceClientFactory, (q, r, t) => new FritzManagementServerService(q, r, t!), FritzManagementServerService.ControlUrl), q => q.SetTr069FirmwareDownloadEnabledAsync(managementServerSetTr069FirmwareDownloadEnabledRequest));

    public Task<TimeGetInfoResponse> TimeGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzTimeServiceClientFactory, (q, r, t) => new FritzTimeService(q, r, t!), FritzTimeService.ControlUrl), q => q.GetInfoAsync(default));

    public Task<TimeSetNtpServersResponse> TimeSetNtpServersAsync(InternetGatewayDevice internetGatewayDevice, TimeSetNtpServersRequest timeSetNtpServersRequest)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzTimeServiceClientFactory, (q, r, t) => new FritzTimeService(q, r, t!), FritzTimeService.ControlUrl), q => q.SetNtpServersAsync(timeSetNtpServersRequest));

    public Task<UserInterfaceGetInfoResponse> UserInterfaceGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzUserInterfaceServiceClientFactory, (q, r, t) => new FritzUserInterfaceService(q, r, t!), FritzUserInterfaceService.ControlUrl), q => q.GetInfoAsync(default));

    public Task<UserInterfaceCheckUpdateResponse> UserInterfaceCheckUpdateAsync(InternetGatewayDevice internetGatewayDevice, UserInterfaceCheckUpdateRequest userInterfaceCheckUpdateRequest)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzUserInterfaceServiceClientFactory, (q, r, t) => new FritzUserInterfaceService(q, r, t!), FritzUserInterfaceService.ControlUrl), q => q.CheckUpdateAsync(userInterfaceCheckUpdateRequest));

    public Task<UserInterfaceDoPrepareCgiResponse> UserInterfaceDoPrepareCgiAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzUserInterfaceServiceClientFactory, (q, r, t) => new FritzUserInterfaceService(q, r, t!), FritzUserInterfaceService.ControlUrl), q => q.DoPrepareCgiAsync(default));

    public Task<UserInterfaceDoUpdateResponse> UserInterfaceDoUpdateAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzUserInterfaceServiceClientFactory, (q, r, t) => new FritzUserInterfaceService(q, r, t!), FritzUserInterfaceService.ControlUrl), q => q.DoUpdateAsync(default));

    public Task<UserInterfaceDoManualUpdateResponse> UserInterfaceDoManualUpdateAsync(InternetGatewayDevice internetGatewayDevice, UserInterfaceDoManualUpdateRequest userInterfaceDoManualUpdateRequest)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzUserInterfaceServiceClientFactory, (q, r, t) => new FritzUserInterfaceService(q, r, t!), FritzUserInterfaceService.ControlUrl), q => q.DoManualUpdateAsync(userInterfaceDoManualUpdateRequest));

    public Task<UserInterfaceGetInternationalConfigResponse> UserInterfaceGetInternationalConfigAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzUserInterfaceServiceClientFactory, (q, r, t) => new FritzUserInterfaceService(q, r, t!), FritzUserInterfaceService.ControlUrl), q => q.GetInternationalConfigAsync(default));

    public Task<UserInterfaceSetInternationalConfigResponse> UserInterfaceSetInternationalConfigAsync(InternetGatewayDevice internetGatewayDevice, UserInterfaceSetInternationalConfigRequest userInterfaceSetInternationalConfigRequest)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzUserInterfaceServiceClientFactory, (q, r, t) => new FritzUserInterfaceService(q, r, t!), FritzUserInterfaceService.ControlUrl), q => q.SetInternationalConfigAsync(userInterfaceSetInternationalConfigRequest));

    public Task<UserInterfaceAvmGetInfoResponse> UserInterfaceAvmGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzUserInterfaceServiceClientFactory, (q, r, t) => new FritzUserInterfaceService(q, r, t!), FritzUserInterfaceService.ControlUrl), q => q.AvmGetInfoAsync(default));

    public Task<UserInterfaceSetConfigResponse> UserInterfaceSetConfigAsync(InternetGatewayDevice internetGatewayDevice, UserInterfaceSetConfigRequest userInterfaceSetConfigRequest)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzUserInterfaceServiceClientFactory, (q, r, t) => new FritzUserInterfaceService(q, r, t!), FritzUserInterfaceService.ControlUrl), q => q.SetConfigAsync(userInterfaceSetConfigRequest));

    public Task<DeviceConfigGetPersistentDataResponse> DeviceConfigGetPersistentDataAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzDeviceConfigServiceClientFactory, (q, r, t) => new FritzDeviceConfigService(q, r, t!), FritzDeviceConfigService.ControlUrl), q => q.GetPersistentDataAsync(default));

    public Task<DeviceConfigGenerateUuIdResponse> DeviceConfigGenerateUuIdAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzDeviceConfigServiceClientFactory, (q, r, t) => new FritzDeviceConfigService(q, r, t!), FritzDeviceConfigService.ControlUrl), q => q.GenerateUuIdAsync(default));

    public Task<DeviceConfigCreateUrlSidResponse> DeviceConfigCreateUrlSidAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzDeviceConfigServiceClientFactory, (q, r, t) => new FritzDeviceConfigService(q, r, t!), FritzDeviceConfigService.ControlUrl), q => q.CreateUrlSidAsync(default));

    public Task<DeviceConfigGetSupportDataInfoResponse> DeviceConfigGetSupportDataInfoAsync(InternetGatewayDevice internetGatewayDevice)
        => ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzDeviceConfigServiceClientFactory, (q, r, t) => new FritzDeviceConfigService(q, r, t!), FritzDeviceConfigService.ControlUrl), q => q.GetSupportDataInfoAsync(default));

    private static T GetFritzServiceClient<T>(InternetGatewayDevice internetGatewayDevice, IClientFactory<T> clientFactory, Func<FritzServiceEndpointConfiguration, EndpointAddress, NetworkCredential?, T> createService, string controlUrl, bool secure = true)
        => clientFactory.Build(createService, internetGatewayDevice.PreferredLocation, secure, controlUrl, secure ? internetGatewayDevice.SecurityPort : null, internetGatewayDevice.NetworkCredential);

    private static async Task<TResult> ExecuteAsync<T, TResult>(T client, Func<T, Task<TResult>> operation)
        where T : IAsyncDisposable
    {
        await using (client.ConfigureAwait(false))
        {
            return await operation(client).ConfigureAwait(false);
        }
    }
}