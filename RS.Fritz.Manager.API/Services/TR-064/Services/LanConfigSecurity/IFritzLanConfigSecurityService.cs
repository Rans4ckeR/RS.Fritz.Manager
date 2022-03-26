namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:LANConfigSecurity:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzLanConfigSecurityService
{
    [OperationContract(Action = "urn:dslforum-org:service:LANConfigSecurity:1#X_AVM-DE_GetCurrentUser")]
    [FaultContract(typeof(FritzFaultContract), Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
    [XmlSerializerFormat(SupportFaults = true)]
    public Task<LanConfigSecurityGetCurrentUserResponse> GetCurrentUserAsync(LanConfigSecurityGetCurrentUserRequest lanConfigSecurityGetCurrentUserRequest);

    [OperationContract(Action = "urn:dslforum-org:service:LANConfigSecurity:1#X_AVM-DE_GetUserList")]
    [FaultContract(typeof(FritzFaultContract), Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
    [XmlSerializerFormat(SupportFaults = true)]
    public Task<LanConfigSecurityGetUserListResponse> GetUserListAsync(LanConfigSecurityGetUserListRequest lanConfigSecurityGetUserListRequest);

    [OperationContract(Action = "urn:dslforum-org:service:LANConfigSecurity:1#GetInfo")]
    [FaultContract(typeof(FritzFaultContract), Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
    [XmlSerializerFormat(SupportFaults = true)]
    public Task<LanConfigSecurityGetInfoResponse> GetInfoAsync(LanConfigSecurityGetInfoRequest lanConfigSecurityGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:LANConfigSecurity:1#X_AVM-DE_GetAnonymousLogin")]
    [FaultContract(typeof(FritzFaultContract), Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
    [XmlSerializerFormat(SupportFaults = true)]
    public Task<LanConfigSecurityGetAnonymousLoginResponse> GetAnonymousLoginAsync(LanConfigSecurityGetAnonymousLoginRequest lanConfigSecurityGetAnonymousLoginRequest);

    [OperationContract(Action = "urn:dslforum-org:service:LANConfigSecurity:1#SetConfigPassword")]
    [FaultContract(typeof(FritzFaultContract), Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
    [XmlSerializerFormat(SupportFaults = true)]
    public Task<LanConfigSecuritySetConfigPasswordResponse> SetConfigPasswordAsync(LanConfigSecuritySetConfigPasswordRequest lanConfigSecuritySetConfigPasswordRequest);
}