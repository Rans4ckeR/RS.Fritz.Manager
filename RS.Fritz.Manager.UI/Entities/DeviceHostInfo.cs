namespace RS.Fritz.Manager.UI;

using System.Collections.ObjectModel;

internal readonly record struct DeviceHostInfo(string HostListPath, Uri HostListPathLink, ObservableCollection<DeviceHost> DeviceHosts);