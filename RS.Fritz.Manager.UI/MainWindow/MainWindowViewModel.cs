namespace RS.Fritz.Manager.UI
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Messaging;
    using CommunityToolkit.Mvvm.Messaging.Messages;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.API;

    internal sealed class MainWindowViewModel : FritzServiceViewModel, IRecipient<PropertyChangedMessage<IEnumerable<User>>>
    {
        private readonly IDeviceSearchService deviceSearchService;
        private ObservableCollection<ObservableInternetGatewayDevice> devices = new();
        private ObservableCollection<User> users = new();
        private ObservableObject? activeView;
        private string? userMessage;
        private bool deviceAndLoginControlsEnabled = true;

        public MainWindowViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, HostsViewModel hostsViewModel, WanCommonInterfaceConfigViewModel wanCommonInterfaceConfigViewModel, WanPppConnectionViewModel wanPppConnectionViewModel, Layer3ForwardingViewModel layer3ForwardingViewModel, DeviceInfoViewModel deviceInfoViewModel, LanConfigSecurityViewModel lanConfigSecurityViewModel, WanDslInterfaceConfigViewModel wanDslInterfaceConfigViewModel, IFritzServiceOperationHandler fritzServiceOperationHandler, IDeviceSearchService deviceSearchService)
        : base(deviceLoginInfo, logger, fritzServiceOperationHandler)
        {
            this.deviceSearchService = deviceSearchService;
            DeviceInfoViewModel = deviceInfoViewModel;
            LanConfigSecurityViewModel = lanConfigSecurityViewModel;
            WanDslInterfaceConfigViewModel = wanDslInterfaceConfigViewModel;
            Layer3ForwardingViewModel = layer3ForwardingViewModel;
            WanPppConnectionViewModel = wanPppConnectionViewModel;
            WanCommonInterfaceConfigViewModel = wanCommonInterfaceConfigViewModel;
            HostsViewModel = hostsViewModel;

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

        public static string Title => "FritzManager";

        public DeviceInfoViewModel DeviceInfoViewModel { get; }

        public LanConfigSecurityViewModel LanConfigSecurityViewModel { get; }

        public WanDslInterfaceConfigViewModel WanDslInterfaceConfigViewModel { get; }

        public Layer3ForwardingViewModel Layer3ForwardingViewModel { get; }

        public WanPppConnectionViewModel WanPppConnectionViewModel { get; }

        public WanCommonInterfaceConfigViewModel WanCommonInterfaceConfigViewModel { get; }

        public HostsViewModel HostsViewModel { get; }

        public string? UserMessage
        {
            get => userMessage; set { _ = SetProperty(ref userMessage, value); }
        }

        public bool DeviceAndLoginControlsEnabled
        {
            get => deviceAndLoginControlsEnabled; set { _ = SetProperty(ref deviceAndLoginControlsEnabled, value); }
        }

        public ObservableCollection<User> Users { get => users; set => _ = SetProperty(ref users, value); }

        public ObservableObject? ActiveView { get => activeView; set => _ = SetProperty(ref activeView, value); }

        public ObservableCollection<ObservableInternetGatewayDevice> Devices { get => devices; set => _ = SetProperty(ref devices, value); }

        public void Receive(PropertyChangedMessage<IEnumerable<User>> message)
        {
            if (message.Sender != DeviceLoginInfo.InternetGatewayDevice)
                return;

            Users = message.PropertyName switch
            {
                nameof(ObservableInternetGatewayDevice.Users) => new ObservableCollection<User>(message.NewValue.OrderByDescending(q => q.LastUser)),
                _ => Users
            };
        }

        protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            base.FritzServiceViewModelPropertyChanged(sender, e);

            DeviceAndLoginControlsEnabled = e.PropertyName switch
            {
                nameof(DefaultCommandActive) => !DefaultCommandActive,
                _ => DeviceAndLoginControlsEnabled
            };
        }

        protected override async Task DoExecuteDefaultCommandAsync()
        {
            Devices = new ObservableCollection<ObservableInternetGatewayDevice>((await deviceSearchService.GetDevicesAsync()).Select(q => new ObservableInternetGatewayDevice(q)));
        }

        protected override bool GetCanExecuteDefaultCommand()
        {
            return !DefaultCommandActive;
        }
    }
}