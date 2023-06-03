namespace RS.Fritz.Manager.UI;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ServiceModel.Security;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

internal sealed class MainWindowViewModel : FritzServiceViewModel
{
    private const double OpacityOverlay = 0.75;
    private const double OpacityNoOverlay = 1d;
    private const int ZIndexOverlay = 1;
    private const int ZIndexNoOverlay = -1;

    private readonly IDeviceSearchService deviceSearchService;
    private ObservableCollection<ObservableInternetGatewayDevice> devices = new();
    private ObservableCollection<User> users = new();
    private ObservableObject? activeView;
    private string? userMessage;
    private bool deviceAndLoginControlsEnabled = true;
    private bool loginCommandActive;
    private bool canExecuteLoginCommand;
    private ImageSource loginButtonImage = new BitmapImage(new("pack://application:,,,/Images/Login.png"));
    private bool discoveryTabSelected = true;
    private double mainContentOpacity = OpacityNoOverlay;
    private bool mainContentIsHitTestVisible = true;
    private int messageZIndex = ZIndexNoOverlay;

    public MainWindowViewModel(
        DeviceLoginInfo deviceLoginInfo,
        ILogger logger,
        IDeviceSearchService deviceSearchService,
        CaptureControlCaptureViewModel captureControlCaptureViewModel,
        WanIpConnectionViewModel wanIpConnectionViewModel,
        HostsViewModel hostsViewModel,
        WanCommonInterfaceConfigViewModel wanCommonInterfaceConfigViewModel,
        WanPppConnectionViewModel wanPppConnectionViewModel,
        Layer3ForwardingViewModel layer3ForwardingViewModel,
        DeviceInfoViewModel deviceInfoViewModel,
        LanConfigSecurityViewModel lanConfigSecurityViewModel,
        WanDslInterfaceConfigViewModel wanDslInterfaceConfigViewModel,
        WanEthernetLinkConfigViewModel wanEthernetLinkConfigViewModel,
        WanDslLinkConfigViewModel wanDslLinkConfigViewModel,
        AvmSpeedtestViewModel avmSpeedtestViewModel,
        LanEthernetInterfaceConfigViewModel lanEthernetInterfaceConfigViewModel,
        LanHostConfigManagementViewModel lanHostConfigManagementViewModel,
        WlanConfigurationViewModel wlanConfigurationViewModel,
        ManagementServerViewModel managementServerViewModel,
        TimeViewModel timeViewModel,
        UserInterfaceViewModel userInterfaceViewModel,
        DeviceConfigViewModel deviceConfigViewModel)
        : base(deviceLoginInfo, logger)
    {
        this.deviceSearchService = deviceSearchService;
        DeviceInfoViewModel = deviceInfoViewModel;
        LanConfigSecurityViewModel = lanConfigSecurityViewModel;
        WanDslInterfaceConfigViewModel = wanDslInterfaceConfigViewModel;
        Layer3ForwardingViewModel = layer3ForwardingViewModel;
        WanPppConnectionViewModel = wanPppConnectionViewModel;
        WanIpConnectionViewModel = wanIpConnectionViewModel;
        WanCommonInterfaceConfigViewModel = wanCommonInterfaceConfigViewModel;
        HostsViewModel = hostsViewModel;
        WanEthernetLinkConfigViewModel = wanEthernetLinkConfigViewModel;
        WanDslLinkConfigViewModel = wanDslLinkConfigViewModel;
        AvmSpeedtestViewModel = avmSpeedtestViewModel;
        CaptureControlCaptureViewModel = captureControlCaptureViewModel;
        LanEthernetInterfaceConfigViewModel = lanEthernetInterfaceConfigViewModel;
        LanHostConfigManagementViewModel = lanHostConfigManagementViewModel;
        WlanConfigurationViewModel = wlanConfigurationViewModel;
        ManagementServerViewModel = managementServerViewModel;
        TimeViewModel = timeViewModel;
        UserInterfaceViewModel = userInterfaceViewModel;
        DeviceConfigViewModel = deviceConfigViewModel;
        LoginCommand = new AsyncRelayCommand<bool?>(ExecuteLoginCommandAsync, _ => CanExecuteLoginCommand);
        CopyMessageCommand = new RelayCommand(ExecuteCopyMessageCommand);
        CloseMessageCommand = new RelayCommand(ExecuteCloseMessageCommand);

        StrongReferenceMessenger.Default.Register<UserMessageValueChangedMessage>(this, (r, m) =>
        {
            ((MainWindowViewModel)r).UserMessage = m.Value.Message;
        });
        StrongReferenceMessenger.Default.Register<ActiveViewValueChangedMessage>(this, (r, m) =>
        {
            ((MainWindowViewModel)r).ActiveView = m.Value;
        });
        StrongReferenceMessenger.Default.Register<PropertyChangedMessage<IEnumerable<User>>>(this, (r, m) =>
        {
            ((MainWindowViewModel)r).Receive(m);
        });
        StrongReferenceMessenger.Default.Register<PropertyChangedMessage<ObservableInternetGatewayDevice?>>(this, (r, m) =>
        {
            ((MainWindowViewModel)r).Receive(m);
        });
        UpdateCanExecuteDefaultCommand();
    }

    public static string Title => "FritzManager";

    public IRelayCommand CopyMessageCommand { get; }

    public IRelayCommand CloseMessageCommand { get; }

    public DeviceInfoViewModel DeviceInfoViewModel { get; }

    public LanConfigSecurityViewModel LanConfigSecurityViewModel { get; }

    public WanDslInterfaceConfigViewModel WanDslInterfaceConfigViewModel { get; }

    public Layer3ForwardingViewModel Layer3ForwardingViewModel { get; }

    public WanIpConnectionViewModel WanIpConnectionViewModel { get; }

    public WanPppConnectionViewModel WanPppConnectionViewModel { get; }

    public WanCommonInterfaceConfigViewModel WanCommonInterfaceConfigViewModel { get; }

    public HostsViewModel HostsViewModel { get; }

    public WanEthernetLinkConfigViewModel WanEthernetLinkConfigViewModel { get; }

    public WanDslLinkConfigViewModel WanDslLinkConfigViewModel { get; }

    public AvmSpeedtestViewModel AvmSpeedtestViewModel { get; }

    public CaptureControlCaptureViewModel CaptureControlCaptureViewModel { get; }

    public LanEthernetInterfaceConfigViewModel LanEthernetInterfaceConfigViewModel { get; }

    public LanHostConfigManagementViewModel LanHostConfigManagementViewModel { get; }

    public WlanConfigurationViewModel WlanConfigurationViewModel { get; }

    public ManagementServerViewModel ManagementServerViewModel { get; }

    public TimeViewModel TimeViewModel { get; }

    public UserInterfaceViewModel UserInterfaceViewModel { get; }

    public DeviceConfigViewModel DeviceConfigViewModel { get; }

    public double MainContentOpacity
    {
        get => mainContentOpacity; set { _ = SetProperty(ref mainContentOpacity, value); }
    }

    public bool MainContentIsHitTestVisible
    {
        get => mainContentIsHitTestVisible; set { _ = SetProperty(ref mainContentIsHitTestVisible, value); }
    }

    public int MessageZIndex
    {
        get => messageZIndex; set { _ = SetProperty(ref messageZIndex, value); }
    }

    public string? UserMessage
    {
        get => userMessage;
        private set
        {
            if (SetProperty(ref userMessage, value))
            {
                if (value is null)
                {
                    MessageZIndex = ZIndexNoOverlay;
                    MainContentOpacity = OpacityNoOverlay;
                    MainContentIsHitTestVisible = true;
                }
                else
                {
                    MessageZIndex = ZIndexOverlay;
                    MainContentOpacity = OpacityOverlay;
                    MainContentIsHitTestVisible = false;
                }
            }
        }
    }

    public bool DeviceAndLoginControlsEnabled
    {
        get => deviceAndLoginControlsEnabled; set { _ = SetProperty(ref deviceAndLoginControlsEnabled, value); }
    }

    public ObservableCollection<User> Users
    {
        get => users;
        private set
        {
            if (SetProperty(ref users, value))
                DeviceLoginInfo.User = Users.SingleOrDefault(q => q.LastUser);
        }
    }

    public ObservableObject? ActiveView
    {
        get => activeView;
        private set => _ = SetProperty(ref activeView, value);
    }

    public ObservableCollection<ObservableInternetGatewayDevice> Devices
    {
        get => devices;
        private set
        {
            if (SetProperty(ref devices, value) && value.Count is 1)
                DeviceLoginInfo.InternetGatewayDevice = Devices.Single();
        }
    }

    public IAsyncRelayCommand LoginCommand { get; }

    public bool LoginCommandActive
    {
        get => loginCommandActive;
        set
        {
            if (SetProperty(ref loginCommandActive, value))
                LoginCommand.NotifyCanExecuteChanged();
        }
    }

    public ImageSource LoginButtonImage
    {
        get => loginButtonImage;
        private set
        {
            if (SetProperty(ref loginButtonImage, value))
                value.Freeze();
        }
    }

    public bool DiscoveryTabSelected
    {
        get => discoveryTabSelected;
        set
        {
            if (SetProperty(ref discoveryTabSelected, value))
            {
                if (value && ActiveView != DeviceLoginInfo.InternetGatewayDevice)
                    ActiveView = DeviceLoginInfo.InternetGatewayDevice;
            }
        }
    }

    private bool CanExecuteLoginCommand
    {
        get => canExecuteLoginCommand;
        set
        {
            if (SetProperty(ref canExecuteLoginCommand, value))
                LoginCommand.NotifyCanExecuteChanged();
        }
    }

    protected override void Receive(PropertyChangedMessage<bool> message)
    {
        base.Receive(message);

        if (message.Sender != DeviceLoginInfo)
            return;

        switch (message.PropertyName)
        {
            case nameof(DeviceLoginInfo.LoginInfoSet):
                {
                    if (message.NewValue)
                        UpdateCanExecuteLoginCommand();
                    break;
                }
        }
    }

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(LoginCommandActive):
                {
                    UpdateCanExecuteLoginCommand();
                    break;
                }

            case nameof(DefaultCommandActive):
                {
                    DeviceAndLoginControlsEnabled = !DefaultCommandActive;
                    break;
                }
        }
    }

    protected override async ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        ActiveView = null;
        DeviceLoginInfo.InternetGatewayDevice = null;
        Devices = new((await deviceSearchService.GetDevicesAsync(cancellationToken: cancellationToken)).Select(q => new ObservableInternetGatewayDevice(q)));
    }

    protected override bool GetCanExecuteDefaultCommand()
    {
        return !DefaultCommandActive;
    }

    private void Receive(PropertyChangedMessage<IEnumerable<User>> message)
    {
        if (message.Sender != DeviceLoginInfo.InternetGatewayDevice)
            return;

        Users = message.PropertyName switch
        {
            nameof(ObservableInternetGatewayDevice.Users) => new(message.NewValue.OrderByDescending(q => q.LastUser)),
            _ => Users
        };
    }

    private void Receive(PropertyChangedMessage<ObservableInternetGatewayDevice?> message)
    {
        if (message.Sender != DeviceLoginInfo)
            return;

        switch (message.PropertyName)
        {
            case nameof(DeviceLoginInfo.InternetGatewayDevice):
                {
                    ActiveView = DeviceLoginInfo.InternetGatewayDevice;
                    LoginButtonImage = new BitmapImage(new("pack://application:,,,/Images/Login.png"));

                    UpdateCanExecuteLoginCommand();
                    break;
                }
        }
    }

    private void UpdateCanExecuteLoginCommand()
    {
        CanExecuteLoginCommand = !LoginCommandActive && DeviceLoginInfo.LoginInfoSet;
    }

    private async Task ExecuteLoginCommandAsync(bool? showView)
    {
        try
        {
            LoginCommandActive = true;

            await DeviceLoginInfo.InternetGatewayDevice!.GetDeviceTypeAsync();

            LoginButtonImage = new BitmapImage(new("pack://application:,,,/Images/Success.png"));
        }
        catch (MessageSecurityException)
        {
            LoginButtonImage = new BitmapImage(new("pack://application:,,,/Images/Fail.png"));
        }
        catch (Exception ex)
        {
            Logger.ExceptionThrown(ex);
        }
        finally
        {
            LoginCommandActive = false;
        }
    }

    private void ExecuteCopyMessageCommand()
    {
        Clipboard.SetText(UserMessage);
    }

    private void ExecuteCloseMessageCommand()
    {
        UserMessage = null;
    }
}