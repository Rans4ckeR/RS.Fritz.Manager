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

    internal sealed class Layer3ForwardingViewModel : ObservableObject
    {
        private readonly IServiceOperationHandler serviceOperationHandler;
        private readonly IClientFactory<IFritzLayer3ForwardingService> fritzLayer3ForwardingServiceClientFactory;
        private readonly ILogger logger;

        private bool getDefaultConnectionServiceCommandActive = false;
        private bool canExecuteGetDefaultConnectionService = false;
        private DeviceLoginInfo deviceLoginInfo;
        private Layer3ForwardingGetDefaultConnectionServiceResponse? layer3ForwardingGetDefaultConnectionServiceResponse;

        public Layer3ForwardingViewModel(ILogger logger, DeviceLoginInfo deviceLoginInfo, IServiceOperationHandler serviceOperationHandler, IClientFactory<IFritzLayer3ForwardingService> fritzLayer3ForwardingServiceClientFactory)
        {
            this.deviceLoginInfo = deviceLoginInfo;
            this.serviceOperationHandler = serviceOperationHandler;
            this.fritzLayer3ForwardingServiceClientFactory = fritzLayer3ForwardingServiceClientFactory;
            this.logger = logger;
            GetDefaultConnectionServiceCommand = new AsyncRelayCommand(GetDefaultConnectionServiceAsync, () => CanExecuteGetDefaultConnectionService);
            deviceLoginInfo.PropertyChanged += DeviceLoginInfoPropertyChanged;
            PropertyChanged += Layer3ForwardingViewModelPropertyChanged;

            WeakReferenceMessenger.Default.Register<DeviceLoginInfoValueChangedMessage>(this, (r, m) =>
            {
                ((Layer3ForwardingViewModel)r).DeviceLoginInfo = m.Value;
            });
        }

        public DeviceLoginInfo DeviceLoginInfo
        {
            get => deviceLoginInfo;
            set
            {
                if (SetProperty(ref deviceLoginInfo, value))
                    GetDefaultConnectionServiceCommand.NotifyCanExecuteChanged();
            }
        }

        public IAsyncRelayCommand GetDefaultConnectionServiceCommand { get; }

        public bool CanExecuteGetDefaultConnectionService
        {
            get => canExecuteGetDefaultConnectionService;
            set
            {
                if (SetProperty(ref canExecuteGetDefaultConnectionService, value))
                    GetDefaultConnectionServiceCommand.NotifyCanExecuteChanged();
            }
        }

        public Layer3ForwardingGetDefaultConnectionServiceResponse? Layer3ForwardingGetDefaultConnectionServiceResponse
        {
            get => layer3ForwardingGetDefaultConnectionServiceResponse; set { _ = SetProperty(ref layer3ForwardingGetDefaultConnectionServiceResponse, value); }
        }

        public bool GetDefaultConnectionServiceCommandActive
        {
            get => getDefaultConnectionServiceCommandActive;
            set
            {
                if (value)
                    Mouse.OverrideCursor = Cursors.Wait;
                else
                    Mouse.OverrideCursor = null;

                if (SetProperty(ref getDefaultConnectionServiceCommandActive, value))
                    GetDefaultConnectionServiceCommand.NotifyCanExecuteChanged();
            }
        }

        private async Task GetDefaultConnectionServiceAsync()
        {
            try
            {
                GetDefaultConnectionServiceCommandActive = true;

                var networkCredential = new NetworkCredential(deviceLoginInfo.User!.Name, deviceLoginInfo.Password);

                await Layer3ForwardingGetDefaultConnectionServiceAsync(networkCredential);

                WeakReferenceMessenger.Default.Send(new ActiveViewValueChangedMessage(this));
            }
            catch (Exception ex)
            {
                logger.ExceptionThrown(ex);
            }
            finally
            {
                GetDefaultConnectionServiceCommandActive = false;
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
                        UpdateCanExecuteGetDefaultConnectionService();
                        break;
                    }

                default:
                    break;
            }
        }

        private void Layer3ForwardingViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(GetDefaultConnectionServiceCommandActive):
                    {
                        UpdateCanExecuteGetDefaultConnectionService();
                        break;
                    }

                default:
                    break;
            }
        }

        private async Task Layer3ForwardingGetDefaultConnectionServiceAsync(NetworkCredential networkCredential)
        {
            Layer3ForwardingGetDefaultConnectionServiceResponse = await serviceOperationHandler.ExecuteAsync(GetFritzLayer3ForwardingServiceClient(deviceLoginInfo.Device!.SecurityPort!.Value, networkCredential), q => q.GetDefaultConnectionServiceAsync(new Layer3ForwardingGetDefaultConnectionServiceRequest()));
        }

        private IFritzLayer3ForwardingService GetFritzLayer3ForwardingServiceClient(ushort port, NetworkCredential networkCredential)
        {
            return fritzLayer3ForwardingServiceClientFactory.Build((q, r, t) => new FritzLayer3ForwardingService(q, r, t!), deviceLoginInfo.Device!.PreferredLocation, true, FritzLayer3ForwardingService.ControlUrl, port, networkCredential);
        }

        private void UpdateCanExecuteGetDefaultConnectionService()
        {
            CanExecuteGetDefaultConnectionService = deviceLoginInfo.Device is not null && deviceLoginInfo.User is not null && !string.IsNullOrWhiteSpace(deviceLoginInfo.Password) && !GetDefaultConnectionServiceCommandActive;
        }
    }
}