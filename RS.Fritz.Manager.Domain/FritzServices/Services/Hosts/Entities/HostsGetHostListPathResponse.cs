namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;



    [MessageContract(WrapperName = "GetHostListPathResponse")]
#pragma warning disable S101 // Types should be named in PascalCase
    public sealed record HostsGetHostListPathResponse
#pragma warning restore S101 // Types should be named in PascalCase
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [MessageBodyMember(Name = "NewX_AVM-DE_HostListPath")]
        public string HostListPath { get; set; }

        public Uri? HostListPathLink { get; set; } = null;
        public DeviceHostsList? DeviceHostsList { get; set; }

        public DeviceHost[] ArrayDeviceHosts { get; set; }

        public ObservableCollection<DeviceHostItem> DeviceHostsCollection { get; set; }
    }
}