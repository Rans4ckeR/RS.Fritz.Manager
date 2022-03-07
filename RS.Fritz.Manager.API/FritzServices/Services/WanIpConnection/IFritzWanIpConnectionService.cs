namespace RS.Fritz.Manager.API
{
    using System.ServiceModel;
    using System.Threading.Tasks;

    [ServiceContract(Namespace = "urn:dslforum-org:service:WANIPConnection:1")]
    [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
    public interface IFritzWanIpConnectionService
    {
        [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#GetInfo")]
        public Task<WanIpConnectionGetInfoResponse> GetInfoAsync(WanIpConnectionGetInfoRequest wanIpConnectionGetInfoRequest);
    }
}