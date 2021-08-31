namespace RS.Fritz.Manager.UI
{
    using System;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using CommunityToolkit.Mvvm.Messaging;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal abstract class FritzServiceViewModel : ObservableObject
    {
        private readonly IFritzServiceOperationHandler fritzServiceOperationHandler;
        private readonly ILogger logger;

        private bool defaultCommandActive = false;
        private bool canExecuteDefaultCommand = false;
        private DeviceLoginInfo deviceLoginInfo;

        protected FritzServiceViewModel(ILogger logger, DeviceLoginInfo deviceLoginInfo, IFritzServiceOperationHandler fritzServiceOperationHandler)
        {
            this.deviceLoginInfo = deviceLoginInfo;
            this.fritzServiceOperationHandler = fritzServiceOperationHandler;
            this.logger = logger;
            DefaultCommand = new AsyncRelayCommand<bool?>(ExecuteDefaultCommandAsync, q => CanExecuteDefaultCommand);
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

        protected IFritzServiceOperationHandler FritzServiceOperationHandler { get => fritzServiceOperationHandler; }

        protected abstract Task DoExecuteDefaultCommandAsync();

        protected virtual void DeviceLoginInfoPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            UpdateCanExecuteDefaultCommand();
        }

        protected virtual void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
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

        protected virtual bool GetCanExecuteDefaultCommand()
        {
            return deviceLoginInfo.InternetGatewayDevice is not null && deviceLoginInfo.User is not null && !string.IsNullOrWhiteSpace(deviceLoginInfo.Password) && !DefaultCommandActive;
        }

        protected void UpdateCanExecuteDefaultCommand()
        {
            CanExecuteDefaultCommand = GetCanExecuteDefaultCommand();
        }

        private async Task ExecuteDefaultCommandAsync(bool? showView)
        {
            try
            {
                DefaultCommandActive = true;

                await DoExecuteDefaultCommandAsync();

                if (showView ?? true)
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
    }
}