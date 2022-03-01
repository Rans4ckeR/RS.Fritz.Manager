namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Net;
    using System.Threading.Tasks;

    public interface IFritzHttpOperationHandler
    {
        InternetGatewayDevice? InternetGatewayDevice { get; set; }

        NetworkCredential? NetworkCredential { get; set; }

        Task<string> GetHostsGetHostListAsync(Uri uri);
    }
}