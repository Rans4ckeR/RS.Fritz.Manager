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
        private HostsGetHostListResponse? hostsGetHostListResponse;

        private ushort index = 0;

        //private DeviceHost[] arrayDeviceHosts;

        //private readonly IHttpGetService httpGetService;
        

        private string hostListPathLink = String.Empty;

        //public HostsViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, IFritzServiceOperationHandler fritzServiceOperationHandler, IHttpGetService httpGetService)
         public HostsViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, IFritzServiceOperationHandler fritzServiceOperationHandler)

            : base(deviceLoginInfo, logger, fritzServiceOperationHandler)
        {
            //this.httpGetService = httpGetService;
        }

        /*
        public DeviceHost[] ArrayDeviceHosts
        {
            get => arrayDeviceHosts; set { _ = SetProperty(ref arrayDeviceHosts, value); }
        }
        */
        /*
        public ObservableCollection<DeviceHost> BindingDeviceHostsCollection
        {
            get => bindingDeviceHostsCollection; set { _ = SetProperty(ref bindingDeviceHostsCollection, value); }
        }
        */

        public HostsGetHostListResponse? HostsGetHostListResponse
        {
            get => hostsGetHostListResponse; set { _ = SetProperty(ref hostsGetHostListResponse, value); }
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
            var logInfo = DeviceLoginInfo;

            


            await Domain.TaskExtensions.WhenAllSafe(new[]
                {
                   //GetHostsGetHostNumberOfEntriesAsync(),
                   GetHostsGetHostListPathAsync(),
                   
                   GetHostsGetGenericHostEntryAsync(index)
                });
        }


        private async Task GetHostsGetHostNumberOfEntriesAsync()
        {
            hostsGetHostNumberOfEntriesResponse = await FritzServiceOperationHandler.GetHostsGetHostNumberOfEntriesAsync();
        }

        private async Task GetHostsGetGenericHostEntryAsync(ushort index)
        {
            hostsGetGenericHostEntryResponse = await FritzServiceOperationHandler.GetHostsGetGenericHostEntryAsync(index);
        }

        private async Task GetHostsGetHostListPathAsync()
        {
            hostsGetHostListPathResponse = await FritzServiceOperationHandler.GetHostsGetHostListPathAsync();

            if (HostsGetHostListPathResponse != null && FritzServiceOperationHandler.InternetGatewayDevice != null)
            {
                HostsGetHostListPathResponse.HostListPathLink = new Uri("http://" + FritzServiceOperationHandler.InternetGatewayDevice.PreferredLocation.Host + ":" + "49000" + hostsGetHostListPathResponse.HostListPath);
                hostsGetHostListResponse = await FritzServiceOperationHandler.GetHostsGetHostListAsync(hostsGetHostListPathResponse.HostListPath);

                using var stringReader = new StringReader(hostsGetHostListResponse.DeviceHostsListXml);
                using var xmlTextReader = new XmlTextReader(stringReader);

                try
                {
                    // fill the array with hosts in HostListResponse (not the actual Data Context)
                    hostsGetHostListResponse.DeviceHostsList = (DeviceHostsList?)new XmlSerializer(typeof(DeviceHostsList)).Deserialize(xmlTextReader);

                    int hostsCount = hostsGetHostListResponse.DeviceHostsList != null ? hostsGetHostListResponse.DeviceHostsList.DeviceHosts.Count() : 0;

                    hostsGetHostListPathResponse.DeviceHostsCollection = new ObservableCollection<DeviceHost>();

                    for (int i = 0; i < hostsCount; i++)
                    {
#pragma warning disable CS8602 // Dereferenzierung eines möglichen Nullverweises.
                        var host = hostsGetHostListResponse.DeviceHostsList.DeviceHosts[i];
#pragma warning restore CS8602 // Dereferenzierung eines möglichen Nullverweises

                        if (i == hostsCount - 1)
                        {
                            hostsGetHostListPathResponse.DeviceHostsCollection.CollectionChanged += DeviceHostsCollection_CollectionChanged;
                        }

                        hostsGetHostListPathResponse.DeviceHostsCollection.Add(host);
                    }
                }
                catch (Exception ex)
                {
                    throw new ValueUnavailableException(ex.Message);
                }
            }
        }

        private void DeviceHostsCollection_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (hostsGetHostListPathResponse != null)
            {
                CollectionViewSource.GetDefaultView(hostsGetHostListPathResponse.DeviceHostsCollection).Refresh();
            }
        }
    }
}