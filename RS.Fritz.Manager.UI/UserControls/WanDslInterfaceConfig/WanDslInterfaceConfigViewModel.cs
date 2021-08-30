namespace RS.Fritz.Manager.UI
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using System.Windows.Threading;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal sealed class WanDslInterfaceConfigViewModel : FritzServiceViewModel
    {
        private readonly IClientFactory<IFritzWanDslInterfaceConfigService> fritzWanDslInterfaceConfigServiceClientFactory;
        private readonly DispatcherTimer autoRefreshTimer;

        private bool autoRefresh = false;
        private WanDslInterfaceConfigGetDSLDiagnoseInfoResponse? wanDslInterfaceConfigGetDSLDiagnoseInfoResponse;
        private WanDslInterfaceConfigGetDSLInfoResponse? wanDslInterfaceConfigGetDSLInfoResponse;
        private WanDslInterfaceConfigGetStatisticsTotalResponse? wanDslInterfaceConfigGetStatisticsTotalResponse;

        public WanDslInterfaceConfigViewModel(ILogger logger, DeviceLoginInfo deviceLoginInfo, IServiceOperationHandler serviceOperationHandler, IClientFactory<IFritzWanDslInterfaceConfigService> fritzWanDslInterfaceConfigServiceClientFactory)
             : base(logger, deviceLoginInfo, serviceOperationHandler)
        {
            this.fritzWanDslInterfaceConfigServiceClientFactory = fritzWanDslInterfaceConfigServiceClientFactory;
            WanDslInterfaceConfigInfoControlViewModel = new WanDslInterfaceConfigInfoControlViewModel();
            autoRefreshTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(3d)
            };
            autoRefreshTimer.Tick += AutoRefreshTimerTick;
        }

        public bool AutoRefresh
        {
            get => autoRefresh;
            set
            {
                if (SetProperty(ref autoRefresh, value))
                {
                    if (value)
                        autoRefreshTimer.Start();
                    else
                        autoRefreshTimer.Stop();
                }
            }
        }

        public WanDslInterfaceConfigGetDSLDiagnoseInfoResponse? WanDslInterfaceConfigGetDSLDiagnoseInfoResponse
        {
            get => wanDslInterfaceConfigGetDSLDiagnoseInfoResponse; set { _ = SetProperty(ref wanDslInterfaceConfigGetDSLDiagnoseInfoResponse, value); }
        }

        public WanDslInterfaceConfigGetDSLInfoResponse? WanDslInterfaceConfigGetDSLInfoResponse
        {
            get => wanDslInterfaceConfigGetDSLInfoResponse; set { _ = SetProperty(ref wanDslInterfaceConfigGetDSLInfoResponse, value); }
        }

        public WanDslInterfaceConfigInfoControlViewModel WanDslInterfaceConfigInfoControlViewModel { get; set; }

        public WanDslInterfaceConfigGetStatisticsTotalResponse? WanDslInterfaceConfigGetStatisticsTotalResponse
        {
            get => wanDslInterfaceConfigGetStatisticsTotalResponse; set { _ = SetProperty(ref wanDslInterfaceConfigGetStatisticsTotalResponse, value); }
        }

        protected override async Task DoExecuteDefaultCommandAsync(NetworkCredential networkCredential)
        {
            await Domain.TaskExtensions.WhenAllSafe(new Task[]
                {
                    GetWanDslInterfaceConfigGetDSLDiagnoseInfoAsync(networkCredential),
                    GetWanDslInterfaceConfigGetDSLInfoAsync(networkCredential),
                    GetWanDslInterfaceConfigGetInfoAsync(networkCredential),
                    GetWanDslInterfaceConfigGetStatisticsTotalAsync(networkCredential)
                });
        }

        private async void AutoRefreshTimerTick(object? sender, EventArgs e)
        {
            if (CanExecuteDefaultCommand)
                await ExecuteDefaultCommandAsync();
        }

        private async Task GetWanDslInterfaceConfigGetDSLDiagnoseInfoAsync(NetworkCredential networkCredential)
        {
            WanDslInterfaceConfigGetDSLDiagnoseInfoResponse = await ServiceOperationHandler.ExecuteAsync(GetFritzWanDslInterfaceConfigServiceClient(DeviceLoginInfo.Device!.SecurityPort!.Value, networkCredential), q => q.GetDSLDiagnoseInfoAsync(new WanDslInterfaceConfigGetDSLDiagnoseInfoRequest()));
        }

        private async Task GetWanDslInterfaceConfigGetDSLInfoAsync(NetworkCredential networkCredential)
        {
            WanDslInterfaceConfigGetDSLInfoResponse = await ServiceOperationHandler.ExecuteAsync(GetFritzWanDslInterfaceConfigServiceClient(DeviceLoginInfo.Device!.SecurityPort!.Value, networkCredential), q => q.GetDSLInfoAsync(new WanDslInterfaceConfigGetDSLInfoRequest()));
        }

        private async Task GetWanDslInterfaceConfigGetInfoAsync(NetworkCredential networkCredential)
        {
            WanDslInterfaceConfigInfoControlViewModel.WanDslInterfaceConfigGetInfoResponse = await ServiceOperationHandler.ExecuteAsync(GetFritzWanDslInterfaceConfigServiceClient(DeviceLoginInfo.Device!.SecurityPort!.Value, networkCredential), q => q.GetInfoAsync(new WanDslInterfaceConfigGetInfoRequest()));
        }

        private async Task GetWanDslInterfaceConfigGetStatisticsTotalAsync(NetworkCredential networkCredential)
        {
            WanDslInterfaceConfigGetStatisticsTotalResponse = await ServiceOperationHandler.ExecuteAsync(GetFritzWanDslInterfaceConfigServiceClient(DeviceLoginInfo.Device!.SecurityPort!.Value, networkCredential), q => q.GetStatisticsTotalAsync(new WanDslInterfaceConfigGetStatisticsTotalRequest()));
        }

        private IFritzWanDslInterfaceConfigService GetFritzWanDslInterfaceConfigServiceClient(ushort port, NetworkCredential networkCredential)
        {
            return fritzWanDslInterfaceConfigServiceClientFactory.Build((q, r, t) => new FritzWanDslInterfaceConfigService(q, r, t!), DeviceLoginInfo.Device!.PreferredLocation, true, FritzWanDslInterfaceConfigService.ControlUrl, port, networkCredential);
        }
    }
}