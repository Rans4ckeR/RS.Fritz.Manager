namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = $"{UPnPConstants.AvmServiceNamespace}:WANDSLLinkConfig:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanDslLinkConfigService : IFritzService
{
    static string IFritzService.ControlUrl => "/upnp/control/wandsllinkconfig1";

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANDSLLinkConfig:1#GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanDslLinkConfigGetInfoResponse> GetInfoAsync(WanDslLinkConfigGetInfoRequest wanDslLinkConfigGetInfoRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANDSLLinkConfig:1#GetDSLLinkInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanDslLinkConfigGetDslLinkInfoResponse> GetDslLinkInfoAsync(WanDslLinkConfigGetDslLinkInfoRequest wanDslLinkConfigGetDslLinkInfoRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANDSLLinkConfig:1#GetDestinationAddress")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanDslLinkConfigGetDestinationAddressResponse> GetDestinationAddressAsync(WanDslLinkConfigGetDestinationAddressRequest wanDslLinkConfigGetDestinationAddressRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANDSLLinkConfig:1#GetATMEncapsulation")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanDslLinkConfigGetAtmEncapsulationResponse> GetAtmEncapsulationAsync(WanDslLinkConfigGetAtmEncapsulationRequest wanDslLinkConfigGetAtmEncapsulationRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANDSLLinkConfig:1#GetAutoConfig")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanDslLinkConfigGetAutoConfigResponse> GetAutoConfigAsync(WanDslLinkConfigGetAutoConfigRequest wanDslLinkConfigGetAutoConfigRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANDSLLinkConfig:1#GetStatistics")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanDslLinkConfigGetStatisticsResponse> GetStatisticsAsync(WanDslLinkConfigGetStatisticsRequest wanDslLinkConfigGetStatisticsRequest);
}