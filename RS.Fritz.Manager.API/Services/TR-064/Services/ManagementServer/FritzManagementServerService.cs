namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzManagementServerService : FritzServiceClient<IFritzManagementServerService>, IFritzManagementServerService
{
    public const string ControlUrl = "/upnp/control/mgmsrv";

    public FritzManagementServerService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<ManagementServerGetInfoResponse> GetInfoAsync(ManagementServerGetInfoRequest managementServerGetInfoRequest)
    {
        return Channel.GetInfoAsync(managementServerGetInfoRequest);
    }

    public Task<ManagementServerGetTr069FirmwareDownloadEnabledResponse> GetTr069FirmwareDownloadEnabledAsync(ManagementServerGetTr069FirmwareDownloadEnabledRequest managementServerGetTr069FirmwareDownloadEnabledRequest)
    {
        return Channel.GetTr069FirmwareDownloadEnabledAsync(managementServerGetTr069FirmwareDownloadEnabledRequest);
    }
}