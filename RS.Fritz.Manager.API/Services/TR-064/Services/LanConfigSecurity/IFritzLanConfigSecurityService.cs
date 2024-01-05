namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:LANConfigSecurity:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzLanConfigSecurityService : IAsyncDisposable
{
    [OperationContract(Action = "urn:dslforum-org:service:LANConfigSecurity:1#X_AVM-DE_GetCurrentUser")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<LanConfigSecurityGetCurrentUserResponse> GetCurrentUserAsync(LanConfigSecurityGetCurrentUserRequest lanConfigSecurityGetCurrentUserRequest);

    [OperationContract(Action = "urn:dslforum-org:service:LANConfigSecurity:1#X_AVM-DE_GetUserList")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<LanConfigSecurityGetUserListResponse> GetUserListAsync(LanConfigSecurityGetUserListRequest lanConfigSecurityGetUserListRequest);

    [OperationContract(Action = "urn:dslforum-org:service:LANConfigSecurity:1#GetInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<LanConfigSecurityGetInfoResponse> GetInfoAsync(LanConfigSecurityGetInfoRequest lanConfigSecurityGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:LANConfigSecurity:1#X_AVM-DE_GetAnonymousLogin")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<LanConfigSecurityGetAnonymousLoginResponse> GetAnonymousLoginAsync(LanConfigSecurityGetAnonymousLoginRequest lanConfigSecurityGetAnonymousLoginRequest);

    [OperationContract(Action = "urn:dslforum-org:service:LANConfigSecurity:1#SetConfigPassword")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<LanConfigSecuritySetConfigPasswordResponse> SetConfigPasswordAsync(LanConfigSecuritySetConfigPasswordRequest lanConfigSecuritySetConfigPasswordRequest);
}