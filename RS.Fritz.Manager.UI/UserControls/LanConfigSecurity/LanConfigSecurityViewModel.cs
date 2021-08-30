namespace RS.Fritz.Manager.UI
{
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal sealed class LanConfigSecurityViewModel : FritzServiceViewModel
    {
        private readonly IClientFactory<IFritzLanConfigSecurityService> fritzLanConfigSecurityServiceClientFactory;
        private readonly LanConfigSecuritySetConfigPasswordViewModel lanConfigSecuritySetConfigPasswordViewModel;

        private LanConfigSecurityGetAnonymousLoginResponse? lanConfigSecurityGetAnonymousLoginResponse;
        private LanConfigSecurityGetCurrentUserResponse? lanConfigSecurityGetCurrentUserResponse;
        private LanConfigSecurityGetInfoResponse? lanConfigSecurityGetInfoResponse;
        private LanConfigSecurityGetUserListResponse? lanConfigSecurityGetUserListResponse;

        public LanConfigSecurityViewModel(ILogger logger, DeviceLoginInfo deviceLoginInfo, LanConfigSecuritySetConfigPasswordViewModel lanConfigSecuritySetConfigPasswordViewModel, IServiceOperationHandler serviceOperationHandler, IClientFactory<IFritzLanConfigSecurityService> fritzLanConfigSecurityServiceClientFactory)
              : base(logger, deviceLoginInfo, serviceOperationHandler)
        {
            this.fritzLanConfigSecurityServiceClientFactory = fritzLanConfigSecurityServiceClientFactory;
            this.lanConfigSecuritySetConfigPasswordViewModel = lanConfigSecuritySetConfigPasswordViewModel;
        }

        public LanConfigSecuritySetConfigPasswordViewModel LanConfigSecuritySetConfigPasswordViewModel
        {
            get => lanConfigSecuritySetConfigPasswordViewModel;
        }

        public LanConfigSecurityGetAnonymousLoginResponse? LanConfigSecurityGetAnonymousLoginResponse
        {
            get => lanConfigSecurityGetAnonymousLoginResponse; set { _ = SetProperty(ref lanConfigSecurityGetAnonymousLoginResponse, value); }
        }

        public LanConfigSecurityGetCurrentUserResponse? LanConfigSecurityGetCurrentUserResponse
        {
            get => lanConfigSecurityGetCurrentUserResponse; set { _ = SetProperty(ref lanConfigSecurityGetCurrentUserResponse, value); }
        }

        public LanConfigSecurityGetInfoResponse? LanConfigSecurityGetInfoResponse
        {
            get => lanConfigSecurityGetInfoResponse; set { _ = SetProperty(ref lanConfigSecurityGetInfoResponse, value); }
        }

        public LanConfigSecurityGetUserListResponse? LanConfigSecurityGetUserListResponse
        {
            get => lanConfigSecurityGetUserListResponse; set { _ = SetProperty(ref lanConfigSecurityGetUserListResponse, value); }
        }

        protected override async Task DoExecuteDefaultCommandAsync(NetworkCredential networkCredential)
        {
            await Domain.TaskExtensions.WhenAllSafe(new Task[]
                {
                    GetLanConfigSecurityGetAnonymousLoginAsync(),
                    GetLanConfigSecurityGetCurrentUserAsync(networkCredential),
                    GetLanConfigSecurityGetInfoAsync(networkCredential),
                    GetLanConfigSecurityGetUserListAsync(networkCredential)
                });
        }

        private async Task GetLanConfigSecurityGetAnonymousLoginAsync()
        {
            LanConfigSecurityGetAnonymousLoginResponse = await ServiceOperationHandler.ExecuteAsync(GetFritzLanConfigSecurityServiceClient(true, DeviceLoginInfo.Device!.SecurityPort), q => q.GetAnonymousLoginAsync(new LanConfigSecurityGetAnonymousLoginRequest()));
        }

        private async Task GetLanConfigSecurityGetCurrentUserAsync(NetworkCredential networkCredential)
        {
            LanConfigSecurityGetCurrentUserResponse = await ServiceOperationHandler.ExecuteAsync(GetFritzLanConfigSecurityServiceClient(true, DeviceLoginInfo.Device!.SecurityPort, networkCredential), q => q.GetCurrentUserAsync(new LanConfigSecurityGetCurrentUserRequest()));
        }

        private async Task GetLanConfigSecurityGetInfoAsync(NetworkCredential networkCredential)
        {
            LanConfigSecurityGetInfoResponse = await ServiceOperationHandler.ExecuteAsync(GetFritzLanConfigSecurityServiceClient(true, DeviceLoginInfo.Device!.SecurityPort, networkCredential), q => q.GetInfoAsync(new LanConfigSecurityGetInfoRequest()));
        }

        private async Task GetLanConfigSecurityGetUserListAsync(NetworkCredential networkCredential)
        {
            LanConfigSecurityGetUserListResponse = await ServiceOperationHandler.ExecuteAsync(GetFritzLanConfigSecurityServiceClient(true, DeviceLoginInfo.Device!.SecurityPort, networkCredential), q => q.GetUserListAsync(new LanConfigSecurityGetUserListRequest()));
        }

        private IFritzLanConfigSecurityService GetFritzLanConfigSecurityServiceClient(bool secure = true, ushort? port = null, NetworkCredential? networkCredential = null)
        {
            return fritzLanConfigSecurityServiceClientFactory.Build((q, r, t) => new FritzLanConfigSecurityService(q, r, t), DeviceLoginInfo.Device!.PreferredLocation, secure, FritzLanConfigSecurityService.ControlUrl, port, networkCredential);
        }
    }
}