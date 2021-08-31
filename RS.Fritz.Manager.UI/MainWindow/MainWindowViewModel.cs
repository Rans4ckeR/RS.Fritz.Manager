namespace RS.Fritz.Manager.UI
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Serialization;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Messaging;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal sealed class MainWindowViewModel : FritzServiceViewModel
    {
        private readonly IDeviceSearchService deviceSearchService;
        private readonly DeviceInfoViewModel deviceInfoViewModel;
        private readonly LanConfigSecurityViewModel lanConfigSecurityViewModel;
        private readonly WanDslInterfaceConfigViewModel wanDslInterfaceConfigViewModel;
        private readonly Layer3ForwardingViewModel layer3ForwardingViewModel;
        private readonly WanPppConnectionViewModel wanPppConnectionViewModel;

        private string deviceType = "urn:dslforum-org:device:InternetGatewayDevice:1";
        private ObservableCollection<InternetGatewayDevice> devices = new();
        private ObservableCollection<User> users = new();
        private ObservableObject? activeView;
        private string? userMessage;
        private bool deviceAndLoginControlsEnabled = true;

        public MainWindowViewModel(ILogger logger, WanPppConnectionViewModel wanPppConnectionViewModel, Layer3ForwardingViewModel layer3ForwardingViewModel, DeviceInfoViewModel deviceInfoViewModel, LanConfigSecurityViewModel lanConfigSecurityViewModel, WanDslInterfaceConfigViewModel wanDslInterfaceConfigViewModel, DeviceLoginInfo deviceLoginInfo, IFritzServiceOperationHandler fritzServiceOperationHandler, IDeviceSearchService deviceSearchService)
            : base(logger, deviceLoginInfo, fritzServiceOperationHandler)
        {
            this.deviceSearchService = deviceSearchService;
            this.deviceInfoViewModel = deviceInfoViewModel;
            this.lanConfigSecurityViewModel = lanConfigSecurityViewModel;
            this.wanDslInterfaceConfigViewModel = wanDslInterfaceConfigViewModel;
            this.layer3ForwardingViewModel = layer3ForwardingViewModel;
            this.wanPppConnectionViewModel = wanPppConnectionViewModel;

            WeakReferenceMessenger.Default.Register<UserMessageValueChangedMessage>(this, (r, m) =>
            {
                ((MainWindowViewModel)r).UserMessage = m.Value.Message;
            });
            WeakReferenceMessenger.Default.Register<ActiveViewValueChangedMessage>(this, (r, m) =>
            {
                ((MainWindowViewModel)r).ActiveView = m.Value;
            });
            UpdateCanExecuteDefaultCommand();
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
                    DefaultCommand.NotifyCanExecuteChanged();
            }
        }

        public bool DeviceAndLoginControlsEnabled
        {
            get => deviceAndLoginControlsEnabled; set { _ = SetProperty(ref deviceAndLoginControlsEnabled, value); }
        }

        public ObservableCollection<User> Users { get => users; set => _ = SetProperty(ref users, value); }

        public ObservableObject? ActiveView { get => activeView; set => _ = SetProperty(ref activeView, value); }

        public ObservableCollection<InternetGatewayDevice> Devices { get => devices; set => _ = SetProperty(ref devices, value); }

        protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            base.FritzServiceViewModelPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case nameof(DefaultCommandActive):
                    {
                        DeviceAndLoginControlsEnabled = !DefaultCommandActive;
                        break;
                    }

                default:
                    break;
            }
        }

        protected override async Task DoExecuteDefaultCommandAsync()
        {
            Devices = new ObservableCollection<InternetGatewayDevice>(await deviceSearchService.GetDevicesAsync(DeviceType!));
        }

        protected override async void DeviceLoginInfoPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            base.DeviceLoginInfoPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case nameof(DeviceLoginInfo.InternetGatewayDevice):
                    {
                        if (DeviceLoginInfo.InternetGatewayDevice is null)
                        {
                            Users = new ObservableCollection<User>();

                            return;
                        }

                        FritzServiceOperationHandler.InternetGatewayDevice = DeviceLoginInfo.InternetGatewayDevice;

                        DeviceInfoGetSecurityPortResponse deviceInfoGetSecurityPortResponse = await FritzServiceOperationHandler.DeviceInfoGetSecurityPortAsync();

                        DeviceLoginInfo.InternetGatewayDevice.SecurityPort = deviceInfoGetSecurityPortResponse.SecurityPort;

                        LanConfigSecurityGetUserListResponse lanConfigSecurityGetUserListResponse = await FritzServiceOperationHandler.LanConfigSecurityGetUserListAsync();

                        using var stringReader = new StringReader(lanConfigSecurityGetUserListResponse.UserList);
                        using var xmlTextReader = new XmlTextReader(stringReader);

                        UserList? userList = (UserList?)new XmlSerializer(typeof(UserList)).Deserialize(xmlTextReader);

                        Users = new ObservableCollection<User>(userList?.Users.OrderByDescending(q => q.LastUser) ?? Enumerable.Empty<User>());
                        break;
                    }

                case nameof(DeviceLoginInfo.User):
                case nameof(DeviceLoginInfo.Password):
                    {
                        FritzServiceOperationHandler.NetworkCredential = new NetworkCredential(DeviceLoginInfo.User?.Name, DeviceLoginInfo.Password);
                        break;
                    }

                default:
                    break;
            }
        }

        protected override bool GetCanExecuteDefaultCommand()
        {
            return !string.IsNullOrWhiteSpace(DeviceType) && !DefaultCommandActive;
        }
    }
}