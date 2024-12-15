using System.Net;

namespace RS.Fritz.Manager.API;

internal sealed class FritzTimeService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
    : FritzServiceClient<IFritzTimeService>(endpointConfiguration, remoteAddress, networkCredential), IFritzTimeService
{
    public const string ControlUrl = "/upnp/control/time";

    public Task<TimeGetInfoResponse> GetInfoAsync(TimeGetInfoRequest timeGetInfoRequest)
        => Channel.GetInfoAsync(timeGetInfoRequest);

    public Task<TimeSetNtpServersResponse> SetNtpServersAsync(TimeSetNtpServersRequest timeSetNtpServersRequest)
        => Channel.SetNtpServersAsync(timeSetNtpServersRequest);
}