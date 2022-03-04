namespace RS.Fritz.Manager.API
{
    using System.ServiceModel;
    using System.Threading.Tasks;

    [ServiceContract(Namespace = "urn:dslforum-org:service:LANConfigSecurity:1")]
    [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
    public interface IFritzLanConfigSecurityService
    {
        [OperationContract(Action = "urn:dslforum-org:service:LANConfigSecurity:1#X_AVM-DE_GetCurrentUser")]
        public Task<LanConfigSecurityGetCurrentUserResponse> GetCurrentUserAsync(LanConfigSecurityGetCurrentUserRequest lanConfigSecurityGetCurrentUserRequest);

        [OperationContract(Action = "urn:dslforum-org:service:LANConfigSecurity:1#X_AVM-DE_GetUserList")]
        public Task<LanConfigSecurityGetUserListResponse> GetUserListAsync(LanConfigSecurityGetUserListRequest lanConfigSecurityGetUserListRequest);

        [OperationContract(Action = "urn:dslforum-org:service:LANConfigSecurity:1#GetInfo")]
        public Task<LanConfigSecurityGetInfoResponse> GetInfoAsync(LanConfigSecurityGetInfoRequest lanConfigSecurityGetInfoRequest);

        [OperationContract(Action = "urn:dslforum-org:service:LANConfigSecurity:1#X_AVM-DE_GetAnonymousLogin")]
        public Task<LanConfigSecurityGetAnonymousLoginResponse> GetAnonymousLoginAsync(LanConfigSecurityGetAnonymousLoginRequest lanConfigSecurityGetAnonymousLoginRequest);

        [OperationContract(Action = "urn:dslforum-org:service:LANConfigSecurity:1#SetConfigPassword")]
        public Task<LanConfigSecuritySetConfigPasswordResponse> SetConfigPasswordAsync(LanConfigSecuritySetConfigPasswordRequest lanConfigSecuritySetConfigPasswordRequest);
    }
}