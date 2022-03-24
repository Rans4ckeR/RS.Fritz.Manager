namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:WANDSLLinkConfig:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanDslLinkConfigService
{
    [OperationContract(Action = "urn:dslforum-org:service:WANDSLLinkConfig:1#GetInfo")]
    public Task<WanDslLinkConfigGetInfoResponse> GetInfoAsync(WanDslLinkConfigGetInfoRequest wanDslLinkConfigGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLLinkConfig:1#GetDSLLinkInfo")]
    public Task<WanDslLinkConfigGetDslLinkInfoResponse> GetDslLinkInfoAsync(WanDslLinkConfigGetDslLinkInfoRequest wanDslLinkConfigGetDslLinkInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLLinkConfig:1#GetDestinationAddress")]
    public Task<WanDslLinkConfigGetDestinationAddressResponse> GetDestinationAddressAsync(WanDslLinkConfigGetDestinationAddressRequest wanDslLinkConfigGetDestinationAddressRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLLinkConfig:1#GetATMEncapsulation")]
    public Task<WanDslLinkConfigGetAtmEncapsulationResponse> GetAtmEncapsulationAsync(WanDslLinkConfigGetAtmEncapsulationRequest wanDslLinkConfigGetAtmEncapsulationRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLLinkConfig:1#GetAutoConfig")]
    public Task<WanDslLinkConfigGetAutoConfigResponse> GetAutoConfigAsync(WanDslLinkConfigGetAutoConfigRequest wanDslLinkConfigGetAutoConfigRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLLinkConfig:1#GetStatistics")]
    public Task<WanDslLinkConfigGetStatisticsResponse> GetStatisticsAsync(WanDslLinkConfigGetStatisticsRequest wanDslLinkConfigGetStatisticsRequest);
}