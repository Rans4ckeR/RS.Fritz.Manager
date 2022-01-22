namespace RS.Fritz.Manager.UI
{
    using System.Text;
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal sealed class HostsViewModel : FritzServiceViewModel
    {
        private HostsGetHostNumberOfEntriesResponse? hostsGetHostNumberOfEntriesResponse;
        private HostsGetHostListPathResponse? hostsGetHostListPathResponse;
        private HostsGetGenericHostEntryResponse? hostsGetGenericHostEntryResponse;

        public HostsViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, IFritzServiceOperationHandler fritzServiceOperationHandler)
            : base(deviceLoginInfo, logger, fritzServiceOperationHandler)
        {
        }

        public HostsGetHostNumberOfEntriesResponse? HostsGetHostNumberOfEntriesResponse
        {
            get => hostsGetHostNumberOfEntriesResponse; set { _ = SetProperty(ref hostsGetHostNumberOfEntriesResponse, value); }
        }

        public HostsGetHostListPathResponse? HostsGetHostListPathResponse
        {
            get => hostsGetHostListPathResponse; set { _ = SetProperty(ref hostsGetHostListPathResponse, value); }
        }

        public HostsGetGenericHostEntryResponse? HostsGetGenericHostEntryResponse
        {
            get => hostsGetGenericHostEntryResponse; set { _ = SetProperty(ref hostsGetGenericHostEntryResponse, value); }
        }

        // ObservableInternetGatewayDevice gatewayDevice = new ObservableInternetGatewayDevice();

        

        public ushort Index = 10;

        protected override async Task DoExecuteDefaultCommandAsync()
        {
            var logInfo = DeviceLoginInfo;

            //IEnumerable<Uri>

            Uri? preferredLocation;

            try
            {
                preferredLocation = FritzServiceOperationHandler.InternetGatewayDevice.PreferredLocation;

               // FritzServiceOperationHandler.InternetGatewayDevice.Locations.Location

                int dummy4 = 1;
            }
            catch
            {
                // ignore
            }

           // string theServer = gatewayDevice.Server;
            
            await Domain.TaskExtensions.WhenAllSafe(new[]
                {
                   GetHostsGetHostNumberOfEntriesAsync(),
                   GetHostsGetHostListPathAsync(),
                   //GetAllHostEntriesAsync()
                   GetHostsGetGenericHostEntryAsync(Index)
                });
        }

        /*
        private async Task GetAllHostEntriesAsync()
        {
            StringBuilder lineBuffer = new StringBuilder();  
            if (hostsGetHostNumberOfEntriesResponse != null && hostsGetHostNumberOfEntriesResponse.HostNumberOfEntries > 0)
            {
                for (ushort i = 0; i < hostsGetHostNumberOfEntriesResponse.HostNumberOfEntries; i++)
                {
                    await GetHostsGetGenericHostEntryAsync(i);
                    lineBuffer.Append(hostsGetGenericHostEntryResponse.IPAddress + " ");
                    lineBuffer.Append(hostsGetGenericHostEntryResponse.MACAddress + " ");
                    lineBuffer.Append("\r\n");
                }
            }
            string allHostsString = lineBuffer.ToString();
            int dummy3 = 1;

        }
        */

        private async Task GetHostsGetHostNumberOfEntriesAsync()
        {
            hostsGetHostNumberOfEntriesResponse = await FritzServiceOperationHandler.GetHostsGetHostNumberOfEntriesAsync();
        }

        private async Task GetHostsGetHostListPathAsync()
        {
            hostsGetHostListPathResponse = await FritzServiceOperationHandler.GetHostsGetHostListPathAsync();
            // For breakpoint:
            int dummy3 = 1;
        }

        private async Task GetHostsGetGenericHostEntryAsync(ushort index)
        {
            hostsGetGenericHostEntryResponse = await FritzServiceOperationHandler.GetHostsGetGenericHostEntryAsync(index);
            // For breakpoint:
            int dummy3 = 1;
        }
    }
}