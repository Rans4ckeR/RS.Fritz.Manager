namespace RS.Fritz.Manager.UI
{
    using System;
    using System.ComponentModel;
    using System.Net;
    using System.Threading.Tasks;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using CommunityToolkit.Mvvm.Messaging;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal abstract class FritzServiceViewModel : ObservableObject
    {
        private readonly IServiceOperationHandler serviceOperationHandler;
        private readonly ILogger logger;

        private bool defaultCommandActive = false;
        private bool canExecuteDefaultCommand = false;
        private DeviceLoginInfo deviceLoginInfo;

        protected FritzServiceViewModel(ILogger logger, DeviceLoginInfo deviceLoginInfo, IServiceOperationHandler serviceOperationHandler)
        {
            this.deviceLoginInfo = deviceLoginInfo;
            this.serviceOperationHandler = serviceOperationHandler;
            this.logger = logger;
            DefaultCommand = new AsyncRelayCommand(ExecuteDefaultCommandAsync, () => CanExecuteDefaultCommand);
            deviceLoginInfo.PropertyChanged += DeviceLoginInfoPropertyChanged;
            PropertyChanged += FritzServiceViewModelPropertyChanged;

            WeakReferenceMessenger.Default.Register<DeviceLoginInfoValueChangedMessage>(this, (r, m) =>
            {
                ((FritzServiceViewModel)r).DeviceLoginInfo = m.Value;
            });
        }

        public DeviceLoginInfo DeviceLoginInfo
        {
            get => deviceLoginInfo;
            set
            {
                if (SetProperty(ref deviceLoginInfo, value))
                    DefaultCommand.NotifyCanExecuteChanged();
            }
        }

        public IServiceOperationHandler ServiceOperationHandler { get => serviceOperationHandler; }

        public IAsyncRelayCommand DefaultCommand { get; }

        public bool CanExecuteDefaultCommand
        {
            get => canExecuteDefaultCommand;
            set
            {
                if (SetProperty(ref canExecuteDefaultCommand, value))
                    DefaultCommand.NotifyCanExecuteChanged();
            }
        }

        public bool DefaultCommandActive
        {
            get => defaultCommandActive;
            set
            {
                if (SetProperty(ref defaultCommandActive, value))
                    DefaultCommand.NotifyCanExecuteChanged();
            }
        }

        protected abstract Task DoExecuteDefaultCommandAsync(NetworkCredential networkCredential);

        protected async Task ExecuteDefaultCommandAsync()
        {
            try
            {
                DefaultCommandActive = true;

                var networkCredential = new NetworkCredential(deviceLoginInfo.User!.Name, deviceLoginInfo.Password);

                await DoExecuteDefaultCommandAsync(networkCredential);

                WeakReferenceMessenger.Default.Send(new ActiveViewValueChangedMessage(this));
            }
            catch (Exception ex)
            {
                logger.ExceptionThrown(ex);
            }
            finally
            {
                DefaultCommandActive = false;
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
                        UpdateCanExecuteDefaultCommand();
                        break;
                    }

                default:
                    break;
            }
        }

        private void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(DefaultCommandActive):
                    {
                        UpdateCanExecuteDefaultCommand();
                        break;
                    }

                default:
                    break;
            }
        }

        private void UpdateCanExecuteDefaultCommand()
        {
            CanExecuteDefaultCommand = deviceLoginInfo.Device is not null && deviceLoginInfo.User is not null && !string.IsNullOrWhiteSpace(deviceLoginInfo.Password) && !DefaultCommandActive;
        }
    }
}