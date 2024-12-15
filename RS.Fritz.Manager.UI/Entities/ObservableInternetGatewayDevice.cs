using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace RS.Fritz.Manager.UI;

internal sealed class ObservableInternetGatewayDevice : ObservableRecipient
{
    public ObservableInternetGatewayDevice(GroupedInternetGatewayDevice groupedInternetGatewayDevice)
        : base(StrongReferenceMessenger.Default)
        => InternetGatewayDevices = [.. groupedInternetGatewayDevice.Devices.OrderByDescending(q => q.UniqueServiceName?.Contains(UPnPConstants.InternetGatewayDeviceV1AvmDeviceType, StringComparison.OrdinalIgnoreCase))];

#pragma warning disable SA1500 // Braces for multi-line statements should not share line
#pragma warning disable SA1513 // Closing brace should be followed by blank line
    public ObservableCollection<InternetGatewayDevice> InternetGatewayDevices
    {
        get;
        private init => SetProperty(ref field, value, true);
    } = [];
#pragma warning restore SA1500 // Braces for multi-line statements should not share line
#pragma warning restore SA1513 // Closing brace should be followed by blank line

    public bool IsAvm => InternetGatewayDevices.Any(q => q.IsAvm);

    public ObservableCollection<string?> Servers => [.. InternetGatewayDevices.Select(q => q.Server).Distinct().OrderBy(q => q)];

    public ObservableCollection<Uri?> Locations => [.. InternetGatewayDevices.SelectMany(q => q.Locations ?? []).Distinct().OrderBy(q => q?.AbsoluteUri)];

    public ObservableCollection<string?> SearchTargets => [.. InternetGatewayDevices.Select(q => q.SearchTarget).Distinct().OrderBy(q => q)];

    public ObservableCollection<string?> CacheControls => [.. InternetGatewayDevices.Select(q => q.CacheControl).Distinct().OrderBy(q => q)];

    public ObservableCollection<string?> Exts => [.. InternetGatewayDevices.Select(q => q.Ext).Distinct().OrderBy(q => q)];

    public ObservableCollection<string?> UniqueServiceNames => [.. InternetGatewayDevices.Select(q => q.UniqueServiceName).Distinct().OrderBy(q => q)];
}