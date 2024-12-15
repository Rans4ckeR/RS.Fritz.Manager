using System.Net;

namespace RS.Fritz.Manager.API;

internal sealed class FritzManagementServerService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
    : FritzServiceClient<IFritzManagementServerService>(endpointConfiguration, remoteAddress, networkCredential), IFritzManagementServerService
{
    public Task<ManagementServerGetInfoResponse> GetInfoAsync(ManagementServerGetInfoRequest managementServerGetInfoRequest)
        => Channel.GetInfoAsync(managementServerGetInfoRequest);

    public Task<ManagementServerGetTr069FirmwareDownloadEnabledResponse> GetTr069FirmwareDownloadEnabledAsync(ManagementServerGetTr069FirmwareDownloadEnabledRequest managementServerGetTr069FirmwareDownloadEnabledRequest)
        => Channel.GetTr069FirmwareDownloadEnabledAsync(managementServerGetTr069FirmwareDownloadEnabledRequest);

    public Task<ManagementServerSetConnectionRequestAuthenticationResponse> SetConnectionRequestAuthenticationAsync(ManagementServerSetConnectionRequestAuthenticationRequest managementServerSetConnectionRequestAuthenticationRequest)
        => Channel.SetConnectionRequestAuthenticationAsync(managementServerSetConnectionRequestAuthenticationRequest);

    public Task<ManagementServerSetManagementServerPasswordResponse> SetManagementServerPasswordAsync(ManagementServerSetManagementServerPasswordRequest managementServerSetManagementServerPasswordRequest)
        => Channel.SetManagementServerPasswordAsync(managementServerSetManagementServerPasswordRequest);

    public Task<ManagementServerSetManagementServerUrlResponse> SetManagementServerUrlAsync(ManagementServerSetManagementServerUrlRequest managementServerSetManagementServerUrlRequest)
        => Channel.SetManagementServerUrlAsync(managementServerSetManagementServerUrlRequest);

    public Task<ManagementServerSetManagementServerUsernameResponse> SetManagementServerUsernameAsync(ManagementServerSetManagementServerUsernameRequest managementServerSetManagementServerUsernameRequest)
        => Channel.SetManagementServerUsernameAsync(managementServerSetManagementServerUsernameRequest);

    public Task<ManagementServerSetPeriodicInformResponse> SetPeriodicInformAsync(ManagementServerSetPeriodicInformRequest managementServerSetPeriodicInformRequest)
        => Channel.SetPeriodicInformAsync(managementServerSetPeriodicInformRequest);

    public Task<ManagementServerSetTr069EnableResponse> SetTr069EnableAsync(ManagementServerSetTr069EnableRequest managementServerSetTr069EnableRequest)
        => Channel.SetTr069EnableAsync(managementServerSetTr069EnableRequest);

    public Task<ManagementServerSetTr069FirmwareDownloadEnabledResponse> SetTr069FirmwareDownloadEnabledAsync(ManagementServerSetTr069FirmwareDownloadEnabledRequest managementServerSetTr069FirmwareDownloadEnabledRequest)
        => Channel.SetTr069FirmwareDownloadEnabledAsync(managementServerSetTr069FirmwareDownloadEnabledRequest);

    public Task<ManagementServerSetUpgradeManagementResponse> SetUpgradeManagementAsync(ManagementServerSetUpgradeManagementRequest managementServerSetUpgradeManagementRequest)
        => Channel.SetUpgradeManagementAsync(managementServerSetUpgradeManagementRequest);
}