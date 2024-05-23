namespace RS.Fritz.Manager.API;

using System.ServiceModel.Channels;

internal sealed class FritzWanCommonInterfaceConfigService(Binding binding, EndpointAddress remoteAddress)
    : ClientBase<IFritzWanCommonInterfaceConfigService>(binding, remoteAddress), IFritzWanCommonInterfaceConfigService
{
    public Task<WanCommonInterfaceConfigGetCommonLinkPropertiesResponse> GetCommonLinkPropertiesAsync(WanCommonInterfaceConfigGetCommonLinkPropertiesRequest wanCommonInterfaceConfigGetCommonLinkPropertiesRequest)
        => Channel.GetCommonLinkPropertiesAsync(wanCommonInterfaceConfigGetCommonLinkPropertiesRequest);

    public Task<WanCommonInterfaceConfigGetTotalBytesReceivedResponse> GetTotalBytesReceivedAsync(WanCommonInterfaceConfigGetTotalBytesReceivedRequest wanCommonInterfaceConfigGetTotalBytesReceivedRequest)
        => Channel.GetTotalBytesReceivedAsync(wanCommonInterfaceConfigGetTotalBytesReceivedRequest);

    public Task<WanCommonInterfaceConfigGetTotalBytesSentResponse> GetTotalBytesSentAsync(WanCommonInterfaceConfigGetTotalBytesSentRequest wanCommonInterfaceConfigGetTotalBytesSentRequest)
        => Channel.GetTotalBytesSentAsync(wanCommonInterfaceConfigGetTotalBytesSentRequest);

    public Task<WanCommonInterfaceConfigGetTotalPacketsReceivedResponse> GetTotalPacketsReceivedAsync(WanCommonInterfaceConfigGetTotalPacketsReceivedRequest wanCommonInterfaceConfigGetTotalPacketsReceivedRequest)
        => Channel.GetTotalPacketsReceivedAsync(wanCommonInterfaceConfigGetTotalPacketsReceivedRequest);

    public Task<WanCommonInterfaceConfigGetTotalPacketsSentResponse> GetTotalPacketsSentAsync(WanCommonInterfaceConfigGetTotalPacketsSentRequest wanCommonInterfaceConfigGetTotalPacketsSentRequest)
        => Channel.GetTotalPacketsSentAsync(wanCommonInterfaceConfigGetTotalPacketsSentRequest);

    public Task<WanCommonInterfaceConfigSetWanAccessTypeResponse> SetWanAccessTypeAsync(WanCommonInterfaceConfigSetWanAccessTypeRequest wanCommonInterfaceConfigSetWanAccessTypeRequest)
        => Channel.SetWanAccessTypeAsync(wanCommonInterfaceConfigSetWanAccessTypeRequest);

    public Task<WanCommonInterfaceConfigGetOnlineMonitorResponse> GetOnlineMonitorAsync(WanCommonInterfaceConfigGetOnlineMonitorRequest wanCommonInterfaceConfigGetOnlineMonitorRequest)
        => Channel.GetOnlineMonitorAsync(wanCommonInterfaceConfigGetOnlineMonitorRequest);
}