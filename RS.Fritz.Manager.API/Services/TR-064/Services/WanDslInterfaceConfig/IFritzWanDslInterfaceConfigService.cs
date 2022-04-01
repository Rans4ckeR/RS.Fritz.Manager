namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:WANDSLInterfaceConfig:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanDslInterfaceConfigService
{
    [OperationContract(Action = "urn:dslforum-org:service:WANDSLInterfaceConfig:1#GetInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<WanDslInterfaceConfigGetInfoResponse> GetInfoAsync(WanDslInterfaceConfigGetInfoRequest wanDslInterfaceConfigGetInfo);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLInterfaceConfig:1#GetStatisticsTotal")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<WanDslInterfaceConfigGetStatisticsTotalResponse> GetStatisticsTotalAsync(WanDslInterfaceConfigGetStatisticsTotalRequest wanDslInterfaceConfigGetStatisticsTotalRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLInterfaceConfig:1#X_AVM-DE_GetDSLDiagnoseInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<WanDslInterfaceConfigGetDslDiagnoseInfoResponse> GetDslDiagnoseInfoAsync(WanDslInterfaceConfigGetDslDiagnoseInfoRequest wanDslInterfaceConfigGetDslDiagnoseInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLInterfaceConfig:1#X_AVM-DE_GetDSLInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<WanDslInterfaceConfigGetDslInfoResponse> GetDslInfoAsync(WanDslInterfaceConfigGetDslInfoRequest wanDslInterfaceConfigGetDslInfoRequest);
}