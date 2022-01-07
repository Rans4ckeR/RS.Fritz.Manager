﻿namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;
    using System.Threading.Tasks;

    [ServiceContract(Namespace = "urn:dslforum-org:service:WANCommonInterfaceConfig:1")]
    [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
    public interface IFritzWanCommonInterfaceConfigService
    {
        // [OperationContract(Action = "urn:dslforum-org:service:WANCommonInterfaceConfig:1#GetInfo")]
        [OperationContract(Action = "urn:dslforum-org:service:WANCommonInterfaceConfig:1#GetTotalBytesReceived")]
        
        public Task<WanCommonInterfaceConfigGetTotalBytesReceivedResponse> GetTotalBytesReceivedAsync(WanCommonInterfaceConfigGetTotalBytesReceivedRequest wanCommonInterfaceConfigGetTotalBytesReceivedRequest);
        
        
        
        
        /*
        [OperationContract(Action = "urn:dslforum-org:service:WANDSLInterfaceConfig:1#GetStatisticsTotal")]
        public Task<WanDslInterfaceConfigGetStatisticsTotalResponse> GetStatisticsTotalAsync(WanDslInterfaceConfigGetStatisticsTotalRequest wanDslInterfaceConfigGetStatisticsTotalRequest);

        [OperationContract(Action = "urn:dslforum-org:service:WANDSLInterfaceConfig:1#X_AVM-DE_GetDSLDiagnoseInfo")]
        public Task<WanDslInterfaceConfigGetDSLDiagnoseInfoResponse> GetDSLDiagnoseInfoAsync(WanDslInterfaceConfigGetDSLDiagnoseInfoRequest wanDslInterfaceConfigGetDSLDiagnoseInfoRequest);

        [OperationContract(Action = "urn:dslforum-org:service:WANDSLInterfaceConfig:1#X_AVM-DE_GetDSLInfo")]
        public Task<WanDslInterfaceConfigGetDSLInfoResponse> GetDSLInfoAsync(WanDslInterfaceConfigGetDSLInfoRequest wanDslInterfaceConfigGetDSLInfoRequest);
        */
    }
}