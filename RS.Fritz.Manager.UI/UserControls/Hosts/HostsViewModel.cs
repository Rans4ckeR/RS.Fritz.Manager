namespace RS.Fritz.Manager.UI
{
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Data;
    using System.Xml;
    using System.Xml.Serialization;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal sealed class HostsViewModel : FritzServiceViewModel
    {
        private HostsGetHostNumberOfEntriesResponse? hostsGetHostNumberOfEntriesResponse;
        private HostsGetHostListPathResponse? hostsGetHostListPathResponse;
        private HostsGetGenericHostEntryResponse? hostsGetGenericHostEntryResponse;

        private ushort index = 0;

        public HostsViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, IFritzServiceOperationHandler fritzServiceOperationHandler, IFritzHttpOperationHandler fritzHttpOperationHandler)

            : base(deviceLoginInfo, logger, fritzServiceOperationHandler)
        {
            FritzHttpOperationHandler = fritzHttpOperationHandler;
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

        private IFritzHttpOperationHandler FritzHttpOperationHandler { get; }

        protected override async Task DoExecuteDefaultCommandAsync()
        {
            await Domain.TaskExtensions.WhenAllSafe(new[]
                {
                    GetHostsGetHostListPathAsync(),
                    GetHostsGetHostNumberOfEntriesAsync(),
                    GetHostsGetGenericHostEntryAsync(index)
                });
        }

        private async Task GetHostsGetHostNumberOfEntriesAsync()
        {
            HostsGetHostNumberOfEntriesResponse newHostsGetHostNumberOfEntriesResponse = await FritzServiceOperationHandler.GetHostsGetHostNumberOfEntriesAsync();
            HostsGetHostNumberOfEntriesResponse = newHostsGetHostNumberOfEntriesResponse;
        }

        private async Task GetHostsGetGenericHostEntryAsync(ushort index)
        {
            HostsGetGenericHostEntryResponse newHostsGetGenericHostEntryResponse = await FritzServiceOperationHandler.GetHostsGetGenericHostEntryAsync(index);
            HostsGetGenericHostEntryResponse = newHostsGetGenericHostEntryResponse;
        }

        private async Task GetHostsGetHostListPathAsync()
        {
            HostsGetHostListPathResponse newHostsGetHostListPathResponse = await FritzServiceOperationHandler.GetHostsGetHostListPathAsync();

            if (FritzServiceOperationHandler.InternetGatewayDevice is not null)
            {
                newHostsGetHostListPathResponse.HostListPathLink = new Uri(string.Format("{0}://{1}{2}", FritzServiceOperationHandler.InternetGatewayDevice.PreferredLocation.Scheme, FritzServiceOperationHandler.InternetGatewayDevice.PreferredLocation.Authority, newHostsGetHostListPathResponse.HostListPath));

                Uri hostListPathLink = new Uri(string.Format("{0}://{1}{2}{3}{4}", "https", FritzServiceOperationHandler.InternetGatewayDevice.PreferredLocation.Host, ":", FritzServiceOperationHandler.InternetGatewayDevice.SecurityPort, newHostsGetHostListPathResponse.HostListPath));
                string deviceHostsListXml = await FritzHttpOperationHandler.GetHostsGetHostListAsync(hostListPathLink);

                using var stringReader = new StringReader(deviceHostsListXml);
                using var xmlTextReader = new XmlTextReader(stringReader);

                DeviceHostsList? deviceHostsList = (DeviceHostsList?)new XmlSerializer(typeof(DeviceHostsList)).Deserialize(xmlTextReader);

                if (deviceHostsList is not null)
                    newHostsGetHostListPathResponse.DeviceHostsCollection = new ObservableCollection<DeviceHost>(deviceHostsList.DeviceHosts);

                HostsGetHostListPathResponse = newHostsGetHostListPathResponse;
            }
        }
    }
}