namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;
    using System.Threading.Tasks;

    [ServiceContract(Namespace = "urn:dslforum-org:service:Hosts:1")]
    [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
    public interface IFritzHostsService
    {
        [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#GetHostNumberOfEntries")]
        public Task<HostsGetHostNumberOfEntriesResponse> GetHostNumberOfEntriesAsync(HostsGetHostNumberOfEntriesRequest hostGetHostNumberOfEntriesRequest);    
    }
}
