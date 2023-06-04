namespace RS.Fritz.Manager.UI;

using System.ServiceModel.Security;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

internal sealed class ObservableInternetGatewayDevice : ObservableRecipient
{
    private IEnumerable<User> users = Enumerable.Empty<User>();
    private WanAccessType? wanAccessType;
    private bool authenticated;

    public ObservableInternetGatewayDevice(InternetGatewayDevice internetGatewayDevice)
        : base(StrongReferenceMessenger.Default)
    {
        ApiDevice = internetGatewayDevice;
    }

    public InternetGatewayDevice ApiDevice { get; }

    public IEnumerable<User> Users
    {
        get => users;
        set => _ = SetProperty(ref users, value, true);
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

    public async ValueTask GetDeviceTypeAsync()
    {
        WanCommonInterfaceConfigGetCommonLinkPropertiesResponse wanCommonInterfaceConfigGetCommonLinkProperties;

        try
        {
            wanCommonInterfaceConfigGetCommonLinkProperties = await ApiDevice.WanCommonInterfaceConfigGetCommonLinkPropertiesAsync().ConfigureAwait(true);
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