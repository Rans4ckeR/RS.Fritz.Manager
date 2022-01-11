﻿
namespace RS.Fritz.Manager.Domain
{
    using System.Net;
    using System.ServiceModel;
    using System.Threading.Tasks;

    public sealed class FritzHostsService : FritzServiceClient<IFritzHostsService>, IFritzHostsService
    {
        public const string ControlUrl = "/upnp/control/hosts";


        // Constructor
        public FritzHostsService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
            : base(endpointConfiguration, remoteAddress, networkCredential)
        {
        }

        public Task<HostsGetHostNumberOfEntriesResponse> GetHostNumberOfEntriesAsync(HostsGetHostNumberOfEntriesRequest hostsGetHostNumberOfEntriesRequest)
        {
            return Channel.GetHostNumberOfEntriesAsync(hostsGetHostNumberOfEntriesRequest);
        }      
    }
}