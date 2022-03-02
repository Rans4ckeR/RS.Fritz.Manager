namespace RS.Fritz.Manager.UI
{
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Serialization;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal sealed class HostsViewModel : FritzServiceViewModel
    {
        private const ushort GetHostsGetGenericHostEntryIndex = 0;

        private readonly IHttpClientFactory httpClientFactory;

        private HostsGetHostNumberOfEntriesResponse? hostsGetHostNumberOfEntriesResponse;
        private HostsGetHostListPathResponse? hostsGetHostListPathResponse;
        private HostsGetGenericHostEntryResponse? hostsGetGenericHostEntryResponse;

        public HostsViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, IFritzServiceOperationHandler fritzServiceOperationHandler, IHttpClientFactory httpClientFactory)

            : base(deviceLoginInfo, logger, fritzServiceOperationHandler)
        {
            this.httpClientFactory = httpClientFactory;
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

        protected override async Task DoExecuteDefaultCommandAsync()
        {
            await Domain.TaskExtensions.WhenAllSafe(new[]
                {
                    GetHostsGetHostListPathAsync(),
                    GetHostsGetHostNumberOfEntriesAsync(),
                    GetHostsGetGenericHostEntryAsync()
                });
        }

        private async Task GetHostsGetHostNumberOfEntriesAsync()
        {
            HostsGetHostNumberOfEntriesResponse newHostsGetHostNumberOfEntriesResponse = await FritzServiceOperationHandler.GetHostsGetHostNumberOfEntriesAsync();
            HostsGetHostNumberOfEntriesResponse = newHostsGetHostNumberOfEntriesResponse;
        }

        private async Task GetHostsGetGenericHostEntryAsync()
        {
            HostsGetGenericHostEntryResponse newHostsGetGenericHostEntryResponse = await FritzServiceOperationHandler.GetHostsGetGenericHostEntryAsync(GetHostsGetGenericHostEntryIndex);
            HostsGetGenericHostEntryResponse = newHostsGetGenericHostEntryResponse;
        }

        private async Task GetHostsGetHostListPathAsync()
        {
            HostsGetHostListPathResponse newHostsGetHostListPathResponse = await FritzServiceOperationHandler.GetHostsGetHostListPathAsync();

            if (FritzServiceOperationHandler.InternetGatewayDevice is not null)
            {
                newHostsGetHostListPathResponse.HostListPathLink = new Uri(FormattableString.Invariant($"{FritzServiceOperationHandler.InternetGatewayDevice.PreferredLocation.Scheme}://{FritzServiceOperationHandler.InternetGatewayDevice.PreferredLocation.Authority}{newHostsGetHostListPathResponse.HostListPath}"));

                Uri hostListPathLink = new Uri(FormattableString.Invariant($"https://{FritzServiceOperationHandler.InternetGatewayDevice.PreferredLocation.Host}:{FritzServiceOperationHandler.InternetGatewayDevice.SecurityPort}{newHostsGetHostListPathResponse.HostListPath}"));
                string deviceHostsListXml = await GetHostsGetHostListAsync(hostListPathLink);

                using var stringReader = new StringReader(deviceHostsListXml);
                using var xmlTextReader = new XmlTextReader(stringReader);

                DeviceHostsList? deviceHostsList = (DeviceHostsList?)new XmlSerializer(typeof(DeviceHostsList)).Deserialize(xmlTextReader);

                if (deviceHostsList is not null)
                    newHostsGetHostListPathResponse.DeviceHostsCollection = new ObservableCollection<DeviceHost>(deviceHostsList.DeviceHosts);

                HostsGetHostListPathResponse = newHostsGetHostListPathResponse;
            }
        }

        private async Task<string> GetHostsGetHostListAsync(Uri uri)
        {
            return await httpClientFactory.CreateClient(Constants.NonValidatingHttpsClientName).GetStringAsync(uri);
        }
    }
}