namespace RS.Fritz.Manager.UI
{
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
            InternetGatewayDevice = internetGatewayDevice;
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
            get => InternetGatewayDevice.UPnPDescription;
            set => _ = SetProperty(InternetGatewayDevice.UPnPDescription, value, InternetGatewayDevice, (u, n) => u.UPnPDescription = n, true);
        }

        public Task<TResult> ExecuteAsync<TResult>(Func<IFritzServiceOperationHandler, InternetGatewayDevice, Task<TResult>> operation)
        {
            return InternetGatewayDevice.ExecuteAsync(operation);
        }

        public async Task GetDeviceTypeAsync()
        {
            WanCommonInterfaceConfigGetCommonLinkPropertiesResponse wanCommonInterfaceConfigGetCommonLinkProperties;

            try
            {
                wanCommonInterfaceConfigGetCommonLinkProperties = await InternetGatewayDevice.ExecuteAsync((h, d) => h.GetWanCommonInterfaceConfigGetCommonLinkPropertiesAsync(d));
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
}