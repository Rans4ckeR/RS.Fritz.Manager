namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:LANEthernetInterfaceConfig:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzLanEthernetInterfaceConfigService
{
    [OperationContract(Action = "urn:dslforum-org:service:LANEthernetInterfaceConfig:1#GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    public Task<LanEthernetInterfaceConfigGetInfoResponse> GetInfoAsync(LanEthernetInterfaceConfigGetInfoRequest lanEthernetInterfaceConfigGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:LANEthernetInterfaceConfig:1#GetStatistics")]
    [FaultContract(typeof(UPnPFault))]
    public Task<LanEthernetInterfaceConfigGetStatisticsResponse> GetStatisticsAsync(LanEthernetInterfaceConfigGetStatisticsRequest lanEthernetInterfaceConfigGetStatisticsRequest);
}