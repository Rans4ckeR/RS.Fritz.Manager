namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = $"{UPnPConstants.AvmServiceNamespace}:X_AVM-DE_WANFiber:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanFiberService : IFritzService
{
    static string IFritzService.ControlUrl => "/upnp/control/x_wanfiber";

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:X_AVM-DE_WANFiber:1#GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanFiberGetInfoResponse> GetInfoAsync(WanFiberGetInfoRequest wanFiberGetInfoRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:X_AVM-DE_WANFiber:1#GetInfoGPON")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanFiberGetInfoGponResponse> GetInfoGponAsync(WanFiberGetInfoGponRequest wanFiberGetInfoGponRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:X_AVM-DE_WANFiber:1#GetStatistics")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanFiberGetStatisticsResponse> GetStatisticsAsync(WanFiberGetStatisticsRequest wanFiberGetStatisticsRequest);
}