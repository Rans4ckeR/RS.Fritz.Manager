namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = $"{UPnPConstants.AvmServiceNamespace}:WANDSLInterfaceConfig:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanDslInterfaceConfigService : IFritzService
{
    static string IFritzService.ControlUrl => "/upnp/control/wandslifconfig1";

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANDSLInterfaceConfig:1#GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanDslInterfaceConfigGetInfoResponse> GetInfoAsync(WanDslInterfaceConfigGetInfoRequest wanDslInterfaceConfigGetInfo);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANDSLInterfaceConfig:1#GetStatisticsTotal")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanDslInterfaceConfigGetStatisticsTotalResponse> GetStatisticsTotalAsync(WanDslInterfaceConfigGetStatisticsTotalRequest wanDslInterfaceConfigGetStatisticsTotalRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANDSLInterfaceConfig:1#X_AVM-DE_GetDSLDiagnoseInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanDslInterfaceConfigGetDslDiagnoseInfoResponse> GetDslDiagnoseInfoAsync(WanDslInterfaceConfigGetDslDiagnoseInfoRequest wanDslInterfaceConfigGetDslDiagnoseInfoRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANDSLInterfaceConfig:1#X_AVM-DE_GetDSLInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanDslInterfaceConfigGetDslInfoResponse> GetDslInfoAsync(WanDslInterfaceConfigGetDslInfoRequest wanDslInterfaceConfigGetDslInfoRequest);
}