namespace RS.Fritz.Manager.API;

using System;
using System.Net;
using System.ServiceModel;
using System.Threading.Tasks;

internal sealed class FritzServiceOperationHandler : ServiceOperationHandler, IFritzServiceOperationHandler
{
    private readonly IClientFactory<IFritzHostsService> fritzHostsServiceClientFactory;
    private readonly IClientFactory<IFritzWanCommonInterfaceConfigService> fritzWanCommonInterfaceConfigServiceClientFactory;
    private readonly IClientFactory<IFritzDeviceInfoService> fritzDeviceInfoServiceClientFactory;
    private readonly IClientFactory<IFritzLanConfigSecurityService> fritzLanConfigSecurityServiceClientFactory;
    private readonly IClientFactory<IFritzLayer3ForwardingService> fritzLayer3ForwardingServiceClientFactory;
    private readonly IClientFactory<IFritzWanDslInterfaceConfigService> fritzWanDslInterfaceConfigServiceClientFactory;
    private readonly IClientFactory<IFritzWanPppConnectionService> fritzWanPppConnectionServiceClientFactory;
    private readonly IClientFactory<IFritzWanIpConnectionService> fritzWanIpConnectionServiceClientFactory;
    private readonly IClientFactory<IFritzWanEthernetLinkConfigService> fritzWanEthernetLinkConfigServiceClientFactory;

    public FritzServiceOperationHandler(
        IClientFactory<IFritzHostsService> fritzHostsServiceClientFactory,
        IClientFactory<IFritzWanCommonInterfaceConfigService> fritzWanCommonInterfaceConfigServiceClientFactory,
        IClientFactory<IFritzDeviceInfoService> fritzDeviceInfoServiceClientFactory,
        IClientFactory<IFritzLanConfigSecurityService> fritzLanConfigSecurityServiceClientFactory,
        IClientFactory<IFritzLayer3ForwardingService> fritzLayer3ForwardingServiceClientFactory,
        IClientFactory<IFritzWanDslInterfaceConfigService> fritzWanDslInterfaceConfigServiceClientFactory,
        IClientFactory<IFritzWanPppConnectionService> fritzWanPppConnectionServiceClientFactory,
        IClientFactory<IFritzWanIpConnectionService> fritzWanIpConnectionServiceClientFactory,
        IClientFactory<IFritzWanEthernetLinkConfigService> fritzWanEthernetLinkConfigServiceClientFactory)
    {
        this.fritzHostsServiceClientFactory = fritzHostsServiceClientFactory;
        this.fritzWanCommonInterfaceConfigServiceClientFactory = fritzWanCommonInterfaceConfigServiceClientFactory;
        this.fritzDeviceInfoServiceClientFactory = fritzDeviceInfoServiceClientFactory;
        this.fritzLanConfigSecurityServiceClientFactory = fritzLanConfigSecurityServiceClientFactory;
        this.fritzLayer3ForwardingServiceClientFactory = fritzLayer3ForwardingServiceClientFactory;
        this.fritzWanDslInterfaceConfigServiceClientFactory = fritzWanDslInterfaceConfigServiceClientFactory;
        this.fritzWanPppConnectionServiceClientFactory = fritzWanPppConnectionServiceClientFactory;
        this.fritzWanIpConnectionServiceClientFactory = fritzWanIpConnectionServiceClientFactory;
        this.fritzWanEthernetLinkConfigServiceClientFactory = fritzWanEthernetLinkConfigServiceClientFactory;
    }

    public Task<HostsGetHostNumberOfEntriesResponse> HostsGetHostNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzHostsServiceClientFactory, (q, r, t) => new FritzHostsService(q, r, t!), FritzHostsService.ControlUrl), q => q.GetHostNumberOfEntriesAsync(new HostsGetHostNumberOfEntriesRequest()));
    }

    public Task<HostsGetHostListPathResponse> HostsGetHostListPathAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzHostsServiceClientFactory, (q, r, t) => new FritzHostsService(q, r, t!), FritzHostsService.ControlUrl), q => q.GetHostListPathAsync(new HostsGetHostListPathRequest()));
    }

    public Task<HostsGetGenericHostEntryResponse> HostsGetGenericHostEntryAsync(InternetGatewayDevice internetGatewayDevice, ushort index)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzHostsServiceClientFactory, (q, r, t) => new FritzHostsService(q, r, t!), FritzHostsService.ControlUrl), q => q.GetGenericHostEntryAsync(new HostsGetGenericHostEntryRequest { Index = index }));
    }

    public Task<WanCommonInterfaceConfigGetCommonLinkPropertiesResponse> WanCommonInterfaceConfigGetCommonLinkPropertiesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetCommonLinkPropertiesAsync(new WanCommonInterfaceConfigGetCommonLinkPropertiesRequest()));
    }

    public Task<WanCommonInterfaceConfigGetTotalBytesReceivedResponse> WanCommonInterfaceConfigGetTotalBytesReceivedAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetTotalBytesReceivedAsync(new WanCommonInterfaceConfigGetTotalBytesReceivedRequest()));
    }

    public Task<WanCommonInterfaceConfigGetTotalBytesSentResponse> WanCommonInterfaceConfigGetTotalBytesSentAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetTotalBytesSentAsync(new WanCommonInterfaceConfigGetTotalBytesSentRequest()));
    }

    public Task<WanCommonInterfaceConfigGetTotalPacketsReceivedResponse> WanCommonInterfaceConfigGetTotalPacketsReceivedAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetTotalPacketsReceivedAsync(new WanCommonInterfaceConfigGetTotalPacketsReceivedRequest()));
    }

    public Task<WanCommonInterfaceConfigGetTotalPacketsSentResponse> WanCommonInterfaceConfigGetTotalPacketsSentAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetTotalPacketsSentAsync(new WanCommonInterfaceConfigGetTotalPacketsSentRequest()));
    }

    public Task<WanCommonInterfaceConfigGetOnlineMonitorResponse> WanCommonInterfaceConfigGetOnlineMonitorAsync(InternetGatewayDevice internetGatewayDevice, uint syncGroupIndex)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetOnlineMonitorAsync(new WanCommonInterfaceConfigGetOnlineMonitorRequest { SyncGroupIndex = syncGroupIndex }));
    }

    public Task<WanCommonInterfaceConfigSetWanAccessTypeResponse> WanCommonInterfaceConfigSetWanAccessTypeAsync(InternetGatewayDevice internetGatewayDevice, string accessType)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.SetWanAccessTypeAsync(new WanCommonInterfaceConfigSetWanAccessTypeRequest { AccessType = accessType }));
    }

    public Task<DeviceInfoGetInfoResponse> DeviceInfoGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzDeviceInfoServiceClientFactory, (q, r, t) => new FritzDeviceInfoService(q, r, t), FritzDeviceInfoService.ControlUrl), q => q.GetInfoAsync(new DeviceInfoGetInfoRequest()));
    }

    public Task<DeviceInfoGetDeviceLogResponse> DeviceInfoGetDeviceLogAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzDeviceInfoServiceClientFactory, (q, r, t) => new FritzDeviceInfoService(q, r, t), FritzDeviceInfoService.ControlUrl), q => q.GetDeviceLogAsync(new DeviceInfoGetDeviceLogRequest()));
    }

    public Task<DeviceInfoGetSecurityPortResponse> DeviceInfoGetSecurityPortAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzDeviceInfoServiceClientFactory, (q, r, t) => new FritzDeviceInfoService(q, r, t), FritzDeviceInfoService.ControlUrl, false), q => q.GetSecurityPortAsync(new DeviceInfoGetSecurityPortRequest()));
    }

    public Task<DeviceInfoSetProvisioningCodeResponse> DeviceInfoSetProvisioningCodeAsync(InternetGatewayDevice internetGatewayDevice, string provisioningCode)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzDeviceInfoServiceClientFactory, (q, r, t) => new FritzDeviceInfoService(q, r, t), FritzDeviceInfoService.ControlUrl), q => q.SetProvisioningCodeAsync(new DeviceInfoSetProvisioningCodeRequest { ProvisioningCode = provisioningCode }));
    }

    public Task<LanConfigSecurityGetAnonymousLoginResponse> LanConfigSecurityGetAnonymousLoginAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanConfigSecurityServiceClientFactory, (q, r, t) => new FritzLanConfigSecurityService(q, r, t), FritzLanConfigSecurityService.ControlUrl, false), q => q.GetAnonymousLoginAsync(new LanConfigSecurityGetAnonymousLoginRequest()));
    }

    public Task<LanConfigSecurityGetCurrentUserResponse> LanConfigSecurityGetCurrentUserAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanConfigSecurityServiceClientFactory, (q, r, t) => new FritzLanConfigSecurityService(q, r, t), FritzLanConfigSecurityService.ControlUrl), q => q.GetCurrentUserAsync(new LanConfigSecurityGetCurrentUserRequest()));
    }

    public Task<LanConfigSecurityGetInfoResponse> LanConfigSecurityGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanConfigSecurityServiceClientFactory, (q, r, t) => new FritzLanConfigSecurityService(q, r, t), FritzLanConfigSecurityService.ControlUrl), q => q.GetInfoAsync(new LanConfigSecurityGetInfoRequest()));
    }

    public Task<LanConfigSecurityGetUserListResponse> LanConfigSecurityGetUserListAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanConfigSecurityServiceClientFactory, (q, r, t) => new FritzLanConfigSecurityService(q, r, t), FritzLanConfigSecurityService.ControlUrl), q => q.GetUserListAsync(new LanConfigSecurityGetUserListRequest()));
    }

    public Task<LanConfigSecuritySetConfigPasswordResponse> LanConfigSecuritySetConfigPasswordAsync(InternetGatewayDevice internetGatewayDevice, string password)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanConfigSecurityServiceClientFactory, (q, r, t) => new FritzLanConfigSecurityService(q, r, t), FritzLanConfigSecurityService.ControlUrl), q => q.SetConfigPasswordAsync(new LanConfigSecuritySetConfigPasswordRequest { Password = password }));
    }

    public Task<Layer3ForwardingGetDefaultConnectionServiceResponse> Layer3ForwardingGetDefaultConnectionServiceAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLayer3ForwardingServiceClientFactory, (q, r, t) => new FritzLayer3ForwardingService(q, r, t!), FritzLayer3ForwardingService.ControlUrl), q => q.GetDefaultConnectionServiceAsync(new Layer3ForwardingGetDefaultConnectionServiceRequest()));
    }

    public Task<WanDslInterfaceConfigGetDslDiagnoseInfoResponse> WanDslInterfaceConfigGetDslDiagnoseInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanDslInterfaceConfigService(q, r, t!), FritzWanDslInterfaceConfigService.ControlUrl), q => q.GetDslDiagnoseInfoAsync(new WanDslInterfaceConfigGetDslDiagnoseInfoRequest()));
    }

    public Task<WanDslInterfaceConfigGetDslInfoResponse> WanDslInterfaceConfigGetDslInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanDslInterfaceConfigService(q, r, t!), FritzWanDslInterfaceConfigService.ControlUrl), q => q.GetDslInfoAsync(new WanDslInterfaceConfigGetDslInfoRequest()));
    }

    public Task<WanDslInterfaceConfigGetInfoResponse> WanDslInterfaceConfigGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanDslInterfaceConfigService(q, r, t!), FritzWanDslInterfaceConfigService.ControlUrl), q => q.GetInfoAsync(new WanDslInterfaceConfigGetInfoRequest()));
    }

    public Task<WanDslInterfaceConfigGetStatisticsTotalResponse> WanDslInterfaceConfigGetStatisticsTotalAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanDslInterfaceConfigService(q, r, t!), FritzWanDslInterfaceConfigService.ControlUrl), q => q.GetStatisticsTotalAsync(new WanDslInterfaceConfigGetStatisticsTotalRequest()));
    }

    public Task<WanIpConnectionGetInfoResponse> WanIpConnectionGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetInfoAsync(new WanIpConnectionGetInfoRequest()));
    }

    public Task<WanIpConnectionGetConnectionTypeInfoResponse> WanIpConnectionGetConnectionTypeInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetConnectionTypeInfoAsync(new WanIpConnectionGetConnectionTypeInfoRequest()));
    }

    public Task<WanIpConnectionGetStatusInfoResponse> WanIpConnectionGetStatusInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetStatusInfoAsync(new WanIpConnectionGetStatusInfoRequest()));
    }

    public Task<WanIpConnectionGetNatRsipStatusResponse> WanIpConnectionGetNatRsipStatusAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetNatRsipStatusAsync(new WanIpConnectionGetNatRsipStatusRequest()));
    }

    public Task<WanIpConnectionGetDnsServersResponse> WanIpConnectionGetDnsServersAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetDnsServersAsync(new WanIpConnectionGetDnsServersRequest()));
    }

    public Task<WanIpConnectionGetPortMappingNumberOfEntriesResponse> WanIpConnectionGetPortMappingNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetPortMappingNumberOfEntriesAsync(new WanIpConnectionGetPortMappingNumberOfEntriesRequest()));
    }

    public Task<WanIpConnectionGetExternalIpAddressResponse> WanIpConnectionGetExternalIpAddressAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetExternalIpAddressAsync(new WanIpConnectionGetExternalIpAddressRequest()));
    }

    public Task<WanPppConnectionGetInfoResponse> WanPppConnectionGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetInfoAsync(new WanPppConnectionGetInfoRequest()));
    }

    public Task<WanPppConnectionGetConnectionTypeInfoResponse> WanPppConnectionGetConnectionTypeInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetConnectionTypeInfoAsync(new WanPppConnectionGetConnectionTypeInfoRequest()));
    }

    public Task<WanPppConnectionGetStatusInfoResponse> WanPppConnectionGetStatusInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetStatusInfoAsync(new WanPppConnectionGetStatusInfoRequest()));
    }

    public Task<WanPppConnectionGetLinkLayerMaxBitRatesResponse> WanPppConnectionGetLinkLayerMaxBitRatesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetLinkLayerMaxBitRatesAsync(new WanPppConnectionGetLinkLayerMaxBitRatesRequest()));
    }

    public Task<WanPppConnectionGetUserNameResponse> WanPppConnectionGetUserNameAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetUserNameAsync(new WanPppConnectionGetUserNameRequest()));
    }

    public Task<WanPppConnectionGetNatRsipStatusResponse> WanPppConnectionGetNatRsipStatusAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetNatRsipStatusAsync(new WanPppConnectionGetNatRsipStatusRequest()));
    }

    public Task<WanPppConnectionGetDnsServersResponse> WanPppConnectionGetDnsServersAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetDnsServersAsync(new WanPppConnectionGetDnsServersRequest()));
    }

    public Task<WanPppConnectionGetPortMappingNumberOfEntriesResponse> WanPppConnectionGetPortMappingNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetPortMappingNumberOfEntriesAsync(new WanPppConnectionGetPortMappingNumberOfEntriesRequest()));
    }

    public Task<WanPppConnectionGetExternalIpAddressResponse> WanPppConnectionGetExternalIpAddressAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetExternalIpAddressAsync(new WanPppConnectionGetExternalIpAddressRequest()));
    }

    public Task<WanPppConnectionGetAutoDisconnectTimeSpanResponse> WanPppConnectionGetAutoDisconnectTimeSpanAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetAutoDisconnectTimeSpanAsync(new WanPppConnectionGetAutoDisconnectTimeSpanRequest()));
    }

    public Task<WanEthernetLinkConfigGetEthernetLinkStatusResponse> WanEthernetLinkConfigGetEthernetLinkStatusAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanEthernetLinkConfigServiceClientFactory, (q, r, t) => new FritzWanEthernetLinkConfigService(q, r, t!), FritzWanEthernetLinkConfigService.ControlUrl), q => q.GetEthernetLinkStatusAsync(new WanEthernetLinkConfigGetEthernetLinkStatusRequest()));
    }

    private static T GetFritzServiceClient<T>(InternetGatewayDevice internetGatewayDevice, IClientFactory<T> clientFactory, Func<FritzServiceEndpointConfiguration, EndpointAddress, NetworkCredential?, T> createService, string controlUrl, bool secure = true)
    {
        return clientFactory.Build(createService, internetGatewayDevice.PreferredLocation, secure, controlUrl, secure ? internetGatewayDevice.SecurityPort : null, internetGatewayDevice.NetworkCredential);
    }
}