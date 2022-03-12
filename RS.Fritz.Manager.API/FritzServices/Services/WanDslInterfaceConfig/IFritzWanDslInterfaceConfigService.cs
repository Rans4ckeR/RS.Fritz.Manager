﻿namespace RS.Fritz.Manager.API;

using System.ServiceModel;
using System.Threading.Tasks;

[ServiceContract(Namespace = "urn:dslforum-org:service:WANDSLInterfaceConfig:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanDslInterfaceConfigService
{
    [OperationContract(Action = "urn:dslforum-org:service:WANDSLInterfaceConfig:1#GetInfo")]
    public Task<WanDslInterfaceConfigGetInfoResponse> GetInfoAsync(WanDslInterfaceConfigGetInfoRequest wanDslInterfaceConfigGetInfo);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLInterfaceConfig:1#GetStatisticsTotal")]
    public Task<WanDslInterfaceConfigGetStatisticsTotalResponse> GetStatisticsTotalAsync(WanDslInterfaceConfigGetStatisticsTotalRequest wanDslInterfaceConfigGetStatisticsTotalRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLInterfaceConfig:1#X_AVM-DE_GetDSLDiagnoseInfo")]
    public Task<WanDslInterfaceConfigGetDslDiagnoseInfoResponse> GetDslDiagnoseInfoAsync(WanDslInterfaceConfigGetDslDiagnoseInfoRequest wanDslInterfaceConfigGetDslDiagnoseInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANDSLInterfaceConfig:1#X_AVM-DE_GetDSLInfo")]
    public Task<WanDslInterfaceConfigGetDslInfoResponse> GetDslInfoAsync(WanDslInterfaceConfigGetDslInfoRequest wanDslInterfaceConfigGetDslInfoRequest);
}