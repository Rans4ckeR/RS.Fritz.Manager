namespace RS.Fritz.Manager.API;

using System.ServiceModel;
using System.Threading.Tasks;

[ServiceContract(Namespace = "urn:dslforum-org:service:WANDSLLinkConfig:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanDslLinkConfigService
{
    [OperationContract(Action = "urn:dslforum-org:service:WANDSLLinkConfig:1#GetInfo")]
    public Task<WanDslLinkConfigGetInfoResponse> GetInfoAsync(WanDslLinkConfigGetInfoRequest wanDslLinkConfigGetInfoRequest);
}