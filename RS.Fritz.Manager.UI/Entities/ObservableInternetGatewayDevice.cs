using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace RS.Fritz.Manager.UI;

internal sealed class ObservableInternetGatewayDevice : ObservableRecipient
{
    public ObservableInternetGatewayDevice(GroupedInternetGatewayDevice groupedInternetGatewayDevice)
        : base(StrongReferenceMessenger.Default)
        => InternetGatewayDevices = [.. groupedInternetGatewayDevice.Devices.OrderByDescending(static q => q.IsAvm)];

#pragma warning disable SA1500 // Braces for multi-line statements should not share line
#pragma warning disable SA1513 // Closing brace should be followed by blank line
    public ObservableCollection<InternetGatewayDevice> InternetGatewayDevices
    {
        get;
        private init => SetProperty(ref field, value, true);
    }
#pragma warning restore SA1500 // Braces for multi-line statements should not share line
#pragma warning restore SA1513 // Closing brace should be followed by blank line

    public bool IsAvm => InternetGatewayDevices.Any(static q => q.IsAvm);

    public ObservableCollection<string?> Servers => [.. InternetGatewayDevices.Select(static q => q.Server).Distinct().OrderBy(static q => q)];

    public ObservableCollection<Uri?> Locations => [.. InternetGatewayDevices.SelectMany(static q => q.Locations ?? []).Distinct().OrderBy(static q => q?.AbsoluteUri)];

    public ObservableCollection<string?> SearchTargets => [.. InternetGatewayDevices.Select(static q => q.SearchTarget).Distinct().OrderBy(static q => q)];

    public ObservableCollection<string?> CacheControls => [.. InternetGatewayDevices.Select(static q => q.CacheControl).Distinct().OrderBy(static q => q)];

    public ObservableCollection<string?> Exts => [.. InternetGatewayDevices.Select(static q => q.Ext).Distinct().OrderBy(static q => q)];

    public ObservableCollection<string?> UniqueServiceNames => [.. InternetGatewayDevices.Select(static q => q.UniqueServiceName).Distinct().OrderBy(static q => q)];
}