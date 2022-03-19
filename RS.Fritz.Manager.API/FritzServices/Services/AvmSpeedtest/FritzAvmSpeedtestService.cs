namespace RS.Fritz.Manager.API;

using System.Net;
using System.ServiceModel;
using System.Threading.Tasks;

internal sealed class FritzAvmSpeedtestService : FritzServiceClient<IFritzAvmSpeedtestService>, IFritzAvmSpeedtestService
{
    public const string ControlUrl = "/upnp/control/x_speedtest";

    public FritzAvmSpeedtestService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<AvmSpeedtestGetInfoResponse> GetInfoAsync(AvmSpeedtestGetInfoRequest avmSpeedtestGetInfoRequest)
    {
        return Channel.GetInfoAsync(avmSpeedtestGetInfoRequest);
    }
}