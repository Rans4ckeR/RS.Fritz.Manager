namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;
    using System.Threading.Tasks;

    [ServiceContract(Namespace = "urn:dslforum-org:service:WANPPPConnection:1")]
    [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
    public interface IFritzWanPppConnectionService
    {
        [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetInfo")]
        public Task<WanPppConnectionGetInfoResponse> GetInfoAsync(WanPppConnectionGetInfoRequest wanPppConnectionGetInfoRequest);
    }
}