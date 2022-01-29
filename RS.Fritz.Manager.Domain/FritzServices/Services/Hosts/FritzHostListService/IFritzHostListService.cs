namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ServiceModel;
    


    //[ServiceContract(Namespace = "urn:dslforum-org:service:Hosts:1")]
    //[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
    public interface IFritzHostListService
    {
        //public Task<HostsGetHostListResponse> GetHostListAsync(HostsGetHostListRequest hostsGetHostListRequest);
        Task<string> GetHttpResponseAsync();

    }
}
