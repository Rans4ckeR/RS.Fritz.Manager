namespace RS.Fritz.Manager.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CommunityToolkit.Mvvm.ComponentModel;
    using RS.Fritz.Manager.API;

    internal sealed class ObservableInternetGatewayDevice : ObservableRecipient
    {
        private IEnumerable<User> users = Enumerable.Empty<User>();

        public ObservableInternetGatewayDevice(InternetGatewayDevice internetGatewayDevice)
        {
            this.InternetGatewayDevice = internetGatewayDevice;
        }

        public InternetGatewayDevice InternetGatewayDevice { get; }

        public string Server
        {
            get => InternetGatewayDevice.Server;
        }

        public string CacheControl
        {
            get => InternetGatewayDevice.CacheControl;
        }

        public string? Ext
        {
            get => InternetGatewayDevice.Ext;
        }

        public string SearchTarget
        {
            get => InternetGatewayDevice.SearchTarget;
        }

        public string UniqueServiceName
        {
            get => InternetGatewayDevice.UniqueServiceName;
        }

        public IEnumerable<Uri> Locations
        {
            get => InternetGatewayDevice.Locations;
        }

        public IEnumerable<User> Users
        {
            get => users;
            set => _ = SetProperty(ref users, value, true);
        }

        public UPnPDescription? UPnPDescription
        {
            get => InternetGatewayDevice.UPnPDescription;
            set => _ = SetProperty(InternetGatewayDevice.UPnPDescription, value, InternetGatewayDevice, (u, n) => u.UPnPDescription = n, true);
        }
    }
}