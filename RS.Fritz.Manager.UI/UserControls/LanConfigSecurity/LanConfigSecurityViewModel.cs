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

    internal sealed class LanConfigSecurityViewModel : ObservableObject
    {
        private readonly IServiceOperationHandler serviceOperationHandler;
        private readonly IClientFactory<IFritzLanConfigSecurityService> fritzLanConfigSecurityServiceClientFactory;
        private readonly ILogger logger;
        private readonly LanConfigSecuritySetConfigPasswordViewModel lanConfigSecuritySetConfigPasswordViewModel;

        private bool getLanConfigSecurityCommandActive = false;
        private bool canExecuteLanConfigSecurity = false;
        private DeviceLoginInfo deviceLoginInfo;
        private LanConfigSecurityGetAnonymousLoginResponse? lanConfigSecurityGetAnonymousLoginResponse;
        private LanConfigSecurityGetCurrentUserResponse? lanConfigSecurityGetCurrentUserResponse;
        private LanConfigSecurityGetInfoResponse? lanConfigSecurityGetInfoResponse;
        private LanConfigSecurityGetUserListResponse? lanConfigSecurityGetUserListResponse;

        public LanConfigSecurityViewModel(ILogger logger, DeviceLoginInfo deviceLoginInfo, LanConfigSecuritySetConfigPasswordViewModel lanConfigSecuritySetConfigPasswordViewModel, IServiceOperationHandler serviceOperationHandler, IClientFactory<IFritzLanConfigSecurityService> fritzLanConfigSecurityServiceClientFactory)
        {
            this.deviceLoginInfo = deviceLoginInfo;
            this.serviceOperationHandler = serviceOperationHandler;
            this.fritzLanConfigSecurityServiceClientFactory = fritzLanConfigSecurityServiceClientFactory;
            this.logger = logger;
            this.lanConfigSecuritySetConfigPasswordViewModel = lanConfigSecuritySetConfigPasswordViewModel;
            GetLanConfigSecurityCommand = new AsyncRelayCommand(GetLanConfigSecurityAsync, () => CanExecuteGetLanConfigSecurity);
            deviceLoginInfo.PropertyChanged += DeviceLoginInfoPropertyChanged;
            PropertyChanged += LanConfigSecurityViewModelPropertyChanged;

            WeakReferenceMessenger.Default.Register<DeviceLoginInfoValueChangedMessage>(this, (r, m) =>
            {
                ((LanConfigSecurityViewModel)r).DeviceLoginInfo = m.Value;
            });
        }

        public DeviceLoginInfo DeviceLoginInfo
        {
            get => deviceLoginInfo;
            set
            {
                if (SetProperty(ref deviceLoginInfo, value))
                    GetLanConfigSecurityCommand.NotifyCanExecuteChanged();
            }
        }

        public LanConfigSecuritySetConfigPasswordViewModel LanConfigSecuritySetConfigPasswordViewModel
        {
            get => lanConfigSecuritySetConfigPasswordViewModel;
        }

        public IAsyncRelayCommand GetLanConfigSecurityCommand { get; }

        public bool CanExecuteGetLanConfigSecurity
        {
            get => canExecuteLanConfigSecurity;
            set
            {
                if (SetProperty(ref canExecuteLanConfigSecurity, value))
                    GetLanConfigSecurityCommand.NotifyCanExecuteChanged();
            }
        }

        public LanConfigSecurityGetAnonymousLoginResponse? LanConfigSecurityGetAnonymousLoginResponse
        {
            get => lanConfigSecurityGetAnonymousLoginResponse; set { _ = SetProperty(ref lanConfigSecurityGetAnonymousLoginResponse, value); }
        }

        public LanConfigSecurityGetCurrentUserResponse? LanConfigSecurityGetCurrentUserResponse
        {
            get => lanConfigSecurityGetCurrentUserResponse; set { _ = SetProperty(ref lanConfigSecurityGetCurrentUserResponse, value); }
        }

        public LanConfigSecurityGetInfoResponse? LanConfigSecurityGetInfoResponse
        {
            get => lanConfigSecurityGetInfoResponse; set { _ = SetProperty(ref lanConfigSecurityGetInfoResponse, value); }
        }

        public LanConfigSecurityGetUserListResponse? LanConfigSecurityGetUserListResponse
        {
            get => lanConfigSecurityGetUserListResponse; set { _ = SetProperty(ref lanConfigSecurityGetUserListResponse, value); }
        }

        public bool GetLanConfigSecurityCommandActive
        {
            get => getLanConfigSecurityCommandActive;
            set
            {
                if (value)
                    Mouse.OverrideCursor = Cursors.Wait;
                else
                    Mouse.OverrideCursor = null;

                if (SetProperty(ref getLanConfigSecurityCommandActive, value))
                    GetLanConfigSecurityCommand.NotifyCanExecuteChanged();
            }
        }

        private async Task GetLanConfigSecurityAsync()
        {
            try
            {
                GetLanConfigSecurityCommandActive = true;

                var networkCredential = new NetworkCredential(deviceLoginInfo.User!.Name, deviceLoginInfo.Password);

                await Domain.TaskExtensions.WhenAllSafe(new Task[]
                    {
                        GetLanConfigSecurityGetAnonymousLoginAsync(),
                        GetLanConfigSecurityGetCurrentUserAsync(networkCredential),
                        GetLanConfigSecurityGetInfoAsync(networkCredential),
                        GetLanConfigSecurityGetUserListAsync(networkCredential)
                    });

                WeakReferenceMessenger.Default.Send(new ActiveViewValueChangedMessage(this));
            }
            catch (Exception ex)
            {
                logger.ExceptionThrown(ex);
            }
            finally
            {
                GetLanConfigSecurityCommandActive = false;
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
                        UpdateCanExecuteGetLanConfigSecurity();
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
                case nameof(GetLanConfigSecurityCommandActive):
                    {
                        UpdateCanExecuteGetLanConfigSecurity();
                        break;
                    }

                default:
                    break;
            }
        }

        private async Task GetLanConfigSecurityGetAnonymousLoginAsync()
        {
            LanConfigSecurityGetAnonymousLoginResponse = await serviceOperationHandler.ExecuteAsync(GetFritzLanConfigSecurityServiceClient(true, deviceLoginInfo.Device!.SecurityPort), q => q.GetAnonymousLoginAsync(new LanConfigSecurityGetAnonymousLoginRequest()));
        }

        private async Task GetLanConfigSecurityGetCurrentUserAsync(NetworkCredential networkCredential)
        {
            LanConfigSecurityGetCurrentUserResponse = await serviceOperationHandler.ExecuteAsync(GetFritzLanConfigSecurityServiceClient(true, deviceLoginInfo.Device!.SecurityPort, networkCredential), q => q.GetCurrentUserAsync(new LanConfigSecurityGetCurrentUserRequest()));
        }

        private async Task GetLanConfigSecurityGetInfoAsync(NetworkCredential networkCredential)
        {
            LanConfigSecurityGetInfoResponse = await serviceOperationHandler.ExecuteAsync(GetFritzLanConfigSecurityServiceClient(true, deviceLoginInfo.Device!.SecurityPort, networkCredential), q => q.GetInfoAsync(new LanConfigSecurityGetInfoRequest()));
        }

        private async Task GetLanConfigSecurityGetUserListAsync(NetworkCredential networkCredential)
        {
            LanConfigSecurityGetUserListResponse = await serviceOperationHandler.ExecuteAsync(GetFritzLanConfigSecurityServiceClient(true, deviceLoginInfo.Device!.SecurityPort, networkCredential), q => q.GetUserListAsync(new LanConfigSecurityGetUserListRequest()));
        }

        private IFritzLanConfigSecurityService GetFritzLanConfigSecurityServiceClient(bool secure = true, ushort? port = null, NetworkCredential? networkCredential = null)
        {
            return fritzLanConfigSecurityServiceClientFactory.Build((q, r, t) => new FritzLanConfigSecurityService(q, r, t), deviceLoginInfo.Device!.PreferredLocation, secure, FritzLanConfigSecurityService.ControlUrl, port, networkCredential);
        }

        private void UpdateCanExecuteGetLanConfigSecurity()
        {
            CanExecuteGetLanConfigSecurity = deviceLoginInfo.Device is not null && deviceLoginInfo.User is not null && !string.IsNullOrWhiteSpace(deviceLoginInfo.Password) && !GetLanConfigSecurityCommandActive;
        }
    }
}