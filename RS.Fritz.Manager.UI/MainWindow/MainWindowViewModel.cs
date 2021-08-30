namespace RS.Fritz.Manager.UI
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using System.Xml;
    using System.Xml.Serialization;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using CommunityToolkit.Mvvm.Messaging;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal sealed class MainWindowViewModel : ObservableObject
    {
        private readonly IServiceOperationHandler serviceOperationHandler;
        private readonly IDeviceSearchService deviceSearchService;
        private readonly IClientFactory<IFritzDeviceInfoService> fritzDeviceInfoServiceClientFactory;
        private readonly IClientFactory<IFritzLanConfigSecurityService> fritzLanConfigSecurityServiceClientFactory;
        private readonly DeviceInfoViewModel deviceInfoViewModel;
        private readonly LanConfigSecurityViewModel lanConfigSecurityViewModel;
        private readonly WanDslInterfaceConfigViewModel wanDslInterfaceConfigViewModel;
        private readonly Layer3ForwardingViewModel layer3ForwardingViewModel;
        private readonly WanPppConnectionViewModel wanPppConnectionViewModel;
        private readonly ILogger logger;

        private string deviceType = "urn:dslforum-org:device:InternetGatewayDevice:1";
        private ObservableCollection<InternetGatewayDevice> devices = new();
        private ObservableCollection<User> users = new();
        private bool discoverDevicesCommandActive = false;
        private ObservableObject? activeView;
        private string? userMessage;
        private DeviceLoginInfo deviceLoginInfo;
        private bool deviceAndLoginControlsEnabled = true;

        public MainWindowViewModel(ILogger logger, WanPppConnectionViewModel wanPppConnectionViewModel, Layer3ForwardingViewModel layer3ForwardingViewModel, DeviceInfoViewModel deviceInfoViewModel, LanConfigSecurityViewModel lanConfigSecurityViewModel, WanDslInterfaceConfigViewModel wanDslInterfaceConfigViewModel, DeviceLoginInfo deviceLoginInfo, IServiceOperationHandler serviceOperationHandler, IDeviceSearchService deviceSearchService, IClientFactory<IFritzDeviceInfoService> fritzDeviceInfoServiceClientFactory, IClientFactory<IFritzLanConfigSecurityService> fritzLanConfigSecurityServiceClientFactory)
        {
            this.deviceLoginInfo = deviceLoginInfo;
            this.serviceOperationHandler = serviceOperationHandler;
            this.deviceSearchService = deviceSearchService;
            this.deviceInfoViewModel = deviceInfoViewModel;
            this.lanConfigSecurityViewModel = lanConfigSecurityViewModel;
            this.wanDslInterfaceConfigViewModel = wanDslInterfaceConfigViewModel;
            this.layer3ForwardingViewModel = layer3ForwardingViewModel;
            this.wanPppConnectionViewModel = wanPppConnectionViewModel;
            this.fritzDeviceInfoServiceClientFactory = fritzDeviceInfoServiceClientFactory;
            this.fritzLanConfigSecurityServiceClientFactory = fritzLanConfigSecurityServiceClientFactory;
            this.logger = logger;
            DiscoverDevicesCommand = new AsyncRelayCommand(DiscoverDevicesAsync, CanExecuteDiscoverDevices);
            deviceLoginInfo.PropertyChanged += DeviceLoginInfoPropertyChanged;

            WeakReferenceMessenger.Default.Register<UserMessageValueChangedMessage>(this, (r, m) =>
            {
                ((MainWindowViewModel)r).UserMessage = m.Value.Message;
            });
            WeakReferenceMessenger.Default.Register<DeviceLoginInfoValueChangedMessage>(this, (r, m) =>
            {
                ((MainWindowViewModel)r).DeviceLoginInfo = m.Value;
            });
            WeakReferenceMessenger.Default.Register<ActiveViewValueChangedMessage>(this, (r, m) =>
            {
                ((MainWindowViewModel)r).ActiveView = m.Value;
            });
        }

        public static string Title { get => "FritzManager"; }

        public DeviceInfoViewModel DeviceInfoViewModel
        {
            get => deviceInfoViewModel;
        }

        public LanConfigSecurityViewModel LanConfigSecurityViewModel
        {
            get => lanConfigSecurityViewModel;
        }

        public WanDslInterfaceConfigViewModel WanDslInterfaceConfigViewModel
        {
            get => wanDslInterfaceConfigViewModel;
        }

        public Layer3ForwardingViewModel Layer3ForwardingViewModel
        {
            get => layer3ForwardingViewModel;
        }

        public WanPppConnectionViewModel WanPppConnectionViewModel
        {
            get => wanPppConnectionViewModel;
        }

        public DeviceLoginInfo DeviceLoginInfo
        {
            get => deviceLoginInfo;
            set
            {
                if (SetProperty(ref deviceLoginInfo, value))
                    DiscoverDevicesCommand.NotifyCanExecuteChanged();
            }
        }

        public string? UserMessage
        {
            get => userMessage; set { _ = SetProperty(ref userMessage, value); }
        }

        public string DeviceType
        {
            get => deviceType;
            set
            {
                if (SetProperty(ref deviceType, value))
                    DiscoverDevicesCommand.NotifyCanExecuteChanged();
            }
        }

        public bool DeviceAndLoginControlsEnabled
        {
            get => deviceAndLoginControlsEnabled; set { _ = SetProperty(ref deviceAndLoginControlsEnabled, value); }
        }

        public ObservableCollection<User> Users { get => users; set => _ = SetProperty(ref users, value); }

        public ObservableObject? ActiveView { get => activeView; set => _ = SetProperty(ref activeView, value); }

        public ObservableCollection<InternetGatewayDevice> Devices { get => devices; set => _ = SetProperty(ref devices, value); }

        public IAsyncRelayCommand DiscoverDevicesCommand { get; }

        private bool DiscoverDevicesCommandActive
        {
            get => discoverDevicesCommandActive;
            set
            {
                if (value)
                    Mouse.OverrideCursor = Cursors.Wait;
                else
                    Mouse.OverrideCursor = null;

                if (SetProperty(ref discoverDevicesCommandActive, value))
                {
                    DiscoverDevicesCommand.NotifyCanExecuteChanged();

                    DeviceAndLoginControlsEnabled = !discoverDevicesCommandActive;
                }
            }
        }

        private async void DeviceLoginInfoPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(DeviceLoginInfo.Device):
                    {
                        if (DeviceLoginInfo.Device is null)
                        {
                            Users = new ObservableCollection<User>();

                            return;
                        }

                        DeviceInfoGetSecurityPortResponse deviceInfoGetSecurityPortResponse = await serviceOperationHandler.ExecuteAsync(GetFritzDeviceInfoServiceClient(false), q => q.GetSecurityPortAsync(new DeviceInfoGetSecurityPortRequest()));

                        if (DeviceLoginInfo.Device is null)
                            return;

                        DeviceLoginInfo.Device.SecurityPort = deviceInfoGetSecurityPortResponse.SecurityPort;

                        LanConfigSecurityGetUserListResponse lanConfigSecurityGetUserListResponse = await serviceOperationHandler.ExecuteAsync(GetFritzLanConfigSecurityServiceClient(), q => q.GetUserListAsync(new LanConfigSecurityGetUserListRequest()));

                        using var stringReader = new StringReader(lanConfigSecurityGetUserListResponse.UserList);
                        using var xmlTextReader = new XmlTextReader(stringReader);

                        UserList? userList = (UserList?)new XmlSerializer(typeof(UserList)).Deserialize(xmlTextReader);

                        Users = new ObservableCollection<User>(userList?.Users.OrderByDescending(q => q.LastUser) ?? Enumerable.Empty<User>());
                        break;
                    }

                default:
                    break;
            }
        }

        private async Task DiscoverDevicesAsync()
        {
            try
            {
                DiscoverDevicesCommandActive = true;
                Devices = new ObservableCollection<InternetGatewayDevice>(await deviceSearchService.GetDevicesAsync(DeviceType!));
            }
            catch (Exception ex)
            {
                logger.ExceptionThrown(ex);
            }
            finally
            {
                DiscoverDevicesCommandActive = false;
            }
        }

        private bool CanExecuteDiscoverDevices()
        {
            return !string.IsNullOrWhiteSpace(DeviceType) && !DiscoverDevicesCommandActive;
        }

        private IFritzDeviceInfoService GetFritzDeviceInfoServiceClient(bool secure = true, ushort? port = null, NetworkCredential? networkCredential = null)
        {
            return fritzDeviceInfoServiceClientFactory.Build((q, r, t) => new FritzDeviceInfoService(q, r, t), deviceLoginInfo.Device!.PreferredLocation, secure, FritzDeviceInfoService.ControlUrl, port, networkCredential);
        }

        private IFritzLanConfigSecurityService GetFritzLanConfigSecurityServiceClient(NetworkCredential? networkCredential = null)
        {
            return fritzLanConfigSecurityServiceClientFactory.Build((q, r, t) => new FritzLanConfigSecurityService(q, r, t), deviceLoginInfo.Device!.PreferredLocation, true, FritzLanConfigSecurityService.ControlUrl, deviceLoginInfo.Device!.SecurityPort, networkCredential);
        }
    }
}