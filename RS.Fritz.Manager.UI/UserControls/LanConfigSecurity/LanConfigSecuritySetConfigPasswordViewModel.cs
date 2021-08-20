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

    internal sealed class LanConfigSecuritySetConfigPasswordViewModel : ObservableObject
    {
        private readonly IServiceOperationHandler serviceOperationHandler;
        private readonly IClientFactory<IFritzLanConfigSecurityService> fritzLanConfigSecurityServiceClientFactory;
        private readonly ILogger logger;

        private bool setConfigPasswordCommandActive = false;
        private bool canExecuteSetConfigPassword = false;
        private DeviceLoginInfo deviceLoginInfo;
        private string? password;

        public LanConfigSecuritySetConfigPasswordViewModel(ILogger logger, DeviceLoginInfo deviceLoginInfo, IServiceOperationHandler serviceOperationHandler, IClientFactory<IFritzLanConfigSecurityService> fritzLanConfigSecurityServiceClientFactory)
        {
            this.deviceLoginInfo = deviceLoginInfo;
            this.serviceOperationHandler = serviceOperationHandler;
            this.fritzLanConfigSecurityServiceClientFactory = fritzLanConfigSecurityServiceClientFactory;
            this.logger = logger;
            SetConfigPasswordCommand = new AsyncRelayCommand(SetConfigPasswordAsync, () => CanExecuteSetConfigPassword);
            deviceLoginInfo.PropertyChanged += DeviceLoginInfoPropertyChanged;
            PropertyChanged += LanConfigSecurityViewModelPropertyChanged;

            WeakReferenceMessenger.Default.Register<DeviceLoginInfoValueChangedMessage>(this, (r, m) =>
            {
                ((LanConfigSecuritySetConfigPasswordViewModel)r).DeviceLoginInfo = m.Value;
            });
        }

        public DeviceLoginInfo DeviceLoginInfo
        {
            get => deviceLoginInfo;
            set
            {
                if (SetProperty(ref deviceLoginInfo, value))
                    SetConfigPasswordCommand.NotifyCanExecuteChanged();
            }
        }

        public IAsyncRelayCommand SetConfigPasswordCommand { get; }

        public bool CanExecuteSetConfigPassword
        {
            get => canExecuteSetConfigPassword;
            set
            {
                if (SetProperty(ref canExecuteSetConfigPassword, value))
                    SetConfigPasswordCommand.NotifyCanExecuteChanged();
            }
        }

        public string? Password
        {
            get => password;
            set
            {
                if (SetProperty(ref password, value))
                    SetConfigPasswordCommand.NotifyCanExecuteChanged();
            }
        }

        public bool SetConfigPasswordCommandActive
        {
            get => setConfigPasswordCommandActive;
            set
            {
                if (value)
                    Mouse.OverrideCursor = Cursors.Wait;
                else
                    Mouse.OverrideCursor = null;

                if (SetProperty(ref setConfigPasswordCommandActive, value))
                    SetConfigPasswordCommand.NotifyCanExecuteChanged();
            }
        }

        private async Task SetConfigPasswordAsync()
        {
            try
            {
                SetConfigPasswordCommandActive = true;

                var networkCredential = new NetworkCredential(deviceLoginInfo.User!.Name, deviceLoginInfo.Password);

                await SetLanConfigSecuritySetConfigPasswordAsync(new LanConfigSecuritySetConfigPasswordRequest { Password = Password! }, networkCredential);

                DeviceLoginInfo.Password = Password;
            }
            catch (Exception ex)
            {
                logger.ExceptionThrown(ex);
            }
            finally
            {
                SetConfigPasswordCommandActive = false;
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
                        UpdateCanExecuteSetConfigPasswordCommand();
                        break;
                    }

                default:
                    break;
            }
        }

        private void LanConfigSecurityViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(SetConfigPasswordCommandActive):
                case nameof(Password):
                    {
                        UpdateCanExecuteSetConfigPasswordCommand();
                        break;
                    }

                default:
                    break;
            }
        }

        private async Task SetLanConfigSecuritySetConfigPasswordAsync(LanConfigSecuritySetConfigPasswordRequest lanConfigSecuritySetConfigPasswordRequest, NetworkCredential networkCredential)
        {
            _ = await serviceOperationHandler.ExecuteAsync(GetFritzLanConfigSecurityServiceClient(true, deviceLoginInfo.Device!.SecurityPort, networkCredential), q => q.SetConfigPasswordAsync(lanConfigSecuritySetConfigPasswordRequest));
        }

        private IFritzLanConfigSecurityService GetFritzLanConfigSecurityServiceClient(bool secure = true, ushort? port = null, NetworkCredential? networkCredential = null)
        {
            return fritzLanConfigSecurityServiceClientFactory.Build((q, r, t) => new FritzLanConfigSecurityService(q, r, t), deviceLoginInfo.Device!.PreferredLocation, secure, FritzLanConfigSecurityService.ControlUrl, port, networkCredential);
        }

        private void UpdateCanExecuteSetConfigPasswordCommand()
        {
            CanExecuteSetConfigPassword = deviceLoginInfo.Device is not null && deviceLoginInfo.User is not null && !string.IsNullOrWhiteSpace(deviceLoginInfo.Password) && !string.IsNullOrWhiteSpace(Password) && !SetConfigPasswordCommandActive;
        }
    }
}