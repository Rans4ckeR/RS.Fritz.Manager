namespace RS.Fritz.Manager.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;
    

    internal sealed class HostsViewModel : FritzServiceViewModel
    {
        private HostsGetHostNumberOfEntriesResponse? hostsGetHostNumberOfEntriesResponse;
        private HostsGetHostListPathResponse? hostsGetHostListPathResponse;
        private HostsGetGenericHostEntryResponse? hostsGetGenericHostEntryResponse;
        private readonly IHttpGetService httpGetService;
        private HostsGetHostListResponse? hostsGetHostListResponse;

        private string hostListPathLink = String.Empty;

        //public HostsViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, IFritzServiceOperationHandler fritzServiceOperationHandler, IHttpGetService httpGetService)
         public HostsViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, IFritzServiceOperationHandler fritzServiceOperationHandler)

            : base(deviceLoginInfo, logger, fritzServiceOperationHandler)
        {
            //this.httpGetService = httpGetService;
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

        public ushort Index = 0;

        protected override async Task DoExecuteDefaultCommandAsync()
        {
            var logInfo = DeviceLoginInfo;


            await Domain.TaskExtensions.WhenAllSafe(new[]
                {
                   //GetHostsGetHostNumberOfEntriesAsync(),
                   GetHostsGetHostListPathAsync(),
                   //GetAllHostEntriesAsync()
                   //GetHostsGetGenericHostEntryAsync(Index)
                });
        }


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

        private async Task GetHostsGetHostNumberOfEntriesAsync()
        {
            hostsGetHostNumberOfEntriesResponse = await FritzServiceOperationHandler.GetHostsGetHostNumberOfEntriesAsync();
        }

        private async Task GetHostsGetHostListPathAsync()
        {
            hostsGetHostListPathResponse = await FritzServiceOperationHandler.GetHostsGetHostListPathAsync();

            if (HostsGetHostListPathResponse != null && FritzServiceOperationHandler.InternetGatewayDevice != null)
            {
                HostsGetHostListPathResponse.HostListPathLink = new Uri("http://" + FritzServiceOperationHandler.InternetGatewayDevice.PreferredLocation.Host + ":" + "49000" + hostsGetHostListPathResponse.HostListPath);
                // FritzServiceOperationHandler.InternetGatewayDevice.SecurityPort

                //string theResponse = await httpGetService.GetHttpResponseAsync(FritzServiceOperationHandler.InternetGatewayDevice.PreferredLocation, true, hostsGetHostListPathResponse.HostListPath, FritzServiceOperationHandler.InternetGatewayDevice.SecurityPort, FritzServiceOperationHandler.NetworkCredential); // NetworkCredential);

               


                string theResponse = await FritzServiceOperationHandler.GetHttpGetResponseAsync(hostsGetHostListPathResponse.HostListPath);

                //string theResponse = await httpGetService.GetHttpResponseAsync(); // NetworkCredential);


                //  string theResponse = await httpGetService.GetHttpResponse(HostsGetHostListPathResponse.HostListPathLink);


                int dummy4 = 1;
            }

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