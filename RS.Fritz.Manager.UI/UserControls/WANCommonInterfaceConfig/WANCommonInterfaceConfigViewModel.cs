namespace RS.Fritz.Manager.UI
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Threading;
    using CommunityToolkit.Mvvm.Messaging.Messages;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal sealed class WANCommonInterfaceConfigViewModel : FritzServiceViewModel
    {
        private readonly DispatcherTimer autoRefreshTimer;

        private bool autoRefresh;
        //private WANCommonInterfaceConfigGetDSLDiagnoseInfoResponse? wanDslInterfaceConfigGetDSLDiagnoseInfoResponse;
        //private WANCommonInterfaceConfigGetDSLInfoResponse? wanDslInterfaceConfigGetDSLInfoResponse;
        //private WANCommonInterfaceConfigGetStatisticsTotalResponse? wanDslInterfaceConfigGetStatisticsTotalResponse;

        
        public WANCommonInterfaceConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, IFritzServiceOperationHandler fritzServiceOperationHandler)
            : base(deviceLoginInfo, logger, fritzServiceOperationHandler)
        {
            WANCommonInterfaceConfigInfoControlViewModel = new WANCommonInterfaceConfigInfoControlViewModel();
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
        */
        
        /*
        public WANCommonInterfaceConfigGetDSLDiagnoseInfoResponse? WANCommonInterfaceConfigGetDSLDiagnoseInfoResponse
        {
            get => wanCommonInterfaceConfigGetDSLDiagnoseInfoResponse; set { _ = SetProperty(ref wanCommonInterfaceConfigGetDSLDiagnoseInfoResponse, value); }
        }

        public WANCommonInterfaceConfigGetDSLInfoResponse? WANCommonInterfaceConfigGetDSLInfoResponse
        {
            get => wanCommonInterfaceConfigGetDSLInfoResponse; set { _ = SetProperty(ref wanCommonInterfaceConfigGetDSLInfoResponse, value); }
        }

        public WANCommonInterfaceConfigInfoControlViewModel WANCommonInterfaceConfigInfoControlViewModel { get; set; }

        public WANCommonInterfaceConfigGetStatisticsTotalResponse? WANCommonInterfaceConfigGetStatisticsTotalResponse
        {
            get => wanCommonInterfaceConfigGetStatisticsTotalResponse; set { _ = SetProperty(ref wanCommonInterfaceConfigGetStatisticsTotalResponse, value); }
        }
        */

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


        // RoSchmi
        /*
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
        */

        protected override async Task DoExecuteDefaultCommandAsync()
        {
            await Domain.TaskExtensions.WhenAllSafe(new[]
                {
                    GetWanCommonInterfaceConfigGetTotalReceivedBytesAsync(),
                });
        }

        private async Task GetWanCommonInterfaceConfigGetTotalReceivedBytesAsync()
        {
            WanCommonInterfaceConfigGetTotalBytesReceivedResponse = await FritzServiceOperationHandler.GetWanCommonInterfaceConfigGetTotalBytesReceivedAsync();
        }


        private async void AutoRefreshTimerTick(object? sender, EventArgs e)
        {
            if (CanExecuteDefaultCommand)
                await DefaultCommand.ExecuteAsync(false);
        }

        /*
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
        */
    }
}