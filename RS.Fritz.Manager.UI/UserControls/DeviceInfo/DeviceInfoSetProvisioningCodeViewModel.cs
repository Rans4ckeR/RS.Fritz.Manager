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

    internal sealed class DeviceInfoSetProvisioningCodeViewModel : ObservableObject
    {
        private readonly IServiceOperationHandler serviceOperationHandler;
        private readonly IClientFactory<IFritzDeviceInfoService> fritzDeviceInfoServiceClientFactory;
        private readonly ILogger logger;

        private bool setProvisioningCodeCommandActive = false;
        private bool canExecuteSetProvisioningCodeCommand = false;
        private DeviceLoginInfo deviceLoginInfo;
        private string provisioningCode = string.Empty;

        public DeviceInfoSetProvisioningCodeViewModel(ILogger logger, DeviceLoginInfo deviceLoginInfo, IServiceOperationHandler serviceOperationHandler, IClientFactory<IFritzDeviceInfoService> fritzDeviceInfoServiceClientFactory)
        {
            this.deviceLoginInfo = deviceLoginInfo;
            this.serviceOperationHandler = serviceOperationHandler;
            this.fritzDeviceInfoServiceClientFactory = fritzDeviceInfoServiceClientFactory;
            this.logger = logger;
            SetProvisioningCodeCommand = new AsyncRelayCommand(SetProvisioningCodeCommandAsync, () => CanExecuteSetProvisioningCodeCommand);
            deviceLoginInfo.PropertyChanged += DeviceLoginInfoPropertyChanged;
            PropertyChanged += DeviceInfoSetProvisioningCodeViewModelPropertyChanged;

            WeakReferenceMessenger.Default.Register<DeviceLoginInfoValueChangedMessage>(this, (r, m) =>
            {
                ((DeviceInfoSetProvisioningCodeViewModel)r).DeviceLoginInfo = m.Value;
            });
        }

        public DeviceLoginInfo DeviceLoginInfo
        {
            get => deviceLoginInfo;
            set
            {
                if (SetProperty(ref deviceLoginInfo, value))
                    SetProvisioningCodeCommand.NotifyCanExecuteChanged();
            }
        }

        public IAsyncRelayCommand SetProvisioningCodeCommand { get; }

        public bool CanExecuteSetProvisioningCodeCommand
        {
            get => canExecuteSetProvisioningCodeCommand;
            set
            {
                if (SetProperty(ref canExecuteSetProvisioningCodeCommand, value))
                    SetProvisioningCodeCommand.NotifyCanExecuteChanged();
            }
        }

        public string ProvisioningCode
        {
            get => provisioningCode;
            set
            {
                if (SetProperty(ref provisioningCode, value))
                    SetProvisioningCodeCommand.NotifyCanExecuteChanged();
            }
        }

        public bool SetProvisioningCodeCommandActive
        {
            get => setProvisioningCodeCommandActive;
            set
            {
                if (value)
                    Mouse.OverrideCursor = Cursors.Wait;
                else
                    Mouse.OverrideCursor = null;

                if (SetProperty(ref setProvisioningCodeCommandActive, value))
                    SetProvisioningCodeCommand.NotifyCanExecuteChanged();
            }
        }

        private async Task SetProvisioningCodeCommandAsync()
        {
            try
            {
                SetProvisioningCodeCommandActive = true;

                var networkCredential = new NetworkCredential(deviceLoginInfo.User!.Name, deviceLoginInfo.Password);

                await SetDeviceInfoSetProvisioningCodeAsync(new SetProvisioningCodeRequest { ProvisioningCode = ProvisioningCode! }, networkCredential);
            }
            catch (Exception ex)
            {
                logger.ExceptionThrown(ex);
            }
            finally
            {
                SetProvisioningCodeCommandActive = false;
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
                        UpdateCanExecuteSetProvisioningCodeCommand();
                        break;
                    }

                default:
                    break;
            }
        }

        private void DeviceInfoSetProvisioningCodeViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(SetProvisioningCodeCommandActive):
                case nameof(ProvisioningCode):
                    {
                        UpdateCanExecuteSetProvisioningCodeCommand();
                        break;
                    }

                default:
                    break;
            }
        }

        private async Task SetDeviceInfoSetProvisioningCodeAsync(SetProvisioningCodeRequest deviceInfoSetProvisioningCodeRequest, NetworkCredential networkCredential)
        {
            _ = await serviceOperationHandler.ExecuteAsync(GetFritzDeviceInfoServiceClient(true, deviceLoginInfo.Device!.SecurityPort, networkCredential), q => q.SetProvisioningCodeAsync(deviceInfoSetProvisioningCodeRequest));
        }

        private IFritzDeviceInfoService GetFritzDeviceInfoServiceClient(bool secure = true, ushort? port = null, NetworkCredential? networkCredential = null)
        {
            return fritzDeviceInfoServiceClientFactory.Build((q, r, t) => new FritzDeviceInfoService(q, r, t), deviceLoginInfo.Device!.PreferredLocation, secure, FritzDeviceInfoService.ControlUrl, port, networkCredential);
        }

        private void UpdateCanExecuteSetProvisioningCodeCommand()
        {
            CanExecuteSetProvisioningCodeCommand = deviceLoginInfo.Device is not null && deviceLoginInfo.User is not null && !string.IsNullOrWhiteSpace(deviceLoginInfo.Password) && !SetProvisioningCodeCommandActive;
        }
    }
}