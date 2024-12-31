using System.Net;
using Microsoft.Extensions.Logging;

namespace RS.Fritz.Manager.API;

internal sealed class FritzTimeService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential, ILoggerFactory loggerFactory)
    : FritzServiceClient<IFritzTimeService>(endpointConfiguration, remoteAddress, networkCredential, loggerFactory), IFritzTimeService
{
    public Task<TimeGetInfoResponse> GetInfoAsync(TimeGetInfoRequest timeGetInfoRequest)
        => Channel.GetInfoAsync(timeGetInfoRequest);

    public Task<TimeSetNtpServersResponse> SetNtpServersAsync(TimeSetNtpServersRequest timeSetNtpServersRequest)
        => Channel.SetNtpServersAsync(timeSetNtpServersRequest);
}