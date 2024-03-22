namespace RS.Fritz.Manager.UI;

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

internal sealed class ObservableInternetGatewayDevice : ObservableRecipient
{
    private readonly ObservableCollection<InternetGatewayDevice> internetGatewayDevices = [];

    public ObservableInternetGatewayDevice(GroupedInternetGatewayDevice groupedInternetGatewayDevice)
        : base(StrongReferenceMessenger.Default)
        => InternetGatewayDevices = new(groupedInternetGatewayDevice.Devices.OrderByDescending(q => q.UniqueServiceName?.Contains(UPnPConstants.InternetGatewayDeviceV1AvmDeviceType, StringComparison.OrdinalIgnoreCase)));

    public ObservableCollection<InternetGatewayDevice> InternetGatewayDevices
    {
        get => internetGatewayDevices;
        private init => SetProperty(ref internetGatewayDevices, value, true);
    }

    public bool IsAvm => InternetGatewayDevices.Any(q => q.IsAvm);

    public ObservableCollection<string?> Servers => new(InternetGatewayDevices.Select(q => q.Server).Distinct().OrderBy(q => q));

    public ObservableCollection<Uri?> Locations => new(InternetGatewayDevices.SelectMany(q => q.Locations ?? []).Distinct().OrderBy(q => q?.AbsoluteUri));

    public ObservableCollection<string?> SearchTargets => new(InternetGatewayDevices.Select(q => q.SearchTarget).Distinct().OrderBy(q => q));

    public ObservableCollection<string?> CacheControls => new(InternetGatewayDevices.Select(q => q.CacheControl).Distinct().OrderBy(q => q));

    public ObservableCollection<string?> Exts => new(InternetGatewayDevices.Select(q => q.Ext).Distinct().OrderBy(q => q));

    public ObservableCollection<string?> UniqueServiceNames => new(InternetGatewayDevices.Select(q => q.UniqueServiceName).Distinct().OrderBy(q => q));
}