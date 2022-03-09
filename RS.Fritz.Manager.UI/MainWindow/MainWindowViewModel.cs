namespace RS.Fritz.Manager.UI;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Security;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    private bool loginCommandActive;
    private bool canExecuteLoginCommand;

    public MainWindowViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, WanIpConnectionViewModel wanIpConnectionViewModel, HostsViewModel hostsViewModel, WanCommonInterfaceConfigViewModel wanCommonInterfaceConfigViewModel, WanPppConnectionViewModel wanPppConnectionViewModel, Layer3ForwardingViewModel layer3ForwardingViewModel, DeviceInfoViewModel deviceInfoViewModel, LanConfigSecurityViewModel lanConfigSecurityViewModel, WanDslInterfaceConfigViewModel wanDslInterfaceConfigViewModel, IDeviceSearchService deviceSearchService)
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
        LoginCommand = new AsyncRelayCommand<bool?>(ExecuteLoginCommandAsync, _ => CanExecuteLoginCommand);

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

    public WanIpConnectionViewModel WanIpConnectionViewModel { get; }

    public WanPppConnectionViewModel WanPppConnectionViewModel { get; }

    public WanCommonInterfaceConfigViewModel WanCommonInterfaceConfigViewModel { get; }

    public HostsViewModel HostsViewModel { get; }

    public string? UserMessage
    {
        get => userMessage; private set { _ = SetProperty(ref userMessage, value); }
    }

    public bool DeviceAndLoginControlsEnabled
    {
        get => deviceAndLoginControlsEnabled; set { _ = SetProperty(ref deviceAndLoginControlsEnabled, value); }
    }

    public ObservableCollection<User> Users { get => users; set => _ = SetProperty(ref users, value); }

    public ObservableObject? ActiveView { get => activeView; set => _ = SetProperty(ref activeView, value); }

    public ObservableCollection<ObservableInternetGatewayDevice> Devices { get => devices; set => _ = SetProperty(ref devices, value); }

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

    private bool CanExecuteLoginCommand
    {
        get => canExecuteLoginCommand;
        set
        {
            if (SetProperty(ref canExecuteLoginCommand, value))
                LoginCommand.NotifyCanExecuteChanged();
        }
    }

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

    public override void Receive(PropertyChangedMessage<bool> message)
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

    protected override async Task DoExecuteDefaultCommandAsync()
    {
        ActiveView = null;
        DeviceLoginInfo.InternetGatewayDevice = null;
        Devices = new ObservableCollection<ObservableInternetGatewayDevice>((await deviceSearchService.GetDevicesAsync()).Select(q => new ObservableInternetGatewayDevice(q)));
    }

    protected override bool GetCanExecuteDefaultCommand()
    {
        return !DefaultCommandActive;
    }

    private void UpdateCanExecuteLoginCommand()
    {
        CanExecuteLoginCommand = !LoginCommandActive && DeviceLoginInfo.LoginInfoSet;
    }

    private async Task ExecuteLoginCommandAsync(bool? showView)
    {
        LoginCommandActive = true;

        try
        {
            await DeviceLoginInfo.InternetGatewayDevice!.GetDeviceTypeAsync();
        }
        catch (MessageSecurityException)
        {
            Logger.LogWarning("Invalid password");
        }
        finally
        {
            LoginCommandActive = false;
        }
    }
}