namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:WANDSLLinkConfig:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanDslLinkConfigService
{
    [OperationContract(Action = "urn:dslforum-org:service:WANDSLLinkConfig:1#GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WanDslLinkConfigGetInfoResponse> GetInfoAsync(WanDslLinkConfigGetInfoRequest wanDslLinkConfigGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLLinkConfig:1#GetDSLLinkInfo")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WanDslLinkConfigGetDslLinkInfoResponse> GetDslLinkInfoAsync(WanDslLinkConfigGetDslLinkInfoRequest wanDslLinkConfigGetDslLinkInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLLinkConfig:1#GetDestinationAddress")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WanDslLinkConfigGetDestinationAddressResponse> GetDestinationAddressAsync(WanDslLinkConfigGetDestinationAddressRequest wanDslLinkConfigGetDestinationAddressRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLLinkConfig:1#GetATMEncapsulation")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WanDslLinkConfigGetAtmEncapsulationResponse> GetAtmEncapsulationAsync(WanDslLinkConfigGetAtmEncapsulationRequest wanDslLinkConfigGetAtmEncapsulationRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLLinkConfig:1#GetAutoConfig")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WanDslLinkConfigGetAutoConfigResponse> GetAutoConfigAsync(WanDslLinkConfigGetAutoConfigRequest wanDslLinkConfigGetAutoConfigRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLLinkConfig:1#GetStatistics")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WanDslLinkConfigGetStatisticsResponse> GetStatisticsAsync(WanDslLinkConfigGetStatisticsRequest wanDslLinkConfigGetStatisticsRequest);
}