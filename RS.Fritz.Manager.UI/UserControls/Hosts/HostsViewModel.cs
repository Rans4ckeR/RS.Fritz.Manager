namespace RS.Fritz.Manager.UI
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Net.Http;
    using System.Data;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;
    using System;
    using System.Runtime.InteropServices;
    using System.Net;
    using System.Security;
    using System.Windows.Input;
    using System.Xml.Serialization;
    using System.Xml;
    using System.Xml.Linq;
    
    
    using System.IO;



    using System.IO;
    
    using System.Xml;
    using System.Xml.Serialization;
    
    

    internal sealed class HostsViewModel : FritzServiceViewModel
    {
        private HostsGetHostNumberOfEntriesResponse? hostsGetHostNumberOfEntriesResponse;
        private HostsGetHostListPathResponse? hostsGetHostListPathResponse;
        private HostsGetGenericHostEntryResponse? hostsGetGenericHostEntryResponse;
        private HostsGetHostListResponse? hostsGetHostListResponse; //= new HostsGetHostListResponse() { DeviceHostsList = string.Empty};

        private DataSet hostsDataSet;

        private DeviceHost[] arrayDeviceHosts;

        private readonly IHttpGetService httpGetService;
        

        private string hostListPathLink = String.Empty;

        //public HostsViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, IFritzServiceOperationHandler fritzServiceOperationHandler, IHttpGetService httpGetService)
         public HostsViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, IFritzServiceOperationHandler fritzServiceOperationHandler)

            : base(deviceLoginInfo, logger, fritzServiceOperationHandler)
        {
            //this.httpGetService = httpGetService;
        }

        public DeviceHost[] ArrayDeviceHosts
        {
            get => arrayDeviceHosts; set { _ = SetProperty(ref arrayDeviceHosts, value); }
        }


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

                hostsGetHostListResponse = await FritzServiceOperationHandler.GetHostsGetHostListAsync(hostsGetHostListPathResponse.HostListPath);

                using var stringReader = new StringReader(hostsGetHostListResponse.DeviceHostsListXml);
                using var xmlTextReader = new XmlTextReader(stringReader);


                /*
              HostsGetHostListPathResponse.DeviceHostsCollection = new ObservableCollection<DeviceHostItem>();


              XDocument document = XDocument.Parse(hostsGetHostListResponse.DeviceHostsListXml);

              IEnumerable<XElement> items = document.Descendants("Item");

              foreach (XElement item in items)
              {
                  using var stringReader2 = new StringReader(item.ToString());
                  using var xmlTextReader2 = new XmlTextReader(stringReader2);

                  try
                  {
                      XmlSerializer serializer = new XmlSerializer(typeof(DeviceHostItem));

                      var deviceHostItem = (DeviceHostItem?)serializer.Deserialize(xmlTextReader2);

                      // var deviceHostItem = serializer.Deserialize(xmlTextReader2);


                      HostsGetHostListPathResponse.DeviceHostsCollection.Add(deviceHostItem);
                      int dummy23 = 1;
                  }
                  catch (Exception ex)
                  {
                      string mess = ex.Message;
                  }
              }
              */

                try
                {


                    hostsGetHostListResponse.DeviceHostsList = (DeviceHostsList?)new XmlSerializer(typeof(DeviceHostsList)).Deserialize(xmlTextReader);

                    int theCount = hostsGetHostListResponse.DeviceHostsList.DeviceHosts.Count();

                    HostsGetHostListPathResponse.DeviceHostsCollection = new ObservableCollection<DeviceHost>();

                    for (int i = 0; i < theCount; i++)
                    {
                        var theResult = hostsGetHostListResponse.DeviceHostsList.DeviceHosts[i];
                        HostsGetHostListPathResponse.DeviceHostsCollection.Add(theResult);

                        int dummy56 = 1;
                    }
                    

                   // HostsGetHostListPathResponse.DeviceHostsCollection = new ObservableCollection<DeviceHost>();

                   // HostsGetHostListPathResponse.DeviceHostsCollection = hostsGetHostListResponse.DeviceHostsList.DeviceHosts;

                    //var deviceHosts = (DeviceHost?)new XmlSerializer(typeof(DeviceHost)).Deserialize(xmlTextReader);


                    // var theColl = ObservableCollection<DeviceHost>(hostsGetHostListResponse.DeviceHostsList.DeviceHosts.ToList<DeviceHost>());

                    // hostsGetHostListPathResponse.DeviceHostsCollection  ((DeviceHostsList?)new XmlSerializer(typeof(DeviceHostsList)).Deserialize(xmlTextReader));


                    //ObservableCollection<DeviceHost>(yourlist);

                    //  List<DeviceHostsList> theList = hostsGetHostListResponse.DeviceHostsList.DeviceHosts.ToList<DeviceHost>();






                    // hostsGetHostListResponse.DeviceHostsCollection = hostsGetHostListResponse.DeviceHostsList.to


                    //System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(hostsGetHostListResponse.DeviceHostsList[0].GetType());

                    /*
                    
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(hostsGetHostListResponse.DeviceHostsList.DeviceHosts[0].GetType());
                    var buffer = new StringBuilder();
                    var writer = XmlWriter.Create(buffer);
                    xmlSerializer.Serialize(writer, hostsGetHostListResponse.DeviceHostsList.DeviceHosts[0]);
                    string xmlString = buffer.ToString();

                    using var stringReader2 = new StringReader(xmlString);

                    using var xmlTextReader2 = new XmlTextReader(stringReader);

                    XElement element = XElement.Load(stringReader);

                    var hostProperties = element.Descendants("Item").Elements();

                    */


                    //var serializeer = new XmlSerializer(typeof(DeviceHostsList)).Serialize

                    /*
                    theCount = hostsGetHostListResponse.DeviceHostsList.DeviceHosts.Count();

                    for (int i = 0; i < theCount; i++)
                    {

                    }
                    */

                    //ArrayDeviceHosts = hostsGetHostListResponse.DeviceHostsList.DeviceHosts.ToArray<DeviceHost>();

                    ArrayDeviceHosts = hostsGetHostListResponse.DeviceHostsList.DeviceHosts;

                    hostsGetHostListPathResponse.ArrayDeviceHosts = hostsGetHostListResponse.DeviceHostsList.DeviceHosts.ToArray();

                    //hostsGetHostListPathResponse.ArrayDeviceHosts[0] = 

                    string theLine = hostsGetHostListPathResponse.ArrayDeviceHosts[0].ToString();



                    //hostsGetHostListPathResponse.DeviceHostsList = hostsGetHostListResponse.DeviceHostsList;



                    int dummy5 = 1;

                    hostsDataSet = new DataSet("Item");

                   // hostsDataSet.ReadXml(textReader);

                    //hostsDataSet.ReadXml(new XmlSerializer(typeof(DeviceHostsList)).Deserialize(xmlTextReader));

                    int dummy6 = 1;
                }
                catch (Exception ex)
                {
                    string mess = ex.Message;
                }
                

              //  internetGatewayDevice.UPnPDescription = (UPnPDescription?)new XmlSerializer(typeof(UPnPDescription)).Deserialize(xmlTextReader);

                int dummy4 = 1;
            }

            // For breakpoint:
            int dummy3 = 1;
        }


       // protected void GetSerializationData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);

        private async Task GetHostsGetGenericHostEntryAsync(ushort index)
        {
            hostsGetGenericHostEntryResponse = await FritzServiceOperationHandler.GetHostsGetGenericHostEntryAsync(index);
            // For breakpoint:
            int dummy3 = 1;
        }
    }
}