namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = $"{UPnPConstants.AvmServiceNamespace}:WANEthernetLinkConfig:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanEthernetLinkConfigService : IAsyncDisposable
{
    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANEthernetLinkConfig:1#GetEthernetLinkStatus")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanEthernetLinkConfigGetEthernetLinkStatusResponse> GetEthernetLinkStatusAsync(WanEthernetLinkConfigGetEthernetLinkStatusRequest wanEthernetLinkConfigGetEthernetLinkStatusRequest);
}