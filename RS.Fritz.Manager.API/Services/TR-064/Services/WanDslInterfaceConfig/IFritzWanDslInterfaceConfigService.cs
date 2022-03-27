namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:WANDSLInterfaceConfig:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanDslInterfaceConfigService
{
    [OperationContract(Action = "urn:dslforum-org:service:WANDSLInterfaceConfig:1#GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WanDslInterfaceConfigGetInfoResponse> GetInfoAsync(WanDslInterfaceConfigGetInfoRequest wanDslInterfaceConfigGetInfo);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLInterfaceConfig:1#GetStatisticsTotal")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WanDslInterfaceConfigGetStatisticsTotalResponse> GetStatisticsTotalAsync(WanDslInterfaceConfigGetStatisticsTotalRequest wanDslInterfaceConfigGetStatisticsTotalRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLInterfaceConfig:1#X_AVM-DE_GetDSLDiagnoseInfo")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WanDslInterfaceConfigGetDslDiagnoseInfoResponse> GetDslDiagnoseInfoAsync(WanDslInterfaceConfigGetDslDiagnoseInfoRequest wanDslInterfaceConfigGetDslDiagnoseInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLInterfaceConfig:1#X_AVM-DE_GetDSLInfo")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WanDslInterfaceConfigGetDslInfoResponse> GetDslInfoAsync(WanDslInterfaceConfigGetDslInfoRequest wanDslInterfaceConfigGetDslInfoRequest);
}