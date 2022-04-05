namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:WANEthernetLinkConfig:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanEthernetLinkConfigService
{
    [OperationContract(Action = "urn:dslforum-org:service:WANEthernetLinkConfig:1#GetEthernetLinkStatus")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WanEthernetLinkConfigGetEthernetLinkStatusResponse> GetEthernetLinkStatusAsync(WanEthernetLinkConfigGetEthernetLinkStatusRequest wanEthernetLinkConfigGetEthernetLinkStatusRequest);
}