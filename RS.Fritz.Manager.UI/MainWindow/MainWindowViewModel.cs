using System.Collections.ObjectModel;
using System.Net;
using System.ServiceModel.Security;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace RS.Fritz.Manager.UI;

internal sealed class MainWindowViewModel : FritzServiceViewModel
{
    private const double OpacityOverlay = 0.75;
    private const double OpacityNoOverlay = 1d;
    private const int ZIndexOverlay = 1;
    private const int ZIndexNoOverlay = -1;

    private readonly IDeviceSearchService deviceSearchService;

    public MainWindowViewModel(
        DeviceLoginInfo deviceLoginInfo,
        ILogger<MainWindowViewModel> logger,
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
        WanFiberViewModel wanFiberViewModel,
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
        WanFiberViewModel = wanFiberViewModel;
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
        ConnectDirectlyCommand = new AsyncRelayCommand<bool?>(ExecuteConnectDirectlyCommandAsync, _ => CanExecuteConnectDirectlyCommand);

        SetupMessageSubscriptions();
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

    public WanFiberViewModel WanFiberViewModel { get; }

    public AvmSpeedtestViewModel AvmSpeedtestViewModel { get; }

    public CaptureControlCaptureViewModel CaptureControlCaptureViewModel { get; }

    public LanEthernetInterfaceConfigViewModel LanEthernetInterfaceConfigViewModel { get; }

    public LanHostConfigManagementViewModel LanHostConfigManagementViewModel { get; }

    public WlanConfigurationViewModel WlanConfigurationViewModel { get; }

    public ManagementServerViewModel ManagementServerViewModel { get; }

    public TimeViewModel TimeViewModel { get; }

    public UserInterfaceViewModel UserInterfaceViewModel { get; }

    public DeviceConfigViewModel DeviceConfigViewModel { get; }

#pragma warning disable SA1500 // Braces for multi-line statements should not share line
#pragma warning disable SA1513 // Closing brace should be followed by blank line
    public double MainContentOpacity
    {
        get;
        set => _ = SetProperty(ref field, value);
    } = OpacityNoOverlay;

    public bool MainContentIsHitTestVisible
    {
        get;
        set => _ = SetProperty(ref field, value);
    } = true;

    public int MessageZIndex
    {
        get;
        set => _ = SetProperty(ref field, value);
    } = ZIndexNoOverlay;

    public string? UserMessage
    {
        get;
        private set
        {
            if (!SetProperty(ref field, value))
                return;

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

            Log = value;
        }
    }

    public string? Log
    {
        get;
        private set
        {
            value = field is null ? value : FormattableString.Invariant($"{field}{Environment.NewLine}{Environment.NewLine}{value}");

            _ = SetProperty(ref field, value);
        }
    }

    public bool DeviceAndLoginControlsEnabled
    {
        get;
        set => _ = SetProperty(ref field, value);
    } = true;

    public ObservableObject? ActiveView
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public ObservableCollection<ObservableInternetGatewayDevice> Devices
    {
        get;
        private set
        {
            if (SetProperty(ref field, value) && value.Count is 1)
                DeviceLoginInfo.InternetGatewayDevice = Devices.Single();
        }
    } = [];

    public IAsyncRelayCommand LoginCommand { get; }

    public bool LoginCommandActive
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                LoginCommand.NotifyCanExecuteChanged();
        }
    }

    public IAsyncRelayCommand ConnectDirectlyCommand { get; }

    public bool ConnectDirectlyCommandActive
    {
        get;
        set
        {
            if (!SetProperty(ref field, value))
                return;

            UpdateCanExecuteConnectDirectlyCommand();
            ConnectDirectlyCommand.NotifyCanExecuteChanged();
        }
    }

    public ImageSource LoginButtonImage
    {
        get;
        private set
        {
            if (SetProperty(ref field, value))
                value.Freeze();
        }
    } = new BitmapImage(new("pack://application:,,,/Images/Login.png"));

    public bool DiscoveryTabSelected
    {
        get;
        set
        {
            if (!SetProperty(ref field, value))
                return;

            if (value && ActiveView != DeviceLoginInfo.InternetGatewayDevice)
                ActiveView = DeviceLoginInfo.InternetGatewayDevice;
        }
    } = true;

    public string? IpAddress
    {
        get;
        set
        {
            if (!SetProperty(ref field, value))
                return;

            UpdateCanExecuteConnectDirectlyCommand();
        }
    }

    public ushort Port
    {
        get;
        set
        {
            if (!SetProperty(ref field, value))
                return;

            UpdateCanExecuteConnectDirectlyCommand();
        }
    } = UPnPConstants.AvmPort;
#pragma warning restore SA1500 // Braces for multi-line statements should not share line
#pragma warning restore SA1513 // Closing brace should be followed by blank line

    private bool CanExecuteLoginCommand
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                LoginCommand.NotifyCanExecuteChanged();
        }
    }

    private bool CanExecuteConnectDirectlyCommand
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                ConnectDirectlyCommand.NotifyCanExecuteChanged();
        }
    }

    protected override void Receive(PropertyChangedMessage<bool> message)
    {
        base.Receive(message);

        if (message.Sender == this)
        {
            switch (message.PropertyName)
            {
                case nameof(LoginCommandActive):
                    {
                        UpdateCanExecuteLoginCommand();
                        break;
                    }

                case nameof(ConnectDirectlyCommandActive):
                    {
                        UpdateCanExecuteConnectDirectlyCommand();
                        break;
                    }

                case nameof(DefaultCommandActive):
                    {
                        DeviceAndLoginControlsEnabled = !DefaultCommandActive;
                        break;
                    }
            }
        }
        else if (message.Sender == DeviceLoginInfo)
        {
            switch (message.PropertyName)
            {
                case nameof(DeviceLoginInfo.LoginInfoSet):
                    {
                        if (message.NewValue)
                            UpdateCanExecuteLoginCommand();
                        break;
                    }

                case nameof(DeviceLoginInfo.Authenticated):
                    {
                        if (!message.NewValue)
                        {
                            ActiveView = DeviceLoginInfo.InternetGatewayDevice;
                            LoginButtonImage = new BitmapImage(new("pack://application:,,,/Images/Login.png"));

                            UpdateCanExecuteLoginCommand();
                        }

                        break;
                    }
            }
        }
    }

    protected override async ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        ActiveView = null;
        DeviceLoginInfo.InternetGatewayDevice = null;
        Devices = [.. (await deviceSearchService.GetInternetGatewayDevicesAsync(cancellationToken: cancellationToken).ConfigureAwait(true)).Select(static q => new ObservableInternetGatewayDevice(q))];
    }

    protected override bool GetCanExecuteDefaultCommand() => !DefaultCommandActive;

    private void SetupMessageSubscriptions()
    {
        StrongReferenceMessenger.Default.Register<UserMessageValueChangedMessage>(this, static (r, m) => ((MainWindowViewModel)r).UserMessage = m.Value.Message);
        StrongReferenceMessenger.Default.Register<LogMessageValueChangedMessage>(this, static (r, m) => ((MainWindowViewModel)r).Log = m.Value.Message);
        StrongReferenceMessenger.Default.Register<ActiveViewValueChangedMessage>(this, static (r, m) => ((MainWindowViewModel)r).ActiveView = m.Value);
        StrongReferenceMessenger.Default.Register<PropertyChangedMessage<ObservableInternetGatewayDevice?>>(this, static (r, m) => ((MainWindowViewModel)r).Receive(m));
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
        => CanExecuteLoginCommand = !LoginCommandActive && (DeviceLoginInfo.SelectedInternetGatewayDevice?.IsAvm ?? false) && DeviceLoginInfo.LoginInfoSet;

    private void UpdateCanExecuteConnectDirectlyCommand()
        => CanExecuteConnectDirectlyCommand = !ConnectDirectlyCommandActive && IpAddress is not null && IPAddress.TryParse(IpAddress, out _);

    private async Task ExecuteLoginCommandAsync(bool? showView)
    {
        try
        {
            LoginCommandActive = true;

            await DeviceLoginInfo.GetDeviceTypeAsync().ConfigureAwait(true);

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

    private async Task ExecuteConnectDirectlyCommandAsync(bool? showView)
    {
        try
        {
            ConnectDirectlyCommandActive = true;
            ActiveView = null;
            DeviceLoginInfo.InternetGatewayDevice = null;

            GroupedInternetGatewayDevice? device = await deviceSearchService.GetInternetGatewayDeviceAsync(IPAddress.Parse(IpAddress!), Port).ConfigureAwait(true);

            Devices = device is null ? [] : [new ObservableInternetGatewayDevice(device)];
        }
        catch (Exception ex)
        {
            Logger.ExceptionThrown(ex);
        }
        finally
        {
            ConnectDirectlyCommandActive = false;
        }
    }

    private void ExecuteCopyMessageCommand()
        => Clipboard.SetText(UserMessage!);

    private void ExecuteCloseMessageCommand()
        => UserMessage = null;
}