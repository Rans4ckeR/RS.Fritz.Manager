namespace RS.Fritz.Manager.UI
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Threading;
    using CommunityToolkit.Mvvm.Messaging.Messages;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal sealed class WanDslInterfaceConfigViewModel : FritzServiceViewModel
    {
        private readonly DispatcherTimer autoRefreshTimer;

        private bool autoRefresh;
        private WanDslInterfaceConfigGetDSLDiagnoseInfoResponse? wanDslInterfaceConfigGetDSLDiagnoseInfoResponse;
        private WanDslInterfaceConfigGetDSLInfoResponse? wanDslInterfaceConfigGetDSLInfoResponse;
        private WanDslInterfaceConfigGetStatisticsTotalResponse? wanDslInterfaceConfigGetStatisticsTotalResponse;

        public WanDslInterfaceConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, IFritzServiceOperationHandler fritzServiceOperationHandler)
            : base(deviceLoginInfo, logger, fritzServiceOperationHandler)
        {
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

        public override void Receive(PropertyChangedMessage<bool> message)
        {
            base.Receive(message);

            if (message.Sender != DeviceLoginInfo)
                return;

            switch (message.PropertyName)
            {
                case nameof(DeviceLoginInfo.LoginInfoSet):
                    {
                        if (!message.NewValue)
                            AutoRefresh = false;
                        break;
                    }
            }
        }

        protected override async Task DoExecuteDefaultCommandAsync()
        {
            await Domain.TaskExtensions.WhenAllSafe(new[]
                {
                    GetWanDslInterfaceConfigGetDSLDiagnoseInfoAsync(),
                    GetWanDslInterfaceConfigGetDSLInfoAsync(),
                    GetWanDslInterfaceConfigGetInfoAsync(),
                    GetWanDslInterfaceConfigGetStatisticsTotalAsync()
                });
        }

        private async void AutoRefreshTimerTick(object? sender, EventArgs e)
        {
            if (CanExecuteDefaultCommand)
                await DefaultCommand.ExecuteAsync(false);
        }

        private async Task GetWanDslInterfaceConfigGetDSLDiagnoseInfoAsync()
        {
            WanDslInterfaceConfigGetDSLDiagnoseInfoResponse = await FritzServiceOperationHandler.WanDslInterfaceConfigGetDSLDiagnoseInfoAsync();
        }

        private async Task GetWanDslInterfaceConfigGetDSLInfoAsync()
        {
            WanDslInterfaceConfigGetDSLInfoResponse = await FritzServiceOperationHandler.WanDslInterfaceConfigGetDSLInfoAsync();
        }

        private async Task GetWanDslInterfaceConfigGetInfoAsync()
        {
            WanDslInterfaceConfigInfoControlViewModel.WanDslInterfaceConfigGetInfoResponse = await FritzServiceOperationHandler.WanDslInterfaceConfigGetInfoAsync();
        }

        private async Task GetWanDslInterfaceConfigGetStatisticsTotalAsync()
        {
            WanDslInterfaceConfigGetStatisticsTotalResponse = await FritzServiceOperationHandler.WanDslInterfaceConfigGetStatisticsTotalAsync();
        }
    }
}