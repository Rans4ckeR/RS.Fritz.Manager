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
    private readonly IClientFactory<IFritzWanDslLinkConfigService> fritzWanDslLinkConfigServiceClientFactory;
    private readonly IClientFactory<IFritzAvmSpeedtestService> fritzAvmSpeedtestServiceClientFactory;

    public FritzServiceOperationHandler(
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
        IClientFactory<IFritzAvmSpeedtestService> fritzAvmSpeedtestServiceClientFactory)
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
        this.fritzWanDslLinkConfigServiceClientFactory = fritzWanDslLinkConfigServiceClientFactory;
        this.fritzAvmSpeedtestServiceClientFactory = fritzAvmSpeedtestServiceClientFactory;
    }

    public Task<HostsGetHostNumberOfEntriesResponse> HostsGetHostNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzHostsServiceClientFactory, (q, r, t) => new FritzHostsService(q, r, t!), FritzHostsService.ControlUrl), q => q.GetHostNumberOfEntriesAsync(default));
    }

    public Task<HostsGetHostListPathResponse> HostsGetHostListPathAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzHostsServiceClientFactory, (q, r, t) => new FritzHostsService(q, r, t!), FritzHostsService.ControlUrl), q => q.GetHostListPathAsync(default));
    }

    public Task<HostsGetGenericHostEntryResponse> HostsGetGenericHostEntryAsync(InternetGatewayDevice internetGatewayDevice, ushort index)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzHostsServiceClientFactory, (q, r, t) => new FritzHostsService(q, r, t!), FritzHostsService.ControlUrl), q => q.GetGenericHostEntryAsync(new HostsGetGenericHostEntryRequest { Index = index }));
    }

    public Task<HostsGetChangeCounterResponse> HostsGetChangeCounterAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzHostsServiceClientFactory, (q, r, t) => new FritzHostsService(q, r, t!), FritzHostsService.ControlUrl), q => q.GetChangeCounterAsync(default));
    }

    public Task<HostsGetMeshListPathResponse> HostsGetMeshListPathAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzHostsServiceClientFactory, (q, r, t) => new FritzHostsService(q, r, t!), FritzHostsService.ControlUrl), q => q.GetMeshListPathAsync(default));
    }

    public Task<WanCommonInterfaceConfigGetCommonLinkPropertiesResponse> WanCommonInterfaceConfigGetCommonLinkPropertiesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetCommonLinkPropertiesAsync(default));
    }

    public Task<WanCommonInterfaceConfigGetTotalBytesReceivedResponse> WanCommonInterfaceConfigGetTotalBytesReceivedAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetTotalBytesReceivedAsync(default));
    }

    public Task<WanCommonInterfaceConfigGetTotalBytesSentResponse> WanCommonInterfaceConfigGetTotalBytesSentAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetTotalBytesSentAsync(default));
    }

    public Task<WanCommonInterfaceConfigGetTotalPacketsReceivedResponse> WanCommonInterfaceConfigGetTotalPacketsReceivedAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetTotalPacketsReceivedAsync(default));
    }

    public Task<WanCommonInterfaceConfigGetTotalPacketsSentResponse> WanCommonInterfaceConfigGetTotalPacketsSentAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetTotalPacketsSentAsync(default));
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
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzDeviceInfoServiceClientFactory, (q, r, t) => new FritzDeviceInfoService(q, r, t), FritzDeviceInfoService.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<DeviceInfoGetDeviceLogResponse> DeviceInfoGetDeviceLogAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzDeviceInfoServiceClientFactory, (q, r, t) => new FritzDeviceInfoService(q, r, t), FritzDeviceInfoService.ControlUrl), q => q.GetDeviceLogAsync(default));
    }

    public Task<DeviceInfoGetSecurityPortResponse> DeviceInfoGetSecurityPortAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzDeviceInfoServiceClientFactory, (q, r, t) => new FritzDeviceInfoService(q, r, t), FritzDeviceInfoService.ControlUrl, false), q => q.GetSecurityPortAsync(default));
    }

    public Task<DeviceInfoSetProvisioningCodeResponse> DeviceInfoSetProvisioningCodeAsync(InternetGatewayDevice internetGatewayDevice, string provisioningCode)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzDeviceInfoServiceClientFactory, (q, r, t) => new FritzDeviceInfoService(q, r, t), FritzDeviceInfoService.ControlUrl), q => q.SetProvisioningCodeAsync(new DeviceInfoSetProvisioningCodeRequest { ProvisioningCode = provisioningCode }));
    }

    public Task<LanConfigSecurityGetAnonymousLoginResponse> LanConfigSecurityGetAnonymousLoginAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanConfigSecurityServiceClientFactory, (q, r, t) => new FritzLanConfigSecurityService(q, r, t), FritzLanConfigSecurityService.ControlUrl, false), q => q.GetAnonymousLoginAsync(default));
    }

    public Task<LanConfigSecurityGetCurrentUserResponse> LanConfigSecurityGetCurrentUserAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanConfigSecurityServiceClientFactory, (q, r, t) => new FritzLanConfigSecurityService(q, r, t), FritzLanConfigSecurityService.ControlUrl), q => q.GetCurrentUserAsync(default));
    }

    public Task<LanConfigSecurityGetInfoResponse> LanConfigSecurityGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanConfigSecurityServiceClientFactory, (q, r, t) => new FritzLanConfigSecurityService(q, r, t), FritzLanConfigSecurityService.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<LanConfigSecurityGetUserListResponse> LanConfigSecurityGetUserListAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanConfigSecurityServiceClientFactory, (q, r, t) => new FritzLanConfigSecurityService(q, r, t), FritzLanConfigSecurityService.ControlUrl), q => q.GetUserListAsync(default));
    }

    public Task<LanConfigSecuritySetConfigPasswordResponse> LanConfigSecuritySetConfigPasswordAsync(InternetGatewayDevice internetGatewayDevice, string password)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLanConfigSecurityServiceClientFactory, (q, r, t) => new FritzLanConfigSecurityService(q, r, t), FritzLanConfigSecurityService.ControlUrl), q => q.SetConfigPasswordAsync(new LanConfigSecuritySetConfigPasswordRequest { Password = password }));
    }

    public Task<Layer3ForwardingGetDefaultConnectionServiceResponse> Layer3ForwardingGetDefaultConnectionServiceAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLayer3ForwardingServiceClientFactory, (q, r, t) => new FritzLayer3ForwardingService(q, r, t!), FritzLayer3ForwardingService.ControlUrl), q => q.GetDefaultConnectionServiceAsync(default));
    }

    public Task<Layer3ForwardingGetForwardNumberOfEntriesResponse> Layer3ForwardingGetForwardNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLayer3ForwardingServiceClientFactory, (q, r, t) => new FritzLayer3ForwardingService(q, r, t!), FritzLayer3ForwardingService.ControlUrl), q => q.GetForwardNumberOfEntriesAsync(default));
    }

    public Task<Layer3ForwardingGetGenericForwardingEntryResponse> Layer3ForwardingGetGenericForwardingEntryAsync(InternetGatewayDevice internetGatewayDevice, ushort forwardingIndex)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzLayer3ForwardingServiceClientFactory, (q, r, t) => new FritzLayer3ForwardingService(q, r, t!), FritzLayer3ForwardingService.ControlUrl), q => q.GetGenericForwardingEntryAsync(new Layer3ForwardingGetGenericForwardingEntryRequest(forwardingIndex)));
    }

    public Task<WanDslInterfaceConfigGetDslDiagnoseInfoResponse> WanDslInterfaceConfigGetDslDiagnoseInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanDslInterfaceConfigService(q, r, t!), FritzWanDslInterfaceConfigService.ControlUrl), q => q.GetDslDiagnoseInfoAsync(default));
    }

    public Task<WanDslInterfaceConfigGetDslInfoResponse> WanDslInterfaceConfigGetDslInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanDslInterfaceConfigService(q, r, t!), FritzWanDslInterfaceConfigService.ControlUrl), q => q.GetDslInfoAsync(default));
    }

    public Task<WanDslInterfaceConfigGetInfoResponse> WanDslInterfaceConfigGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanDslInterfaceConfigService(q, r, t!), FritzWanDslInterfaceConfigService.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<WanDslInterfaceConfigGetStatisticsTotalResponse> WanDslInterfaceConfigGetStatisticsTotalAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanDslInterfaceConfigService(q, r, t!), FritzWanDslInterfaceConfigService.ControlUrl), q => q.GetStatisticsTotalAsync(default));
    }

    public Task<WanIpConnectionGetInfoResponse> WanIpConnectionGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<WanConnectionGetConnectionTypeInfoResponse> WanIpConnectionGetConnectionTypeInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetConnectionTypeInfoAsync(default));
    }

    public Task<WanConnectionGetStatusInfoResponse> WanIpConnectionGetStatusInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetStatusInfoAsync(default));
    }

    public Task<WanConnectionGetNatRsipStatusResponse> WanIpConnectionGetNatRsipStatusAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetNatRsipStatusAsync(default));
    }

    public Task<WanConnectionGetDnsServersResponse> WanIpConnectionGetDnsServersAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetDnsServersAsync(default));
    }

    public Task<WanConnectionGetPortMappingNumberOfEntriesResponse> WanIpConnectionGetPortMappingNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetPortMappingNumberOfEntriesAsync(default));
    }

    public Task<WanConnectionGetExternalIpAddressResponse> WanIpConnectionGetExternalIpAddressAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetExternalIpAddressAsync(default));
    }

    public Task<WanConnectionGetGenericPortMappingEntryResponse> WanIpConnectionGetGenericPortMappingEntryAsync(InternetGatewayDevice internetGatewayDevice, ushort portMappingIndex)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetGenericPortMappingEntryAsync(new WanConnectionGetGenericPortMappingEntryRequest(portMappingIndex)));
    }

    public Task<WanPppConnectionGetInfoResponse> WanPppConnectionGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<WanConnectionGetConnectionTypeInfoResponse> WanPppConnectionGetConnectionTypeInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetConnectionTypeInfoAsync(default));
    }

    public Task<WanConnectionGetStatusInfoResponse> WanPppConnectionGetStatusInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetStatusInfoAsync(default));
    }

    public Task<WanPppConnectionGetLinkLayerMaxBitRatesResponse> WanPppConnectionGetLinkLayerMaxBitRatesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetLinkLayerMaxBitRatesAsync(default));
    }

    public Task<WanPppConnectionGetUserNameResponse> WanPppConnectionGetUserNameAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetUserNameAsync(default));
    }

    public Task<WanConnectionGetNatRsipStatusResponse> WanPppConnectionGetNatRsipStatusAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetNatRsipStatusAsync(default));
    }

    public Task<WanConnectionGetDnsServersResponse> WanPppConnectionGetDnsServersAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetDnsServersAsync(default));
    }

    public Task<WanConnectionGetPortMappingNumberOfEntriesResponse> WanPppConnectionGetPortMappingNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetPortMappingNumberOfEntriesAsync(default));
    }

    public Task<WanConnectionGetExternalIpAddressResponse> WanPppConnectionGetExternalIpAddressAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetExternalIpAddressAsync(default));
    }

    public Task<WanPppConnectionGetAutoDisconnectTimeSpanResponse> WanPppConnectionGetAutoDisconnectTimeSpanAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetAutoDisconnectTimeSpanAsync(default));
    }

    public Task<WanConnectionGetGenericPortMappingEntryResponse> WanPppConnectionGetGenericPortMappingEntryAsync(InternetGatewayDevice internetGatewayDevice, ushort portMappingIndex)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetGenericPortMappingEntryAsync(new WanConnectionGetGenericPortMappingEntryRequest(portMappingIndex)));
    }

    public Task<WanEthernetLinkConfigGetEthernetLinkStatusResponse> WanEthernetLinkConfigGetEthernetLinkStatusAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanEthernetLinkConfigServiceClientFactory, (q, r, t) => new FritzWanEthernetLinkConfigService(q, r, t!), FritzWanEthernetLinkConfigService.ControlUrl), q => q.GetEthernetLinkStatusAsync(default));
    }

    public Task<WanDslLinkConfigGetInfoResponse> WanDslLinkConfigGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslLinkConfigServiceClientFactory, (q, r, t) => new FritzWanDslLinkConfigService(q, r, t!), FritzWanDslLinkConfigService.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<WanDslLinkConfigGetDslLinkInfoResponse> WanDslLinkConfigGetDslLinkInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslLinkConfigServiceClientFactory, (q, r, t) => new FritzWanDslLinkConfigService(q, r, t!), FritzWanDslLinkConfigService.ControlUrl), q => q.GetDslLinkInfoAsync(default));
    }

    public Task<WanDslLinkConfigGetDestinationAddressResponse> WanDslLinkConfigGetDestinationAddressAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslLinkConfigServiceClientFactory, (q, r, t) => new FritzWanDslLinkConfigService(q, r, t!), FritzWanDslLinkConfigService.ControlUrl), q => q.GetDestinationAddressAsync(default));
    }

    public Task<WanDslLinkConfigGetAtmEncapsulationResponse> WanDslLinkConfigGetAtmEncapsulationAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslLinkConfigServiceClientFactory, (q, r, t) => new FritzWanDslLinkConfigService(q, r, t!), FritzWanDslLinkConfigService.ControlUrl), q => q.GetAtmEncapsulationAsync(default));
    }

    public Task<WanDslLinkConfigGetAutoConfigResponse> WanDslLinkConfigGetAutoConfigAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslLinkConfigServiceClientFactory, (q, r, t) => new FritzWanDslLinkConfigService(q, r, t!), FritzWanDslLinkConfigService.ControlUrl), q => q.GetAutoConfigAsync(default));
    }

    public Task<WanDslLinkConfigGetStatisticsResponse> WanDslLinkConfigGetStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzWanDslLinkConfigServiceClientFactory, (q, r, t) => new FritzWanDslLinkConfigService(q, r, t!), FritzWanDslLinkConfigService.ControlUrl), q => q.GetStatisticsAsync(default));
    }

    public Task<AvmSpeedtestGetInfoResponse> AvmSpeedtestGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, fritzAvmSpeedtestServiceClientFactory, (q, r, t) => new FritzAvmSpeedtestService(q, r, t!), FritzAvmSpeedtestService.ControlUrl), q => q.GetInfoAsync(default));
    }

    private static T GetFritzServiceClient<T>(InternetGatewayDevice internetGatewayDevice, IClientFactory<T> clientFactory, Func<FritzServiceEndpointConfiguration, EndpointAddress, NetworkCredential?, T> createService, string controlUrl, bool secure = true)
    {
        return clientFactory.Build(createService, internetGatewayDevice.PreferredLocation, secure, controlUrl, secure ? internetGatewayDevice.SecurityPort : null, internetGatewayDevice.NetworkCredential);
    }
}