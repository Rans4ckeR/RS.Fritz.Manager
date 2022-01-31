namespace RS.Fritz.Manager.Domain
{
      using System.ServiceModel;
    public sealed record HostsGetHostListResponse
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        // [MessageBodyMember(Name = "NewHostNumberOfEntries")]
        public string DeviceHostsListXml { get; set; }

        public DeviceHostsList? DeviceHostsList { get; set; }
    }
}