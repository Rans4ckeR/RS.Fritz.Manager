namespace RS.Fritz.Manager.UI
{
    using System;
    using System.Collections.ObjectModel;
    using RS.Fritz.Manager.API;

    internal readonly record struct DeviceHostInfo(string HostListPath, Uri HostListPathLink, ObservableCollection<DeviceHost> DeviceHosts);
}