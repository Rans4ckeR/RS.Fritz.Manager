namespace RS.Fritz.Manager.UI
{
    using System;
    using System.ComponentModel;
    using System.Net;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using System.Windows.Threading;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using CommunityToolkit.Mvvm.Messaging;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal sealed class WanDslInterfaceConfigViewModel : ObservableObject
    {
        private readonly IServiceOperationHandler serviceOperationHandler;
        private readonly IClientFactory<IFritzWanDslInterfaceConfigService> fritzWanDslInterfaceConfigServiceClientFactory;
        private readonly ILogger logger;
        private readonly DispatcherTimer autoRefreshTimer;

        private bool getWanDslInterfaceConfigCommand = false;
        private bool canExecuteWanDslInterfaceConfig = false;
        private bool autoRefresh = false;
        private DeviceLoginInfo deviceLoginInfo;
        private WanDslInterfaceConfigGetDSLDiagnoseInfoResponse? wanDslInterfaceConfigGetDSLDiagnoseInfoResponse;
        private WanDslInterfaceConfigGetDSLInfoResponse? wanDslInterfaceConfigGetDSLInfoResponse;
        private WanDslInterfaceConfigGetStatisticsTotalResponse? wanDslInterfaceConfigGetStatisticsTotalResponse;

        public WanDslInterfaceConfigViewModel(ILogger logger, DeviceLoginInfo deviceLoginInfo, IServiceOperationHandler serviceOperationHandler, IClientFactory<IFritzWanDslInterfaceConfigService> fritzWanDslInterfaceConfigServiceClientFactory)
        {
            this.deviceLoginInfo = deviceLoginInfo;
            this.serviceOperationHandler = serviceOperationHandler;
            this.fritzWanDslInterfaceConfigServiceClientFactory = fritzWanDslInterfaceConfigServiceClientFactory;
            this.logger = logger;
            GetWanDslInterfaceConfigCommand = new AsyncRelayCommand(GetExecuteWanDslInterfaceConfigAsync, () => CanExecuteGetWanDslInterfaceConfig);
            WanDslInterfaceConfigInfoControlViewModel = new WanDslInterfaceConfigInfoControlViewModel();
            deviceLoginInfo.PropertyChanged += DeviceLoginInfoPropertyChanged;
            PropertyChanged += WanDslInterfaceConfigViewModelPropertyChanged;
            autoRefreshTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(3)
            };
            autoRefreshTimer.Tick += AutoRefreshTimerTick;

            WeakReferenceMessenger.Default.Register<DeviceLoginInfoValueChangedMessage>(this, (r, m) =>
            {
                ((WanDslInterfaceConfigViewModel)r).DeviceLoginInfo = m.Value;
            });
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

        public DeviceLoginInfo DeviceLoginInfo
        {
            get => deviceLoginInfo;
            set
            {
                if (SetProperty(ref deviceLoginInfo, value))
                    GetWanDslInterfaceConfigCommand.NotifyCanExecuteChanged();
            }
        }

        public IAsyncRelayCommand GetWanDslInterfaceConfigCommand { get; }

        public bool CanExecuteGetWanDslInterfaceConfig
        {
            get => canExecuteWanDslInterfaceConfig;
            set
            {
                if (SetProperty(ref canExecuteWanDslInterfaceConfig, value))
                    GetWanDslInterfaceConfigCommand.NotifyCanExecuteChanged();
            }
        }

        public bool GetWanDslInterfaceConfigCommandActive
        {
            get => getWanDslInterfaceConfigCommand;
            set
            {
                if (value)
                    Mouse.OverrideCursor = Cursors.Wait;
                else
                    Mouse.OverrideCursor = null;

                if (SetProperty(ref getWanDslInterfaceConfigCommand, value))
                    GetWanDslInterfaceConfigCommand.NotifyCanExecuteChanged();
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

        private async void AutoRefreshTimerTick(object? sender, EventArgs e)
        {
            if (CanExecuteGetWanDslInterfaceConfig)
                await GetExecuteWanDslInterfaceConfigAsync();
        }

        private async Task GetExecuteWanDslInterfaceConfigAsync()
        {
            try
            {
                GetWanDslInterfaceConfigCommandActive = true;

                var networkCredential = new NetworkCredential(deviceLoginInfo.User!.Name, deviceLoginInfo.Password);

                await Domain.TaskExtensions.WhenAllSafe(new Task[]
                    {
                        GetWanDslInterfaceConfigGetDSLDiagnoseInfoAsync(networkCredential),
                        GetWanDslInterfaceConfigGetDSLInfoAsync(networkCredential),
                        GetWanDslInterfaceConfigGetInfoAsync(networkCredential),
                        GetWanDslInterfaceConfigGetStatisticsTotalAsync(networkCredential)
                    });

                WeakReferenceMessenger.Default.Send(new ActiveViewValueChangedMessage(this));
            }
            catch (Exception ex)
            {
                logger.ExceptionThrown(ex);
            }
            finally
            {
                GetWanDslInterfaceConfigCommandActive = false;
            }
        }

        private void DeviceLoginInfoPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(deviceLoginInfo.Device):
                case nameof(deviceLoginInfo.User):
                case nameof(deviceLoginInfo.Password):
                    {
                        UpdateCanExecuteGetWanDslInterfaceConfig();
                        break;
                    }

                default:
                    break;
            }
        }

        private void WanDslInterfaceConfigViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(GetWanDslInterfaceConfigCommandActive):
                    {
                        UpdateCanExecuteGetWanDslInterfaceConfig();
                        break;
                    }

                default:
                    break;
            }
        }

        private async Task GetWanDslInterfaceConfigGetDSLDiagnoseInfoAsync(NetworkCredential networkCredential)
        {
            WanDslInterfaceConfigGetDSLDiagnoseInfoResponse = await serviceOperationHandler.ExecuteAsync(GetFritzWanDslInterfaceConfigServiceClient(deviceLoginInfo.Device!.SecurityPort!.Value, networkCredential), q => q.GetDSLDiagnoseInfoAsync(new WanDslInterfaceConfigGetDSLDiagnoseInfoRequest()));
        }

        private async Task GetWanDslInterfaceConfigGetDSLInfoAsync(NetworkCredential networkCredential)
        {
            WanDslInterfaceConfigGetDSLInfoResponse = await serviceOperationHandler.ExecuteAsync(GetFritzWanDslInterfaceConfigServiceClient(deviceLoginInfo.Device!.SecurityPort!.Value, networkCredential), q => q.GetDSLInfoAsync(new WanDslInterfaceConfigGetDSLInfoRequest()));
        }

        private async Task GetWanDslInterfaceConfigGetInfoAsync(NetworkCredential networkCredential)
        {
            WanDslInterfaceConfigInfoControlViewModel.WanDslInterfaceConfigGetInfoResponse = await serviceOperationHandler.ExecuteAsync(GetFritzWanDslInterfaceConfigServiceClient(deviceLoginInfo.Device!.SecurityPort!.Value, networkCredential), q => q.GetInfoAsync(new WanDslInterfaceConfigGetInfoRequest()));
        }

        private async Task GetWanDslInterfaceConfigGetStatisticsTotalAsync(NetworkCredential networkCredential)
        {
            WanDslInterfaceConfigGetStatisticsTotalResponse = await serviceOperationHandler.ExecuteAsync(GetFritzWanDslInterfaceConfigServiceClient(deviceLoginInfo.Device!.SecurityPort!.Value, networkCredential), q => q.GetStatisticsTotalAsync(new WanDslInterfaceConfigGetStatisticsTotalRequest()));
        }

        private IFritzWanDslInterfaceConfigService GetFritzWanDslInterfaceConfigServiceClient(ushort port, NetworkCredential networkCredential)
        {
            return fritzWanDslInterfaceConfigServiceClientFactory.Build((q, r, t) => new FritzWanDslInterfaceConfigService(q, r, t!), deviceLoginInfo.Device!.PreferredLocation, true, FritzWanDslInterfaceConfigService.ControlUrl, port, networkCredential);
        }

        private void UpdateCanExecuteGetWanDslInterfaceConfig()
        {
            CanExecuteGetWanDslInterfaceConfig = deviceLoginInfo.Device is not null && deviceLoginInfo.User is not null && !string.IsNullOrWhiteSpace(deviceLoginInfo.Password) && !GetWanDslInterfaceConfigCommandActive;
        }
    }
}