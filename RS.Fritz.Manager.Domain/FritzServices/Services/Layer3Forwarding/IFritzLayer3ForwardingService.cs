namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;
    using System.Threading.Tasks;

    [ServiceContract(Namespace = "urn:dslforum-org:service:Layer3Forwarding:1")]
    [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
    public interface IFritzLayer3ForwardingService
    {
        [OperationContract(Action = "urn:dslforum-org:service:Layer3Forwarding:1#GetDefaultConnectionService")]
        public Task<Layer3ForwardingGetDefaultConnectionServiceResponse> GetDefaultConnectionServiceAsync(Layer3ForwardingGetDefaultConnectionServiceRequest layer3ForwardingGetDefaultConnectionServiceRequest);
    }
}