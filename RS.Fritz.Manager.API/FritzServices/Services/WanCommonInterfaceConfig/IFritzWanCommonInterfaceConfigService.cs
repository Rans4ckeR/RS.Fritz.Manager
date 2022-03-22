﻿namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:WANCommonInterfaceConfig:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanCommonInterfaceConfigService
{
    [OperationContract(Action = "urn:dslforum-org:service:WANCommonInterfaceConfig:1#GetTotalBytesReceived")]
    public Task<WanCommonInterfaceConfigGetTotalBytesReceivedResponse> GetTotalBytesReceivedAsync(WanCommonInterfaceConfigGetTotalBytesReceivedRequest wanCommonInterfaceConfigGetTotalBytesReceivedRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANCommonInterfaceConfig:1#GetTotalBytesSent")]
    public Task<WanCommonInterfaceConfigGetTotalBytesSentResponse> GetTotalBytesSentAsync(WanCommonInterfaceConfigGetTotalBytesSentRequest wanCommonInterfaceConfigGetTotalBytesSentRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANCommonInterfaceConfig:1#GetCommonLinkProperties")]
    public Task<WanCommonInterfaceConfigGetCommonLinkPropertiesResponse> GetCommonLinkPropertiesAsync(WanCommonInterfaceConfigGetCommonLinkPropertiesRequest wanCommonInterfaceConfigGetCommonLinkPropertiesRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANCommonInterfaceConfig:1#GetTotalPacketsSent")]
    public Task<WanCommonInterfaceConfigGetTotalPacketsSentResponse> GetTotalPacketsSentAsync(WanCommonInterfaceConfigGetTotalPacketsSentRequest wanCommonInterfaceConfigGetTotalPacketsSentRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANCommonInterfaceConfig:1#GetTotalPacketsReceived")]
    public Task<WanCommonInterfaceConfigGetTotalPacketsReceivedResponse> GetTotalPacketsReceivedAsync(WanCommonInterfaceConfigGetTotalPacketsReceivedRequest wanCommonInterfaceConfigGetTotalPacketsReceivedRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANCommonInterfaceConfig:1#X_AVM-DE_SetWANAccessType")]
    public Task<WanCommonInterfaceConfigSetWanAccessTypeResponse> SetWanAccessTypeAsync(WanCommonInterfaceConfigSetWanAccessTypeRequest wanCommonInterfaceConfigSetWanAccessTypeRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANCommonInterfaceConfig:1#X_AVM-DE_GetOnlineMonitor")]
    public Task<WanCommonInterfaceConfigGetOnlineMonitorResponse> GetOnlineMonitorAsync(WanCommonInterfaceConfigGetOnlineMonitorRequest wanCommonInterfaceConfigGetOnlineMonitorRequest);
}