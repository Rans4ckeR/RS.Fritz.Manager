namespace RS.Fritz.Manager.UI
{
    using System;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Messaging;
    using CommunityToolkit.Mvvm.Messaging.Messages;
    using RS.Fritz.Manager.Domain;

    internal sealed class ObservableInternetGatewayDevice : ObservableRecipient, IRecipient<PropertyChangedMessage<ObservableInternetGatewayDevice>>
    {
        private readonly InternetGatewayDevice internetGatewayDevice;
        private readonly IFritzServiceOperationHandler fritzServiceOperationHandler;

        public ObservableInternetGatewayDevice(InternetGatewayDevice internetGatewayDevice, IFritzServiceOperationHandler fritzServiceOperationHandler)
        {
            this.internetGatewayDevice = internetGatewayDevice;
            this.fritzServiceOperationHandler = fritzServiceOperationHandler;
        }

        public string? Server
        {
            get => internetGatewayDevice.Server;
            set => _ = SetProperty(internetGatewayDevice.Server, value, internetGatewayDevice, (u, n) => u.Server = n, true);
        }

        public string? CacheControl
        {
            get => internetGatewayDevice.CacheControl;
            set => _ = SetProperty(internetGatewayDevice.CacheControl, value, internetGatewayDevice, (u, n) => u.CacheControl = n, true);
        }

        public string? Ext
        {
            get => internetGatewayDevice.Ext;
            set => _ = SetProperty(internetGatewayDevice.Ext, value, internetGatewayDevice, (u, n) => u.Ext = n, true);
        }

        public string? SearchTarget
        {
            get => internetGatewayDevice.SearchTarget;
            set => _ = SetProperty(internetGatewayDevice.SearchTarget, value, internetGatewayDevice, (u, n) => u.SearchTarget = n, true);
        }

        public string? UniqueServiceName
        {
            get => internetGatewayDevice.UniqueServiceName;
            set => _ = SetProperty(internetGatewayDevice.UniqueServiceName, value, internetGatewayDevice, (u, n) => u.UniqueServiceName = n, true);
        }

        public ushort? SecurityPort
        {
            get => internetGatewayDevice.SecurityPort;
            set => _ = SetProperty(internetGatewayDevice.SecurityPort, value, internetGatewayDevice, (u, n) => u.SecurityPort = n, true);
        }

        public Uri? PreferredLocation
        {
            get => internetGatewayDevice.PreferredLocation;
            set => _ = SetProperty(internetGatewayDevice.PreferredLocation, value, internetGatewayDevice, (u, n) => u.PreferredLocation = n, true);
        }

        public UPnPDescription? UPnPDescription
        {
            get => internetGatewayDevice.UPnPDescription;
            set => _ = SetProperty(internetGatewayDevice.UPnPDescription, value, internetGatewayDevice, (u, n) => u.UPnPDescription = n, true);
        }

        public async void Receive(PropertyChangedMessage<ObservableInternetGatewayDevice> message)
        {
            if (message.NewValue is null)
            {
                fritzServiceOperationHandler.InternetGatewayDevice = null;

                return;
            }

            switch (message.PropertyName)
            {
                case nameof(ObservableInternetGatewayDevice.PreferredLocation):
                    {
                        fritzServiceOperationHandler.InternetGatewayDevice = internetGatewayDevice;

                        DeviceInfoGetSecurityPortResponse deviceInfoGetSecurityPortResponse = await fritzServiceOperationHandler.DeviceInfoGetSecurityPortAsync();

                        internetGatewayDevice!.SecurityPort = deviceInfoGetSecurityPortResponse.SecurityPort;
                        break;
                    }
            }
        }
    }
}