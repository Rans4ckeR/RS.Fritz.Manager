namespace RS.Fritz.Manager.UI;

using System.Security;
using System.ServiceModel.Security;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

internal sealed class DeviceLoginInfo : ObservableRecipient
{
    private readonly ILogger logger;
    private ObservableInternetGatewayDevice? internetGatewayDevice;
    private InternetGatewayDevice? selectedInternetGatewayDevice;
    private User? user;
    private SecureString? password;
    private bool loginInfoSet;
    private bool authenticated;
    private WanAccessType? wanAccessType;
    private IEnumerable<User> users = [];

    public DeviceLoginInfo(ILogger logger)
        : base(StrongReferenceMessenger.Default)
    {
        IsActive = true;
        this.logger = logger;

        StrongReferenceMessenger.Default.Register<PropertyChangedMessage<ObservableInternetGatewayDevice?>>(this, (r, m) => ((DeviceLoginInfo)r).Receive(m));
        StrongReferenceMessenger.Default.Register<PropertyChangedMessage<InternetGatewayDevice?>>(this, (r, m) => ((DeviceLoginInfo)r).Receive(m));
        StrongReferenceMessenger.Default.Register<PropertyChangedMessage<SecureString?>>(this, (r, m) => ((DeviceLoginInfo)r).Receive(m));
        StrongReferenceMessenger.Default.Register<PropertyChangedMessage<User?>>(this, (r, m) => ((DeviceLoginInfo)r).Receive(m));
    }

    public ObservableInternetGatewayDevice? InternetGatewayDevice
    {
        get => internetGatewayDevice;
        set => _ = SetProperty(ref internetGatewayDevice, value, true);
    }

    public InternetGatewayDevice? SelectedInternetGatewayDevice
    {
        get => selectedInternetGatewayDevice;
        set => _ = SetProperty(ref selectedInternetGatewayDevice, value, true);
    }

    public SecureString? Password
    {
        get => password;
        set => _ = SetProperty(ref password, value, true);
    }

    public User? User
    {
        get => user;
        set => _ = SetProperty(ref user, value, true);
    }

    public bool LoginInfoSet
    {
        get => loginInfoSet;
        private set => _ = SetProperty(ref loginInfoSet, value, true);
    }

    public bool Authenticated
    {
        get => authenticated;
        private set => _ = SetProperty(ref authenticated, value, true);
    }

    public WanAccessType? WanAccessType
    {
        get => wanAccessType;
        set => _ = SetProperty(ref wanAccessType, value, true);
    }

    public IEnumerable<User> Users
    {
        get => users;
        set => _ = SetProperty(ref users, value, true);
    }

    // ReSharper disable once AsyncVoidMethod
    private async void Receive(PropertyChangedMessage<ObservableInternetGatewayDevice?> message)
    {
        try
        {
            if (message.Sender != this)
                return;

            switch (message.PropertyName)
            {
                case nameof(InternetGatewayDevice):
                    {
                        if (message.NewValue is null)
                        {
                            User = null;
                            Password = null;
                            SelectedInternetGatewayDevice = null;
                        }
                        else
                        {
                            SelectedInternetGatewayDevice = message.NewValue.InternetGatewayDevices.SingleOrDefault(q => q.UniqueServiceName?.Contains(UPnPConstants.InternetGatewayDeviceV1AvmDeviceType, StringComparison.OrdinalIgnoreCase) ?? false) ?? message.NewValue.InternetGatewayDevices.MaxBy(q => q.Version);

                            await SelectedInternetGatewayDevice!.InitializeAsync().ConfigureAwait(true);

                            Users = SelectedInternetGatewayDevice.Users!;
                            User = Users.SingleOrDefault(q => q.LastUser);
                        }

                        SetLoginInfo();

                        break;
                    }
            }
        }
        catch (Exception ex)
        {
            logger.ExceptionThrown(ex);
        }
    }

    private void Receive(PropertyChangedMessage<InternetGatewayDevice?> message)
    {
        if (message.Sender != this)
            return;

        switch (message.PropertyName)
        {
            case nameof(SelectedInternetGatewayDevice):
                {
                    Authenticated = false;

                    SetLoginInfo();

                    break;
                }
        }
    }

    private void Receive(PropertyChangedMessage<SecureString?> message)
    {
        if (message.Sender != this)
            return;

        switch (message.PropertyName)
        {
            case nameof(Password):
                if (SelectedInternetGatewayDevice is not null)
                    SelectedInternetGatewayDevice.NetworkCredential = new(User?.Name, Password);

                SetLoginInfo();
                break;
        }
    }

    private void Receive(PropertyChangedMessage<User?> message)
    {
        if (message.Sender != this)
            return;

        switch (message.PropertyName)
        {
            case nameof(User):
                if (SelectedInternetGatewayDevice is not null)
                    SelectedInternetGatewayDevice.NetworkCredential = new(User?.Name, Password);

                SetLoginInfo();
                break;
        }
    }

    private void SetLoginInfo()
        => LoginInfoSet = SelectedInternetGatewayDevice is not null && User is not null && Password is not null;

    public async ValueTask GetDeviceTypeAsync()
    {
        WanCommonInterfaceConfigGetCommonLinkPropertiesResponse wanCommonInterfaceConfigGetCommonLinkProperties;

        try
        {
            wanCommonInterfaceConfigGetCommonLinkProperties = await SelectedInternetGatewayDevice!.WanCommonInterfaceConfigGetCommonLinkPropertiesAsync().ConfigureAwait(true);
        }
        catch (MessageSecurityException)
        {
            Authenticated = false;

            throw;
        }

        Authenticated = true;
        WanAccessType = wanCommonInterfaceConfigGetCommonLinkProperties.WanAccessType switch
        {
            "DSL" => UI.WanAccessType.Dsl,
            "Ethernet" => UI.WanAccessType.Ethernet,
            "X_AVM-DE_Fiber" => UI.WanAccessType.Ethernet,
            "X_AVM-DE_UMTS" => UI.WanAccessType.Ethernet,
            "X_AVM-DE_Cable" => UI.WanAccessType.Ethernet,
            "X_AVM-DE_LTE" => UI.WanAccessType.Ethernet,
            _ => throw new ArgumentOutOfRangeException(nameof(WanCommonInterfaceConfigGetCommonLinkPropertiesResponse.WanAccessType), wanCommonInterfaceConfigGetCommonLinkProperties.WanAccessType, null)
        };
    }
}