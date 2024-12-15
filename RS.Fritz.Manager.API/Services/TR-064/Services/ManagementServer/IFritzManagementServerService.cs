namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = $"{UPnPConstants.AvmServiceNamespace}:ManagementServer:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzManagementServerService : IFritzService
{
    static string IFritzService.ControlUrl => "/upnp/control/mgmsrv";

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:ManagementServer:1#GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<ManagementServerGetInfoResponse> GetInfoAsync(ManagementServerGetInfoRequest managementServerGetInfoRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:ManagementServer:1#X_AVM-DE_GetTR069FirmwareDownloadEnabled")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<ManagementServerGetTr069FirmwareDownloadEnabledResponse> GetTr069FirmwareDownloadEnabledAsync(ManagementServerGetTr069FirmwareDownloadEnabledRequest managementServerGetTr069FirmwareDownloadEnabledRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:ManagementServer:1#SetManagementServerURL")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<ManagementServerSetManagementServerUrlResponse> SetManagementServerUrlAsync(ManagementServerSetManagementServerUrlRequest managementServerSetManagementServerUrlRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:ManagementServer:1#SetManagementServerUsername")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<ManagementServerSetManagementServerUsernameResponse> SetManagementServerUsernameAsync(ManagementServerSetManagementServerUsernameRequest managementServerSetManagementServerUsernameRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:ManagementServer:1#SetManagementServerPassword")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<ManagementServerSetManagementServerPasswordResponse> SetManagementServerPasswordAsync(ManagementServerSetManagementServerPasswordRequest managementServerSetManagementServerPasswordRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:ManagementServer:1#SetPeriodicInform")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<ManagementServerSetPeriodicInformResponse> SetPeriodicInformAsync(ManagementServerSetPeriodicInformRequest managementServerSetPeriodicInformRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:ManagementServer:1#SetConnectionRequestAuthentication")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<ManagementServerSetConnectionRequestAuthenticationResponse> SetConnectionRequestAuthenticationAsync(ManagementServerSetConnectionRequestAuthenticationRequest managementServerSetConnectionRequestAuthenticationRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:ManagementServer:1#SetUpgradeManagement")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<ManagementServerSetUpgradeManagementResponse> SetUpgradeManagementAsync(ManagementServerSetUpgradeManagementRequest managementServerSetUpgradeManagementRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:ManagementServer:1#X_SetTR069Enable")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<ManagementServerSetTr069EnableResponse> SetTr069EnableAsync(ManagementServerSetTr069EnableRequest managementServerSetTr069EnableRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:ManagementServer:1#X_AVM-DE_SetTR069FirmwareDownloadEnabled")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<ManagementServerSetTr069FirmwareDownloadEnabledResponse> SetTr069FirmwareDownloadEnabledAsync(ManagementServerSetTr069FirmwareDownloadEnabledRequest managementServerSetTr069FirmwareDownloadEnabledRequest);
}