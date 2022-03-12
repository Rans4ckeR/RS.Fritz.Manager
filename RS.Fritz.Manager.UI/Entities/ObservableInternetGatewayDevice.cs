namespace RS.Fritz.Manager.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using RS.Fritz.Manager.API;

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

    public string Server
    {
        get => ApiDevice.Server;
    }

    public string CacheControl
    {
        get => ApiDevice.CacheControl;
    }

    public string? Ext
    {
        get => ApiDevice.Ext;
    }

    public string SearchTarget
    {
        get => ApiDevice.SearchTarget;
    }

    public string UniqueServiceName
    {
        get => ApiDevice.UniqueServiceName;
    }

    public IEnumerable<Uri> Locations
    {
        get => ApiDevice.Locations;
    }

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

    public UPnPDescription? UPnPDescription
    {
        get => ApiDevice.UPnPDescription;
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
            _ => throw new ArgumentOutOfRangeException(nameof(WanCommonInterfaceConfigGetCommonLinkPropertiesResponse.WanAccessType), wanCommonInterfaceConfigGetCommonLinkProperties.WanAccessType, null)
        };
    }
}