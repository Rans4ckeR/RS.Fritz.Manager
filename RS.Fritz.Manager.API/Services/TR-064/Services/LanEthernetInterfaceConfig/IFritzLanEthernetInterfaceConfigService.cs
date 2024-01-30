namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = $"{UPnPConstants.AvmServiceNamespace}:LANEthernetInterfaceConfig:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzLanEthernetInterfaceConfigService : IAsyncDisposable
{
    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:LANEthernetInterfaceConfig:1#GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<LanEthernetInterfaceConfigGetInfoResponse> GetInfoAsync(LanEthernetInterfaceConfigGetInfoRequest lanEthernetInterfaceConfigGetInfoRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:LANEthernetInterfaceConfig:1#GetStatistics")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<LanEthernetInterfaceConfigGetStatisticsResponse> GetStatisticsAsync(LanEthernetInterfaceConfigGetStatisticsRequest lanEthernetInterfaceConfigGetStatisticsRequest);
}