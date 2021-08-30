namespace RS.Fritz.Manager.UI
{
    using System;
    using System.ComponentModel;
    using System.Net;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using CommunityToolkit.Mvvm.Messaging;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal sealed class WanPppConnectionViewModel : ObservableObject
    {
        private readonly IServiceOperationHandler serviceOperationHandler;
        private readonly IClientFactory<IFritzWanPppConnectionService> fritzWanPppConnectionServiceClientFactory;
        private readonly ILogger logger;

        private bool getInfoCommandActive = false;
        private bool canExecuteGetInfo = false;
        private DeviceLoginInfo deviceLoginInfo;
        private WanPppConnectionGetInfoResponse? wanPppConnectionGetInfoResponse;

        public WanPppConnectionViewModel(ILogger logger, DeviceLoginInfo deviceLoginInfo, IServiceOperationHandler serviceOperationHandler, IClientFactory<IFritzWanPppConnectionService> fritzWanPppConnectionServiceClientFactory)
        {
            this.deviceLoginInfo = deviceLoginInfo;
            this.serviceOperationHandler = serviceOperationHandler;
            this.fritzWanPppConnectionServiceClientFactory = fritzWanPppConnectionServiceClientFactory;
            this.logger = logger;
            GetInfoCommand = new AsyncRelayCommand(GetInfoAsync, () => CanExecuteGetInfo);
            deviceLoginInfo.PropertyChanged += DeviceLoginInfoPropertyChanged;
            PropertyChanged += WanPppConnectionViewModelPropertyChanged;

            WeakReferenceMessenger.Default.Register<DeviceLoginInfoValueChangedMessage>(this, (r, m) =>
            {
                ((WanPppConnectionViewModel)r).DeviceLoginInfo = m.Value;
            });
        }

        public DeviceLoginInfo DeviceLoginInfo
        {
            get => deviceLoginInfo;
            set
            {
                if (SetProperty(ref deviceLoginInfo, value))
                    GetInfoCommand.NotifyCanExecuteChanged();
            }
        }

        public IAsyncRelayCommand GetInfoCommand { get; }

        public bool CanExecuteGetInfo
        {
            get => canExecuteGetInfo;
            set
            {
                if (SetProperty(ref canExecuteGetInfo, value))
                    GetInfoCommand.NotifyCanExecuteChanged();
            }
        }

        public WanPppConnectionGetInfoResponse? WanPppConnectionGetInfoResponse
        {
            get => wanPppConnectionGetInfoResponse; set { _ = SetProperty(ref wanPppConnectionGetInfoResponse, value); }
        }

        public bool GetInfoCommandActive
        {
            get => getInfoCommandActive;
            set
            {
                if (value)
                    Mouse.OverrideCursor = Cursors.Wait;
                else
                    Mouse.OverrideCursor = null;

                if (SetProperty(ref getInfoCommandActive, value))
                    GetInfoCommand.NotifyCanExecuteChanged();
            }
        }

        private async Task GetInfoAsync()
        {
            try
            {
                GetInfoCommandActive = true;

                var networkCredential = new NetworkCredential(deviceLoginInfo.User!.Name, deviceLoginInfo.Password);

                await WanPppConnectionGetInfoAsync(networkCredential);

                WeakReferenceMessenger.Default.Send(new ActiveViewValueChangedMessage(this));
            }
            catch (Exception ex)
            {
                logger.ExceptionThrown(ex);
            }
            finally
            {
                GetInfoCommandActive = false;
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
                        UpdateCanExecuteGetInfo();
                        break;
                    }

                default:
                    break;
            }
        }

        private void WanPppConnectionViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(GetInfoCommandActive):
                    {
                        UpdateCanExecuteGetInfo();
                        break;
                    }

                default:
                    break;
            }
        }

        private async Task WanPppConnectionGetInfoAsync(NetworkCredential networkCredential)
        {
            WanPppConnectionGetInfoResponse = await serviceOperationHandler.ExecuteAsync(GetFritzWanPppConnectionServiceClient(deviceLoginInfo.Device!.SecurityPort!.Value, networkCredential), q => q.GetInfoAsync(new WanPppConnectionGetInfoRequest()));
        }

        private IFritzWanPppConnectionService GetFritzWanPppConnectionServiceClient(ushort port, NetworkCredential networkCredential)
        {
            return fritzWanPppConnectionServiceClientFactory.Build((q, r, t) => new FritzWanPppConnectionService(q, r, t!), deviceLoginInfo.Device!.PreferredLocation, true, FritzWanPppConnectionService.ControlUrl, port, networkCredential);
        }

        private void UpdateCanExecuteGetInfo()
        {
            CanExecuteGetInfo = deviceLoginInfo.Device is not null && deviceLoginInfo.User is not null && !string.IsNullOrWhiteSpace(deviceLoginInfo.Password) && !GetInfoCommandActive;
        }
    }
}