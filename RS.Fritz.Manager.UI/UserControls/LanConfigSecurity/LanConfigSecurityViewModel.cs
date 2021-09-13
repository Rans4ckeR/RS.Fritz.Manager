namespace RS.Fritz.Manager.UI
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal sealed class LanConfigSecurityViewModel : FritzServiceViewModel
    {
        private LanConfigSecurityGetAnonymousLoginResponse? lanConfigSecurityGetAnonymousLoginResponse;
        private LanConfigSecurityGetCurrentUserResponse? lanConfigSecurityGetCurrentUserResponse;
        private LanConfigSecurityGetInfoResponse? lanConfigSecurityGetInfoResponse;
        private LanConfigSecurityGetUserListResponse? lanConfigSecurityGetUserListResponse;

        public LanConfigSecurityViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, LanConfigSecuritySetConfigPasswordViewModel lanConfigSecuritySetConfigPasswordViewModel, IFritzServiceOperationHandler fritzServiceOperationHandler)
            : base(deviceLoginInfo, logger, fritzServiceOperationHandler)
        {
            LanConfigSecuritySetConfigPasswordViewModel = lanConfigSecuritySetConfigPasswordViewModel;
        }

        public LanConfigSecuritySetConfigPasswordViewModel LanConfigSecuritySetConfigPasswordViewModel { get; }

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

        protected override async Task DoExecuteDefaultCommandAsync()
        {
            await Domain.TaskExtensions.WhenAllSafe(new[]
                {
                    GetLanConfigSecurityGetAnonymousLoginAsync(),
                    GetLanConfigSecurityGetCurrentUserAsync(),
                    GetLanConfigSecurityGetInfoAsync(),
                    GetLanConfigSecurityGetUserListAsync()
                });
        }

        private async Task GetLanConfigSecurityGetAnonymousLoginAsync()
        {
            LanConfigSecurityGetAnonymousLoginResponse = await FritzServiceOperationHandler.LanConfigSecurityGetAnonymousLoginAsync();
        }

        private async Task GetLanConfigSecurityGetCurrentUserAsync()
        {
            LanConfigSecurityGetCurrentUserResponse = await FritzServiceOperationHandler.LanConfigSecurityGetCurrentUserAsync();
        }

        private async Task GetLanConfigSecurityGetInfoAsync()
        {
            LanConfigSecurityGetInfoResponse = await FritzServiceOperationHandler.LanConfigSecurityGetInfoAsync();
        }

        private async Task GetLanConfigSecurityGetUserListAsync()
        {
            LanConfigSecurityGetUserListResponse = await FritzServiceOperationHandler.LanConfigSecurityGetUserListAsync();
        }
    }
}