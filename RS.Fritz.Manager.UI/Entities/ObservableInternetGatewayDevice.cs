namespace RS.Fritz.Manager.UI;

using System.ServiceModel.Security;
using CommunityToolkit.Mvvm.ComponentModel;

internal sealed class ObservableInternetGatewayDevice : ObservableRecipient
{
    private IEnumerable<User> users = Enumerable.Empty<User>();
    private WanAccessType? wanAccessType;
    private bool authenticated;

    public ObservableInternetGatewayDevice(InternetGatewayDevice internetGatewayDevice)
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

    public async Task GetDeviceTypeAsync()
    {
        WanCommonInterfaceConfigGetCommonLinkPropertiesResponse wanCommonInterfaceConfigGetCommonLinkProperties;

        try
        {
            wanCommonInterfaceConfigGetCommonLinkProperties = await ApiDevice.WanCommonInterfaceConfigGetCommonLinkPropertiesAsync();
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