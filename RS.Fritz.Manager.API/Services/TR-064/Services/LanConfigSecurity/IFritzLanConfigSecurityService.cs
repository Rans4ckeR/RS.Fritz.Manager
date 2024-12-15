namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = $"{UPnPConstants.AvmServiceNamespace}:LANConfigSecurity:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzLanConfigSecurityService : IFritzService
{
    static string IFritzService.ControlUrl => "/upnp/control/lanconfigsecurity";

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:LANConfigSecurity:1#X_AVM-DE_GetCurrentUser")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<LanConfigSecurityGetCurrentUserResponse> GetCurrentUserAsync(LanConfigSecurityGetCurrentUserRequest lanConfigSecurityGetCurrentUserRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:LANConfigSecurity:1#X_AVM-DE_GetUserList")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<LanConfigSecurityGetUserListResponse> GetUserListAsync(LanConfigSecurityGetUserListRequest lanConfigSecurityGetUserListRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:LANConfigSecurity:1#GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<LanConfigSecurityGetInfoResponse> GetInfoAsync(LanConfigSecurityGetInfoRequest lanConfigSecurityGetInfoRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:LANConfigSecurity:1#X_AVM-DE_GetAnonymousLogin")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<LanConfigSecurityGetAnonymousLoginResponse> GetAnonymousLoginAsync(LanConfigSecurityGetAnonymousLoginRequest lanConfigSecurityGetAnonymousLoginRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:LANConfigSecurity:1#SetConfigPassword")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<LanConfigSecuritySetConfigPasswordResponse> SetConfigPasswordAsync(LanConfigSecuritySetConfigPasswordRequest lanConfigSecuritySetConfigPasswordRequest);
}