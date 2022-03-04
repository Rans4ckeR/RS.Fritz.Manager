﻿namespace RS.Fritz.Manager.API
{
    using System.ServiceModel;
    using System.Threading.Tasks;

    [ServiceContract(Namespace = "urn:dslforum-org:service:WANCommonInterfaceConfig:1")]
    [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
    public interface IFritzWanCommonInterfaceConfigService
    {
        [OperationContract(Action = "urn:dslforum-org:service:WANCommonInterfaceConfig:1#GetTotalBytesReceived")]
        public Task<WanCommonInterfaceConfigGetTotalBytesReceivedResponse> GetTotalBytesReceivedAsync(WanCommonInterfaceConfigGetTotalBytesReceivedRequest wanCommonInterfaceConfigGetTotalBytesReceivedRequest);

        [OperationContract(Action = "urn:dslforum-org:service:WANCommonInterfaceConfig:1#GetTotalBytesSent")]
        public Task<WanCommonInterfaceConfigGetTotalBytesSentResponse> GetTotalBytesSentAsync(WanCommonInterfaceConfigGetTotalBytesSentRequest wanCommonInterfaceConfigGetTotalBytesSentRequest);

        [OperationContract(Action = "urn:dslforum-org:service:WANCommonInterfaceConfig:1#GetCommonLinkProperties")]
        public Task<WanCommonInterfaceConfigGetCommonLinkPropertiesResponse> GetCommonLinkPropertiesAsync(WanCommonInterfaceConfigGetCommonLinkPropertiesRequest wanCommonInterfaceConfigGetCommonLinkPropertiesRequest);
    }
}