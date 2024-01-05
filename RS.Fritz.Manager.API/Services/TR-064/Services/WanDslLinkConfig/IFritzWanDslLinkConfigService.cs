namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:WANDSLLinkConfig:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanDslLinkConfigService : IAsyncDisposable
{
    [OperationContract(Action = "urn:dslforum-org:service:WANDSLLinkConfig:1#GetInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WanDslLinkConfigGetInfoResponse> GetInfoAsync(WanDslLinkConfigGetInfoRequest wanDslLinkConfigGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLLinkConfig:1#GetDSLLinkInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WanDslLinkConfigGetDslLinkInfoResponse> GetDslLinkInfoAsync(WanDslLinkConfigGetDslLinkInfoRequest wanDslLinkConfigGetDslLinkInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLLinkConfig:1#GetDestinationAddress")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WanDslLinkConfigGetDestinationAddressResponse> GetDestinationAddressAsync(WanDslLinkConfigGetDestinationAddressRequest wanDslLinkConfigGetDestinationAddressRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLLinkConfig:1#GetATMEncapsulation")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WanDslLinkConfigGetAtmEncapsulationResponse> GetAtmEncapsulationAsync(WanDslLinkConfigGetAtmEncapsulationRequest wanDslLinkConfigGetAtmEncapsulationRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLLinkConfig:1#GetAutoConfig")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WanDslLinkConfigGetAutoConfigResponse> GetAutoConfigAsync(WanDslLinkConfigGetAutoConfigRequest wanDslLinkConfigGetAutoConfigRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLLinkConfig:1#GetStatistics")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WanDslLinkConfigGetStatisticsResponse> GetStatisticsAsync(WanDslLinkConfigGetStatisticsRequest wanDslLinkConfigGetStatisticsRequest);
}