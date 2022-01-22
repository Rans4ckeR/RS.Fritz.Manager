namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetGenericHostEntryResponse")]
#pragma warning disable S101 // Types should be named in PascalCase
    public sealed record HostsGetGenericHostEntryResponse
#pragma warning restore S101 // Types should be named in PascalCase
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [MessageBodyMember(Name = "NewIPAddress")]
        public string IPAddress { get; set; }

        [MessageBodyMember(Name = "NewMACAddress")]
        public string MACAddress { get; set; }

        [MessageBodyMember(Name = "NewAddressSource")]
        public string AddressSource { get; set; }

        [MessageBodyMember(Name = "NewLeaseTimeRemaining")]
        public uint LeaseTimeRemaining { get; set; }

        [MessageBodyMember(Name = "NewInterfaceType")]
        public string InterfaceType { get; set; }

        [MessageBodyMember(Name = "NewActive")]
        public bool Active { get; set; }

        [MessageBodyMember(Name = "NewHostName")]
        public string HostName { get; set; }
    }
}