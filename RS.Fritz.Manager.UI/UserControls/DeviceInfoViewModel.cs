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

    internal sealed class DeviceInfoViewModel : ObservableObject
    {
        private readonly IServiceOperationHandler serviceOperationHandler;
        private readonly IClientFactory<IFritzDeviceInfoService> fritzDeviceInfoServiceClientFactory;
        private readonly ILogger logger;

        private bool getDeviceInfoCommandActive = false;
        private bool canExecuteGetDeviceInfo = false;
        private DeviceInfoGetSecurityPortResponse? deviceInfoGetSecurityPortResponse;
        private DeviceInfoGetInfoResponse? deviceInfoGetInfoResponse;
        private DeviceInfoGetDeviceLogResponse? deviceInfoGetDeviceLogResponse;
        private DeviceLoginInfo deviceLoginInfo;

        public DeviceInfoViewModel(ILogger logger, DeviceLoginInfo deviceLoginInfo, IServiceOperationHandler serviceOperationHandler, IClientFactory<IFritzDeviceInfoService> fritzDeviceInfoServiceClientFactory)
        {
            this.deviceLoginInfo = deviceLoginInfo;
            this.serviceOperationHandler = serviceOperationHandler;
            this.fritzDeviceInfoServiceClientFactory = fritzDeviceInfoServiceClientFactory;
            this.logger = logger;
            GetDeviceInfoCommand = new AsyncRelayCommand(GetDeviceInfoAsync, () => CanExecuteGetDeviceInfo);
            deviceLoginInfo.PropertyChanged += DeviceLoginInfoPropertyChanged;
            PropertyChanged += DeviceInfoViewModelPropertyChanged;

            WeakReferenceMessenger.Default.Register<DeviceLoginInfoValueChangedMessage>(this, (r, m) =>
            {
                ((DeviceInfoViewModel)r).DeviceLoginInfo = m.Value;
            });
        }

        public DeviceInfoGetSecurityPortResponse? DeviceInfoGetSecurityPortResponse
        {
            get => deviceInfoGetSecurityPortResponse; set { _ = SetProperty(ref deviceInfoGetSecurityPortResponse, value); }
        }

        public DeviceInfoGetInfoResponse? DeviceInfoGetInfoResponse
        {
            get => deviceInfoGetInfoResponse; set { _ = SetProperty(ref deviceInfoGetInfoResponse, value); }
        }

        public DeviceInfoGetDeviceLogResponse? DeviceInfoGetDeviceLogResponse
        {
            get => deviceInfoGetDeviceLogResponse; set { _ = SetProperty(ref deviceInfoGetDeviceLogResponse, value); }
        }

        public DeviceLoginInfo DeviceLoginInfo
        {
            get => deviceLoginInfo;
            set
            {
                if (SetProperty(ref deviceLoginInfo, value))
                    GetDeviceInfoCommand.NotifyCanExecuteChanged();
            }
        }

        public IAsyncRelayCommand GetDeviceInfoCommand { get; }

        public bool CanExecuteGetDeviceInfo
        {
            get => canExecuteGetDeviceInfo;
            set
            {
                if (SetProperty(ref canExecuteGetDeviceInfo, value))
                    GetDeviceInfoCommand.NotifyCanExecuteChanged();
            }
        }

        public bool GetDeviceInfoCommandActive
        {
            get => getDeviceInfoCommandActive;
            set
            {
                if (value)
                    Mouse.OverrideCursor = Cursors.Wait;
                else
                    Mouse.OverrideCursor = null;

                if (SetProperty(ref getDeviceInfoCommandActive, value))
                    GetDeviceInfoCommand.NotifyCanExecuteChanged();
            }
        }

        private async Task GetDeviceInfoAsync()
        {
            try
            {
                GetDeviceInfoCommandActive = true;

                var networkCredential = new NetworkCredential(deviceLoginInfo.User!.Name, deviceLoginInfo.Password);

                await Domain.TaskExtensions.WhenAllSafe(new Task[]
                    {
                        GetDeviceInfoGetSecurityPortAsync(),
                        GetDeviceInfoGetInfoAsync(networkCredential),
                        GetDeviceInfoGetDeviceLogAsync(networkCredential)
                    });

                WeakReferenceMessenger.Default.Send(new ActiveViewValueChangedMessage(this));
            }
            catch (Exception ex)
            {
                logger.ExceptionThrown(ex);
            }
            finally
            {
                GetDeviceInfoCommandActive = false;
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
                        UpdateCanExecuteGetDeviceInfo();
                        break;
                    }

                default:
                    break;
            }
        }

        private async Task GetDeviceInfoGetSecurityPortAsync()
        {
            DeviceInfoGetSecurityPortResponse = await serviceOperationHandler.ExecuteAsync(GetFritzDeviceInfoServiceClient(false), q => q.GetSecurityPortAsync(new DeviceInfoGetSecurityPortRequest()));
        }

        private async Task GetDeviceInfoGetInfoAsync(NetworkCredential networkCredential)
        {
            DeviceInfoGetInfoResponse = await serviceOperationHandler.ExecuteAsync(GetFritzDeviceInfoServiceClient(true, deviceLoginInfo.Device!.SecurityPort, networkCredential), q => q.GetInfoAsync(new DeviceInfoGetInfoRequest()));
        }

        private async Task GetDeviceInfoGetDeviceLogAsync(NetworkCredential networkCredential)
        {
            DeviceInfoGetDeviceLogResponse = await serviceOperationHandler.ExecuteAsync(GetFritzDeviceInfoServiceClient(true, deviceLoginInfo.Device!.SecurityPort, networkCredential), q => q.GetDeviceLogAsync(new DeviceInfoGetDeviceLogRequest()));
        }

        private IFritzDeviceInfoService GetFritzDeviceInfoServiceClient(bool secure = true, ushort? port = null, NetworkCredential? networkCredential = null)
        {
            return fritzDeviceInfoServiceClientFactory.Build((q, r, t) => new FritzDeviceInfoService(q, r, t), deviceLoginInfo.Device!.PreferredLocation, secure, FritzDeviceInfoService.ControlUrl, port, networkCredential);
        }

        private void DeviceInfoViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(GetDeviceInfoCommandActive):
                    {
                        UpdateCanExecuteGetDeviceInfo();
                        break;
                    }

                default:
                    break;
            }
        }

        private void UpdateCanExecuteGetDeviceInfo()
        {
            CanExecuteGetDeviceInfo = deviceLoginInfo.Device is not null && deviceLoginInfo.User is not null && !string.IsNullOrWhiteSpace(deviceLoginInfo.Password) && !GetDeviceInfoCommandActive;
        }
    }
}