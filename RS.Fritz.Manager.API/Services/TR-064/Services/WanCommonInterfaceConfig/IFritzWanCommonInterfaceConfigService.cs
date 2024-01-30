namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = $"{UPnPConstants.AvmServiceNamespace}:WANCommonInterfaceConfig:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanCommonInterfaceConfigService : IAsyncDisposable
{
    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANCommonInterfaceConfig:1#GetTotalBytesReceived")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanCommonInterfaceConfigGetTotalBytesReceivedResponse> GetTotalBytesReceivedAsync(WanCommonInterfaceConfigGetTotalBytesReceivedRequest wanCommonInterfaceConfigGetTotalBytesReceivedRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANCommonInterfaceConfig:1#GetTotalBytesSent")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanCommonInterfaceConfigGetTotalBytesSentResponse> GetTotalBytesSentAsync(WanCommonInterfaceConfigGetTotalBytesSentRequest wanCommonInterfaceConfigGetTotalBytesSentRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANCommonInterfaceConfig:1#GetCommonLinkProperties")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanCommonInterfaceConfigGetCommonLinkPropertiesResponse> GetCommonLinkPropertiesAsync(WanCommonInterfaceConfigGetCommonLinkPropertiesRequest wanCommonInterfaceConfigGetCommonLinkPropertiesRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANCommonInterfaceConfig:1#GetTotalPacketsSent")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanCommonInterfaceConfigGetTotalPacketsSentResponse> GetTotalPacketsSentAsync(WanCommonInterfaceConfigGetTotalPacketsSentRequest wanCommonInterfaceConfigGetTotalPacketsSentRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANCommonInterfaceConfig:1#GetTotalPacketsReceived")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanCommonInterfaceConfigGetTotalPacketsReceivedResponse> GetTotalPacketsReceivedAsync(WanCommonInterfaceConfigGetTotalPacketsReceivedRequest wanCommonInterfaceConfigGetTotalPacketsReceivedRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANCommonInterfaceConfig:1#X_AVM-DE_SetWANAccessType")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanCommonInterfaceConfigSetWanAccessTypeResponse> SetWanAccessTypeAsync(WanCommonInterfaceConfigSetWanAccessTypeRequest wanCommonInterfaceConfigSetWanAccessTypeRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANCommonInterfaceConfig:1#X_AVM-DE_GetOnlineMonitor")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanCommonInterfaceConfigGetOnlineMonitorResponse> GetOnlineMonitorAsync(WanCommonInterfaceConfigGetOnlineMonitorRequest wanCommonInterfaceConfigGetOnlineMonitorRequest);
}